using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class BoundsTester
    {
        public static void run()
        {
            try
            {
                Console.Write("Enter the first number: ");
                byte a = byte.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                byte b = byte.Parse(Console.ReadLine());
                Console.WriteLine("\r\nTheir sum is: " + (a + b));
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nError: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
