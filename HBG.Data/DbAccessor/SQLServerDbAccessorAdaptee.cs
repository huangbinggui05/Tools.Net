using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Data
{
    /// <summary>
    /// 被适配的SQLServer数据库交互类
    /// </summary>
    public class SQLServerDbAccessorAdaptee : DbConfig
    {
        public SQLServerDbAccessorAdaptee(string connString,int timeout):base(connString, timeout)
        {
        }
        public DataSet ExecuteDataSet(string cmdText)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandTimeout = timeout;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds;
        }
        public SqlDataReader ExecuteDataReader(string cmdText)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandTimeout = timeout;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        public object ExecuteScalar(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandTimeout = timeout;
                return cmd.ExecuteScalar();
            }
        }
        public int ExecuteNonQuery(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandTimeout = timeout;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
