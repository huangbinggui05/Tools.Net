using HBG.Utils.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace HBG.Utils
{
    //事件处理程序的委托
    public delegate bool MyEventHandler();
    public class MyTimer
    {
        public event MyEventHandler MyElapsed; //声明事件

        private string timerName = string.Empty;

        public void OnInterval(object obj, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["TimerNames"]!=null)
            {
                //记录设定任务的定时器触发日志
                string timerNames = ConfigurationManager.AppSettings["TimerNames"];
                if ( !string.IsNullOrEmpty(timerName) && timerNames.Contains(timerName))
                {
                    LogHelper.GetInstance().WriteLog(string.Format("启动【{0}】任务", timerName));
                }
            }
            else
            {
                //记录所有定时器触发日志
                LogHelper.GetInstance().WriteLog(string.Format("启动【{0}】任务", timerName));
            }
            
            if (MyElapsed != null) MyElapsed();
        }

        //私有计时器
        private System.Timers.Timer MyPrivateTimer;

        public MyTimer(int intervalSec,string timerName)//构造函数
        {
            this.timerName = timerName;
            MyPrivateTimer = new System.Timers.Timer();//创建私有计时器

            //将上面的OnInterval设置成了类计时器的Elapsed事件的事件处理程序
            MyPrivateTimer.Elapsed += OnInterval;//附加事件处理程序
            MyPrivateTimer.Interval = intervalSec*1000;
            MyPrivateTimer.Enabled = true;
        }
    }
}
