using System;
using System.Threading.Tasks;

namespace TobeConsolePractise.Scheduling
{
    public class Job
    {
        private long count = 0;

        public async void Run()
        {
            Console.WriteLine("Initial: "+count);
            var task = TestTask();
            Console.WriteLine("Start1: " + count);
            Console.WriteLine("Start2: " + count);
            var awaiter = task.GetAwaiter();
            Console.WriteLine("After awaiter gotten: " + count);
            awaiter.GetResult();
            Console.WriteLine("After result gotten: " + count);
            await task;
            Console.WriteLine("After await: " + count);
        }

        Task TestTask()
        {
            return Task.Factory.StartNew(() => {
                for(long i = 0; i < 1000000000; i++)
                {
                    count = i;
                }
            });
        }
    }
}
