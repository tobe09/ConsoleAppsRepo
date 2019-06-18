using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Quartz.Spi;
using System;
using TobeConsolePractise.QuartzJob;

namespace TobeConsolePractise
{
    /// <summary>
    /// Main console app
    /// </summary>
    /// <param name="args"></param>
    /// <devdoc>Really cool, aint it</devdoc>
    class Program
    {
        public static void Main(string[] args)
        {
            using (var scope = Container)
            {
                scope.Resolve<Application>().Run();
                Console.ReadKey();
            }
        }

        private static IContainer _container;
        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = GetContainer();
                    ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(_container));
                }

                return _container;
            }
        }

        //tobenna 1

        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConcreteHold>().As<Hold>();
            builder.RegisterType<MyJob>().AsSelf();
            builder.RegisterType<MyMailJob>().AsSelf();
            builder.RegisterType<MyJobFactory>().As<IJobFactory>();
            builder.RegisterType<MyScheduler>().AsSelf();

            builder.RegisterType<Application>().AsSelf();

            return builder.Build();
        }

        //tobenna 2
    }

    class Application
    {
        private IComponentContext context;

        public Application(IComponentContext context)
        {
            this.context = context;
        }

        public void Run()
        {
            //MergeSort.Run();
            //ShellSort.Run();
            //BetweenTwoSets.Run();
            //BreakingRecords.Run();
            //NodeTest.Run();
            //TaskTest.Run();    
            //BalancedBrackets.Run();
            //MaxTriangles.Run();
            //LargestPrimeFactor.Run();
            //IntPtrReverse.Run();
            //ThreadTest.Run();  
            //StackCheck.Run();
            //TestMathLibrary.Run();
            //GenericsTest.Run();
            ////LinqToSql.Run();
            //DiPractise.Run();
            //AddShift.Run();
            //Serialization.DtoSerialize.Run();
            //Join.Run();
            //Cousant.EncryptDecrypt.Run();
            //Mapping_EF.PractiseEf.Run();
            //new Mapping_EF.TestService().UpdateStudent_Did_Update();
            //WebServices.IntegrationJavaSoap.Run();
            //DataStructures.SinglyLinkedList.Run();
            //new Scheduling.Job().Run(); 
            //TaskTest.Run().Wait();
            //context.Resolve<MyScheduler>().Run().Wait();
            //HoneyPot.Challenges.Run();
            //EMail.TestSmtpMailServer.Run();   lstIP.Items.Clear();
        }
    }
}