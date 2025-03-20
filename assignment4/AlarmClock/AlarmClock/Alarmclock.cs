using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AlarmClock
{
    public class AlarmClock
    {
        private readonly System.Timers.Timer _timer;
        private DateTime _alarmTime;
        private bool _alarmTriggered;

        public event EventHandler Tick;
        public event EventHandler Alarm;

        public AlarmClock(DateTime alarmTime)
        {
            _alarmTime = alarmTime;
            _timer = new System.Timers.Timer(1000); // 1秒间隔
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // 检查是否到达设定时间
            // 若还没到，那么tick即可
            // 如果超过了，就一直响直到用户回应
            if (DateTime.Now >= _alarmTime)
            {
                Alarm?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Tick?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}