using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Data
{
    public class DbConfig
    {
        public DbConfig(string connString, int timeout)
        {
            DbConfig.connString = connString;
            DbConfig.timeout = timeout;
        }

        //SQLite ConnectionString 样例：Data Source=Test.db;Pooling=true;FailIfMissing=false
        protected static string connString = string.Empty;

        public DbConfig()
        {
            try
            {
                connString = ConfigurationManager.ConnectionStrings["主数据库"].ToString();
            }
            catch (Exception e)
            {
                LogHelper.GetInstance().WriteLog(string.Format("未指定名称叫【主数据库】的连接字符串！"));
            }
        }

        protected static int timeout = 180;//执行SQL超时（秒）
        public string ConnString
        {
            get { return connString; }
            set { connString = value; }
        }
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }
    }
}
