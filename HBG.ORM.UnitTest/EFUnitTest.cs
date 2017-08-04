using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HBG.ORM.EF;
using HBG.ORM.EF.SQLServer;

namespace HBG.ORM.UnitTest
{
    [TestClass]
    public class EFUnitTest
    {
        [TestMethod]
        public void TestEF()
        {
            using (Super100网管系统自监控v1Entities db = new Super100网管系统自监控v1Entities())
            {
                T_YJCollectProgramMonitor_Cron cron = new T_YJCollectProgramMonitor_Cron();
                cron.CronId = new Guid("58E29999-4109-49F3-B34D-5A914096545C");
                cron.Cron = "0 0/5 * * * ?";
                cron.CronRemark = "test";

                //增
                db.T_YJCollectProgramMonitor_Cron.Add(cron);
                db.SaveChanges();

                //删 方法1
                db.Entry<T_YJCollectProgramMonitor_Cron>(cron).State = System.Data.Entity.EntityState.Deleted;

                //删 方法2
                //Attach的实体事先不能已经在内存中,否则上下文会追踪到两个相同键名的实体
                db.T_YJCollectProgramMonitor_Cron.Attach(cron);//将对象添加到EF管理容器中 ObjectStateManager
                db.T_YJCollectProgramMonitor_Cron.Remove(cron);//将对象包装类状态标识为删除
                db.Entry<T_YJCollectProgramMonitor_Cron>(cron).State = System.Data.Entity.EntityState.Deleted;

                //改
                cron.Cron = "0 0/10 * * * ?";
                cron.CronRemark = "修改测试";
                db.Entry<T_YJCollectProgramMonitor_Cron>(cron).State = System.Data.Entity.EntityState.Modified;

                //查
                //查询单个实体
                var user = db.T_YJCollectProgramMonitor_Cron.Find("58E29999-4109-49F3-B34D-5A914096545C");

                //查询所有实体
                var crons = db.T_YJCollectProgramMonitor_Cron;
                foreach (var c in crons)
                {
                    //ObjectDumper.Write(c);//打印实体
                }

                //备注：所有增删改操作都需要调用 db.SaveChanges() 方法，才能更新到数据库。
            }
        }
    }
}
