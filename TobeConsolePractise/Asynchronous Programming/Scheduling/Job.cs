using System;
using System.Threading;
using System.Threading.Tasks;

namespace TobeConsolePractise.Scheduling
{
    public class Job
    {
        private static long count = 0;

        public static async void Run()
        {
            Console.WriteLine("Initial: " + count);
            var task = TestTask();

            Console.WriteLine("Start1: " + count);
            Thread.Sleep(400);

            Console.WriteLine("Start2: " + count);
            Thread.Sleep(100);

            var awaiter = task.GetAwaiter();
            Console.WriteLine("After awaiter gotten: " + count);
            Thread.Sleep(100);

            awaiter.GetResult();
            Console.WriteLine("After result gotten: " + count);
            Thread.Sleep(100);

            await task;
            Console.WriteLine("After await: " + count);
        }

        static Task TestTask()
        {
            return Task.Factory.StartNew(() =>
            {
                for (long i = 0; i < 1000000000; i++)
                {
                    count = i;
                }
            });
        }
    }
}