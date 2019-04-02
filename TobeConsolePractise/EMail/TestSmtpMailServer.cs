using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;

namespace TobeConsolePractise.EMail
{
    class TestSmtpMailServer
    {
        public static void Run()
        {
            using (var client = new TcpClient())
            {
                var server = "10.0.73.11"; //"smtp.gmail.com";
                var port = 25;  //465;
                client.Connect(server, port);
                // As GMail requires SSL we should use SslStream
                // If your SMTP server doesn't support SSL you can
                // work directly with the underlying stream
                using (var stream = client.GetStream())
                using (var sslStream = new SslStream(stream))
                {
                    sslStream.AuthenticateAsClient(server);
                    using (var writer = new StreamWriter(sslStream))
                    using (var reader = new StreamReader(sslStream))
                    {
                        writer.WriteLine("EHLO " + server);
                        writer.Flush();
                        Console.WriteLine(reader.ReadLine());
                        // GMail responds with: 220 mx.google.com ESMTP
                    }
                }
            }
        }
    }
}
