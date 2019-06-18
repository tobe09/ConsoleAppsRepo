using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;

namespace TobeConsolePractise.EMail
{
    class TestSmtpMailServer
    {
        public static void Run()
        {
            CheckSmtpMailServer();
        }

        private static void CheckSmtpMailServer()
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

        private static void HostInformation()
        {
            try
            {
                // IP Address resolution to Host Name
                IPHostEntry ip = Dns.GetHostEntry("31.13.90.36");  //("110.000.073.011");
                string hostName = ip.HostName;
                Console.WriteLine("Host Name: " + hostName + "\n");

                // Host Name resolution to IP Address
                IPHostEntry host = Dns.GetHostEntry("facebook.com");
                IPAddress[] ipaddr = host.AddressList;
                Console.WriteLine("Number of Addresses: " + ipaddr.Length + "\n");
                foreach (IPAddress addr in ipaddr)
                    Console.WriteLine(addr);
            }
            // Catch unknown host names
            catch (SocketException ex)
            {
                Console.WriteLine("Socket Error: " + ex.Message + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message + "\n");
            }
        }
    }
}