using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefereeConsoleApp
{
    public class CsProgram
    {
        public static void Main(string[] args)
        {
            //will be referenced
            Console.WriteLine("The referee's name is: " + new CsProgram().ToString());
            Console.WriteLine("Parameter passed is: " + args[0]);
            Console.ReadKey();
        }
    }
}
