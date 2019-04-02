using System;
using CommonServiceLocator;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;

namespace TobeConsolePractise.QuartzJob
{
    class MyJobFactory : SimpleJobFactory
    {

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)ServiceLocator.Current.GetService(bundle.JobDetail.JobType);      //base.NewJob(bundle, scheduler);
        }
    }
}
