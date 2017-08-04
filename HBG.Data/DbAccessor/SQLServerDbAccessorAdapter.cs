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
    /// SQLServerDbAccessorAdaptee 适配类
    /// </summary>
    public class SQLServerDbAccessorAdapter : DbAccessor
    {
        public SQLServerDbAccessorAdapter(){}
        public SQLServerDbAccessorAdapter(string connString, int timeout)
        {
            this.adaptee = new SQLServerDbAccessorAdaptee(connString,timeout);
        }
        private SQLServerDbAccessorAdaptee adaptee = null;
        public override DataSet ExecuteDataSet(string cmdText)
        {
            return adaptee.ExecuteDataSet(cmdText);
        }
        public override DbDataReader ExecuteReader(string cmdText)
        {
            return adaptee.ExecuteDataReader(cmdText);
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
