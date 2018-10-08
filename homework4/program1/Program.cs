using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace program1
{
    public class ClockEventArgs : EventArgs { }
    public delegate void ClockEventHandler(object sender, ClockEventArgs e);
    public class Clock
    {
        public event ClockEventHandler Clocking;
        public void DoClock()
        {
            if (Clocking != null)
            {
                ClockEventArgs args = new ClockEventArgs();
                Clocking(this, args);//发生一次事件，即通知外界
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入闹钟时间(整数)  小时 分钟");
            string r = Console.ReadLine();
            Boolean ok = true;
            List<int> a = new List<int>();
            do
            {
                try
                {
                    a = new List<string>(r.Split()).ConvertAll<int>(i => int.Parse(i));
                    while (a[0] > 24 || a[0] < 0 || a[1] > 24 || a[1] < 0)
                    {
                        Console.WriteLine("输入不合理，请重新输入：");
                        r = Console.ReadLine();
                        a = new List<string>(r.Split()).ConvertAll<int>(i => int.Parse(i));
                    }
                }
                catch (Exception e)
                {
                    ok = false;
                    Console.WriteLine("输入不合理，请重新输入：");
                    r = Console.ReadLine();                }
            } while (ok =!ok);//每次如果catch到错误ok = false并在while里反转ok同时以！ok为判断值
            string s = a[0] + ":" + a[1];


            var clock = new Clock();//注册一个闹钟
            string now_t = DateTime.Now.ToShortTimeString().ToString();
            Console.WriteLine("现在是：" + now_t);
            while (now_t != s)
            {
                Thread.Sleep(6000);//每一分钟求一次当前时间
                now_t = DateTime.Now.ToShortTimeString().ToString();
                Console.WriteLine("现在是：" + now_t);
            }
            clock.Clocking += Ring;
            clock.DoClock();
        }
        static void Ring(object sender, ClockEventArgs e)
        {
            Console.WriteLine("it's time to get up");
        }
    }
}
