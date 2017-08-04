using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Reflection;
using System.Configuration;

namespace HBG.Data.Common.UnitTest
{
    [TestClass]
    public class DbAccessorUnitTest
    {
        /// <summary>
        /// DbAccessor 测试代码
        /// </summary>
        [TestMethod]
        public void TestSQLite()
        {
            DbAccessor dbAccessor = null;

            //带构造函数不带参数
            dbAccessor = (DbAccessor)Assembly.Load("HBG.Data.Common").CreateInstance("HBG.Data.Common.SQLiteDbAccessorAdapter", false);

            //带构造函数带参数
            Type t = Assembly.Load("HBG.Data.Common").GetType("HBG.Data.Common.SQLiteDbAccessorAdapter");
            string connString = ConfigurationManager.ConnectionStrings["SqlServer.主数据库"].ToString();
            dbAccessor = (SQLServerDbAccessorAdapter)Activator.CreateInstance(t, new object[] { connString, 180 });

            //增
            string insertCmdText = "insert into T_USER(UserId,UserName,UserPwd) values('3','hbg','123');";
            int insertResult = dbAccessor.ExecuteNonQuery(insertCmdText);

            //删
            string delCmdText = "delete from T_USER where UserId='3';";
            int delResult = dbAccessor.ExecuteNonQuery(delCmdText);

            //改
            string updateCmdText = "update T_USER set UserPwd='123456' where UserId='2';";
            int updateResult = dbAccessor.ExecuteNonQuery(updateCmdText);

            //查
            string selectCmdText = "select * from T_USER;";
            DataSet ds = dbAccessor.ExecuteDataSet(selectCmdText);

        }
        /// <summary>
        /// DbAccessor 测试代码
        /// </summary>
        [TestMethod]
        public void TestSQLServer()
        {
            DbAccessor dbAccessor = null;

            //带构造函数不带参数
            dbAccessor = (DbAccessor)Assembly.Load("HBG.Data.Common").CreateInstance("HBG.Data.Common.SQLServerDbAccessorAdapter", false);

            //带构造函数带参数
            Type t = Assembly.Load("HBG.Data.Common").GetType("HBG.Data.Common.SQLServerDbAccessorAdapter");
            string connString = ConfigurationManager.ConnectionStrings["SqlServer.主数据库"].ToString();
            dbAccessor = (SQLServerDbAccessorAdapter)Activator.CreateInstance(t, new object[] { connString, 180 });

            //增
            string insertCmdText = "insert into T_USER(UserId,UserName,UserPwd) values('3','hbg','123');";
            int insertResult = dbAccessor.ExecuteNonQuery(insertCmdText);

            //删
            string delCmdText = "delete from T_USER where UserId='3';";
            int delResult = dbAccessor.ExecuteNonQuery(delCmdText);

            //改
            string updateCmdText = "update T_USER set UserPwd='123456' where UserId='2';";
            int updateResult = dbAccessor.ExecuteNonQuery(updateCmdText);

            //查
            string selectCmdText = "select * from T_USER;";
            DataSet ds = dbAccessor.ExecuteDataSet(selectCmdText);

        }
    }
}
