using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Data
{
    /// <summary>
    /// 被适配的SQLite数据库交互类
    /// </summary>
    public class SQLiteDbAccessorAdaptee : DbConfig
    {
        public SQLiteDbAccessorAdaptee(string connString, int timeout):base(connString, timeout)
        {
        }
        /// <summary>
        /// 数据库路径
        /// </summary>
        private static readonly string dataSource = HBG.Utils.Common.AppRootDirPath +"\\"+ ConfigurationManager.AppSettings["SQLiteDataSource"];

        /// <summary>
        /// 静态构造函数，初始化连接字符串，检查数据库连接
        /// </summary>
        public SQLiteDbAccessorAdaptee()
        {
            SQLiteConnectionStringBuilder connectionStringBuilder = new SQLiteConnectionStringBuilder
            {
                Version = 3,
                Pooling = true,
                FailIfMissing = false,
                DataSource = dataSource
            };
            connString = connectionStringBuilder.ConnectionString;
        }
        /// <summary>
        /// 获得连接对象
        /// </summary>
        /// <returns></returns>
        private SQLiteConnection GetSQLiteConnection()
        {
            return new SQLiteConnection(connString);
        }
        /// <summary>
        /// 预备命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] commandParameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (commandParameters != null)
            {
                foreach (object parm in commandParameters)
                    cmd.Parameters.AddWithValue(string.Empty, parm);
            }
        }

        public int ExecuteNonQuery(string cmdText)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            int result = 0;
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                PrepareCommand(cmd, conn, cmdText);
                try
                {
                    result= cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    LogHelper.GetInstance().WriteLog(string.Format("SQLite异常：{0}\n{1}",e.Message,e.StackTrace));
                }
            }
            return result;
        }

        public DataSet ExecuteDataSet(string cmdText, params object[] commandParameters)
        {
            DataSet ds = new DataSet();
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                PrepareCommand(cmd, conn, cmdText, commandParameters);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds;
        }

        public SQLiteDataReader ExecuteReader(string cmdText, params object[] commandParameters)
        {
            SQLiteCommand command = new SQLiteCommand();
            SQLiteConnection conn = GetSQLiteConnection();
            try
            {
                PrepareCommand(command, conn, cmdText, commandParameters);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        public object ExecuteScalar(string cmdText, params object[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection conn = GetSQLiteConnection())
            {
                PrepareCommand(cmd, conn, cmdText, commandParameters);
                return cmd.ExecuteScalar();
            }
        }
    }
}
