using System;
using TobeConsolePractise.ConsoleWeather;

namespace TobeConsolePractise
{
    class AsyncClient
    {
        public static void Run()
        {
            AsyncServiceSoapClient obj = new AsyncServiceSoapClient();
            AsyncServerClass obj2 = new AsyncServerClass();
            Console.ReadKey();
        }
    }
}
