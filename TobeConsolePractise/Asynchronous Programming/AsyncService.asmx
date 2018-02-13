<%@ WebService Language="C#" Class="TobeConsolePractise.AsyncService"%>

using System;
using System.Web.Services;

namespace TobeConsolePractise
{
    [WebService(Description="Asynchronous Service")]
    public class AsyncService
    {
        public enum Choice
        {
            Abia = 1,
            Abuja,
            Anambra,
            Lagos
        }

        [WebService]
        public class TrialClass
        {
            [WebMethod(Description = "Trial Method")]
            public int TrialMethod() { return 1; }
        }
        
        [WebMethod(Description="Get Weather Information")]
        public string GetWeather(Choice ch, Time t)
        {
            System.Threading.Thread.Sleep((int)t * 1000);
            string weather;
            switch (ch)
            {
                case Choice.Abia:
                    weather = "Abia= 10 degrees";
                    break;
                case Choice.Abuja:
                    weather = "Abuja= 20 degrees";
                    break;
                case Choice.Anambra:
                    weather = "Anambra= 30 degrees";
                    break;
                case Choice.Lagos:
                    weather = "Lagos= 40 degrees";
                    break;
                default:
                    weather = "Unknown degrees";
                    break;
            }
            return weather;
        }

        [WebMethod(Description = "Add Numbers with a Delay")]
        public int Add(int a, int b, int delayInSecs)
        {
            System.Threading.Thread.Sleep(delayInSecs * 1000);
            return a + b;
        }
    }

    public enum Time
    {
        Two = 2,
        Four = 4,
        Six = 6,
        Eight = 8,
        Ten = 10
    }

}
