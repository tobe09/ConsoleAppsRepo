using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// To test integer and byte default values as well as overflow
    /// </summary>
    class DefaultValues
    {
        private int a { get; set; }  //defaults to 0
        private byte b { get; set; }  //defaults to 0
        private string c { get; set; }  //defaults to "" or null
        
        public static void run()  //'this' keyword is invalid in a static context
        {
            DefaultValues i = new DefaultValues();
            Console.WriteLine("The int is: {0}, the byte is: {1} and {{the sring is: {2}", i.a, i.b, i.c); // {{ escapes curly brace
            Console.ReadKey();
        }
    }
}
