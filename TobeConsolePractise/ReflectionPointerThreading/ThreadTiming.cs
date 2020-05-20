using System;
using System.Threading;

namespace TobeConsolePractise
{
    public class ThreadTiming
    {
        static readonly object _object = new object();

        public static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadStart start = new ThreadStart(TestLock);
                new Thread(start).Start();
            }

            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
                Threads[i] = new Thread(new ThreadStart(PrintNumbers)) { Name = "Child " + i };

            foreach (Thread t in Threads)
                t.Start();
        }

        private static void PrintNumbers()
        {
            bool _lockTaken = false;

            Monitor.Enter(_object, ref _lockTaken);
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                if (_lockTaken)
                    Monitor.Exit(_object);
            }
        }

        private static void TestLock()
        {

            lock (_object)
            {
                Thread.Sleep(100);
                Console.WriteLine(Environment.TickCount);
            }
        }
    }
}