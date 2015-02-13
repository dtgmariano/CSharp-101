namespace Thread_103
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(sw.Elapsed);
                Thread.Sleep(100);
            }

            sw.Stop();

        }
    }
}
