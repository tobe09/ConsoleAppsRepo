using System;
using System.Threading.Tasks;
using Quartz;

namespace TobeConsolePractise.QuartzJob
{
    class MyJob : IJob
    {
        private static int count = 1;

        public Task Execute(IJobExecutionContext context)
        {
            var jdm = context.JobDetail.JobDataMap;
            string name = jdm.GetString("name");

            var jobDetailName = context.JobDetail.Key.Name;

            var triggerName = context.Trigger.Key.Name;

            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Iteration " + count);
                Console.WriteLine(jobDetailName);
                Console.WriteLine(triggerName);
                Console.WriteLine(name);
                Console.WriteLine();
                count++;
            });
        }
    }

}
