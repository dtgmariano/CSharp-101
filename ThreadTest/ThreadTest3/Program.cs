using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> dt = new List<DateTime>();

            for (int i = 0; i < 1000; i++)
            {
                dt.Add(DateTime.Now);
                Thread.Sleep(50);
            }

            //List<TimeSpan> ts = new List<TimeSpan>();
            TimeSpan ts;
            List<int> intervals = new List<int>();

            for (int i = 0; i < dt.Count()-1; i++)
            {
                ts = (dt[i + 1].TimeOfDay - dt[i].TimeOfDay);
                intervals.Add(ts.Milliseconds);
            }

            List<int> distinct = intervals.Distinct().ToList();

            Console.WriteLine(intervals.Count() + " " + distinct.Count() + "\n");
            
        }

        static void Go()
        {
            for (int i = 0; i < 1000; i++)
                Console.Write(System.DateTime.Now + " " + System.DateTime.Now.Millisecond + "\n");
        }
    }
}