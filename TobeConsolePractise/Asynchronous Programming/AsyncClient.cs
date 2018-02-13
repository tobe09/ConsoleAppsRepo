using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Services;
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
