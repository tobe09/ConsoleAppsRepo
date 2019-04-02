using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Quartz;

namespace TobeConsolePractise.QuartzJob
{
    class MyMailJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ////From Address  
            string FromAddress = "chineketobenna@gmail.com";
            string FromAdressTitle = "Email from app";
            //To Address  
            string ToAddress = "chineketobenna@gmail.com";
            //string ToAdressTitle = "Microsoft ASP.NET Core";
            string Subject = "Hello World - Sending email using ASP.NET Core 1.1";
            string BodyContent = "ASP.NET Core was previously called ASP.NET 5. It was renamed in January 2016. It supports cross-platform frameworks ( Windows, Linux, Mac ) " +
                                 "for building modern cloud-based internet-connected applications like IOT, web apps, and mobile back-end.";

            //Smtp Server  
            string SmtpServer = "smtp.gmail.com";
            //Smtp Port Number  
            int SmtpPortNumber = 587;

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
            mimeMessage.To.Add(new MailboxAddress(ToAddress));
            mimeMessage.Subject = Subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = BodyContent
            };

            return Task.Factory.StartNew(() =>
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPortNumber, false);

                    // Note: only needed if the SMTP server requires authentication  
                    // Error 5.5.1 Authentication   
                    client.Authenticate("philipbradley09@gmail.com", "philipfiverr");
                    client.Send(mimeMessage);
                    Console.WriteLine("EMail sent");
                    client.Disconnect(true);
                }
            });
        }
    }
}
