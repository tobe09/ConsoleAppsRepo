using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace TobeConsolePractise
{
    public class Reflect
    {
        private static int a = 5,
            b = 10,
            c = 15;
        public static void run()
        {
            Console.WriteLine("Reflection in C#\r\n");
            Console.WriteLine("The sum of a(5), b(10) and c(15) is: " + (a + b + c));
            Type type = typeof(Reflect);
            Console.Write("Enter the variable whose value you wish to change: ");
            string varName=Console.ReadLine();
            FieldInfo field;
            if (varName == "a" || varName == "b" || varName == "c")
            {
                field = type.GetField(varName, BindingFlags.NonPublic|BindingFlags.Static);
                Console.Write("Enter the new value of " + field.Name + ": ");
                string newStr = Console.ReadLine();
                int newVal;
                while (!int.TryParse(newStr, out newVal))
                {
                    Console.WriteLine("Please enter an integer: ");
                    newStr = Console.ReadLine();
                }
                field.SetValue(null, newVal);
                Console.WriteLine("The new value of " + field.Name + " is: " + field.GetValue(null));
                Console.WriteLine("The new sum of a, b and c is: " + (a + b + c) + "\n\nTHE END");
            }
            else
            {
                Console.WriteLine("Wrong variable name specified.\n\nTHE END");
            }
            Console.ReadKey();
        }
    }
}
