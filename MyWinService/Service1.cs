using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyWinService
{
    public partial class ScheduledWinService : ServiceBase
    {
        System.Timers.Timer _timer;
        TimeSpan startTime;

        public ScheduledWinService()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();

            startTime = TimeSpan.Parse("01:36:00");


        }

        protected override void OnStart(string[] args)
        {
            // For first time, set amount of seconds between current time and schedule time
            _timer.Enabled = true;
            _timer.Interval = GetNextInterval(startTime, DateTime.Now.TimeOfDay);
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
        }

        protected override void OnStop()
        {
        }
        protected void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Interval = GetNextInterval(startTime, DateTime.Now.TimeOfDay);
        }

        protected double GetNextInterval(TimeSpan startTime, TimeSpan timeOfDay)
        {
            TimeSpan res;
            if (startTime < timeOfDay)
            {
                res = startTime.Add(new TimeSpan(23, 59, 59)).Subtract(timeOfDay);
            }
            else
            {
                res = startTime.Subtract(timeOfDay);
            }
            return res.TotalMilliseconds;
        }
    }
}
