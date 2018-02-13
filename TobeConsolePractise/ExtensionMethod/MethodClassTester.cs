using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// To test MethodClass and Extensin Class
    /// </summary>
    class MethodClassTester
    {
        public static void run()
        {
            Console.WriteLine("This is a method testing extension classes on c#\r\n");
            MethodClass m = new MethodClass(); //using 3 and 4
            Console.Write("Enter the first integer property: ");
            double a;
            while (!double.TryParse(Console.ReadLine(), out a)) Console.Write("Please enter a valid number: ");
            m.A = a;
            Console.Write("Enter the second integer property: ");
            double b;
            while (!double.TryParse(Console.ReadLine(), out b)) Console.Write("Please enter a valid number: ");
            m.B = b;
            Console.Write("Enter the declared integer property: ");
            double c;
            while (!double.TryParse(Console.ReadLine(), out c)) Console.Write("Please enter a valid number: ");
            Console.WriteLine();
            Console.WriteLine("The first integer property is: " + m.A + ".");
            Console.WriteLine("The second integer property is: " + m.B + ".");
            Console.WriteLine("The declared integer property is: " + c + ".");
            Console.WriteLine("\r\nTheir sum is: " + m.extSum(c));   //using the static extension method in the m MethodClass instance
            Console.ReadKey();
        }
    }
}
