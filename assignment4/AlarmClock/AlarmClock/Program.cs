using System;
using System.Timers;

namespace AlarmClock
{
    public class Program
    {
        public static void Main()
        {
            // 设置闹钟在5秒后响铃
            var alarmTime = DateTime.Now.AddSeconds(5);
            var clock = new AlarmClock(alarmTime);

            // 订阅嘀嗒事件
            clock.Tick += (sender, e) =>
            {
                Console.WriteLine($"【嘀嗒】当前时间: {DateTime.Now:HH:mm:ss}");
            };

            // 订阅响铃事件
            clock.Alarm += (sender, e) =>
            {
                Console.WriteLine("【响铃】叮铃铃！该起床啦！");
            };

            Console.WriteLine($"闹钟已设置，将在 {alarmTime:HH:mm:ss} 响铃");
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();

            Console.WriteLine();
        }
    }
}
