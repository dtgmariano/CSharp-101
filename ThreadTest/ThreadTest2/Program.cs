using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.Start();
            t.Join();
            Console.Write("Thread t has ended!");
        }

        static void Go()
        {
            for (int i = 0; i < 1000; i++)
                Console.Write(System.DateTime.Now + " " + System.DateTime.Now.Millisecond + "\n");
        }
    }
}
