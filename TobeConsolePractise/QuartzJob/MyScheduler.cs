using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace TobeConsolePractise.QuartzJob
{
    class MyScheduler
    {
        private IJobFactory jobFactory;

        public MyScheduler(IJobFactory jobFactory)
        {
            this.jobFactory = jobFactory;
        }

        public async Task Run()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();

            IScheduler scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = jobFactory;
            await scheduler.Start();

            foreach (int id in new int[] { 1, 2 })
            {
                JobDataMap jobDataMap = new JobDataMap { new KeyValuePair<string, object>("name", "Tobenna" + id) };

                IJobDetail jobDetail = JobBuilder.Create<MyJob>()
                                        .UsingJobData(jobDataMap)
                                        .WithIdentity("Job Detail Id: " + (id + 2))
                                        .Build(); 

                 ITrigger trigger = TriggerBuilder.Create()
                                        .WithIdentity("Trigger Id: " + (id + 4))
                                        .StartAt(DateTime.Now.AddSeconds(id * 2))
                                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).WithRepeatCount(2))
                                        .Build();

                await scheduler.ScheduleJob(jobDetail, trigger);
            }

            //await scheduler.ScheduleJob(
            //    JobBuilder.Create<MyMailJob>().Build(),
            //    TriggerBuilder.Create().StartAt(DateTime.Now).Build()
            //    );
        }
    }
}
