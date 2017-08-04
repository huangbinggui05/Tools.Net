using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBG.Data
{
    /// <summary>
    /// SQLiteDbAccessorAdaptee 适配类
    /// </summary>
    public class SQLiteDbAccessorAdapter : DbAccessor
    {
        public SQLiteDbAccessorAdapter():base() { }
        public SQLiteDbAccessorAdapter(string connString, int timeout)
        {
            this.adaptee = new SQLiteDbAccessorAdaptee(connString, timeout);
        }

        private SQLiteDbAccessorAdaptee adaptee = null;
        public override DataSet ExecuteDataSet(string cmdText)
        {
            return adaptee.ExecuteDataSet(cmdText);
        }
        public override DbDataReader ExecuteReader(string cmdText)
        {
            return adaptee.ExecuteReader(cmdText);
        }
        public override object ExecuteScalar(string cmdText)
        {
            return adaptee.ExecuteScalar(cmdText);
        }
        public override int ExecuteNonQuery(string cmdText)
        {
            return adaptee.ExecuteNonQuery(cmdText);
        }
    }
}
