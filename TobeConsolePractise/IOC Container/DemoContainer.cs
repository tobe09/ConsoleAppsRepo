using System;
using System.Collections.Generic;

namespace TobeConsolePractise.IOC_Container
{
    class DemoContainer
    {
        public static void Run()
        {
            DemoContainer container = new DemoContainer();
            //registering dependecies
            container.Register<IRepository>(delegate
            {
                return new NHibernateRepository();
            });
            container.Configuration["email.sender.port"] = 1234;
            container.Register<IEmailSender>(delegate
            {
                return new SmtpEmailSender(container.GetConfiguration<int>("email.sender.port"));
            });
            //container.Register<IEmailSender>(delegate
            //{
            //    return new NHibernateRepository();
            //});
            container.Register<LoginController>(delegate
            {
                return new LoginController(
                    container.Create<IRepository>(),
                    container.Create<IEmailSender>());
            });

            //using the container
            Console.WriteLine("Created conroller email port: " + container.Create<LoginController>().EmailSender.Port);
        }

        public delegate object Creator(DemoContainer container);
        private readonly Dictionary<Type, Creator> typeToCreator = new Dictionary<Type, Creator>();

        public Dictionary<string, object> Configuration { get; private set; } = new Dictionary<string, object>();

        public void Register<T>(Creator creator)
        {
            if (!(creator(this) is T)) throw new Exception("Wrong interface implementation");     //not necessary
            typeToCreator.Add(typeof(T), creator);
        }

        public T Create<T>()
        {
            return (T)typeToCreator[typeof(T)](this);
        }

        public T GetConfiguration<T>(string name)
        {
            return (T)Configuration[name];
        }


        interface IRepository { bool Save(); }
        class NHibernateRepository : IRepository { public bool Save() => true; }

        interface IEmailSender { int Port { get; set; } }
        class SmtpEmailSender : IEmailSender { public SmtpEmailSender(int port) { } public int Port { get; set; } = 5; }

        class LoginController
        {
            public IEmailSender EmailSender { get; set; }
            public LoginController(IRepository repo, IEmailSender sender)
            {
                EmailSender = sender;
            }
        }
    }
}
