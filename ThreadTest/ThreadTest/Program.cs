using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> dt = new List<DateTime>();

            for (int i = 0; i < 100; i++)
            {
                dt.Add(DateTime.Now);
                Thread.Sleep(50);
                dt.Add(DateTime.Now);
                Thread.Sleep(50);
            }

            //List<TimeSpan> ts = new List<TimeSpan>();
            TimeSpan ts;
            List<int> intervals = new List<int>();
            
            for (int i = 0; i < dt.Count() - 1; i++)
            {
                ts = (dt[i + 1].TimeOfDay - dt[i].TimeOfDay);
                intervals.Add(ts.Milliseconds);
                Console.WriteLine(ts.Milliseconds + "\n");
            }

            List<int> distinct = intervals.Distinct().ToList();

            
            Console.WriteLine(intervals.Count() + " " + distinct.Count() + "\n");

        }
    }
}
