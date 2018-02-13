using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Looping
    {
        public static void run()
        {
            //Testing loops and string conversion with parse
            string loop = "y";
            while (loop != "n" && loop != "N" && loop != "exit")
            {
                Console.WriteLine("This is just a method loop to test integer parsing (doesn't do much)");
                Console.Write("Test number: ");
                string temp = Console.ReadLine();
                int a;
                while (!int.TryParse(temp, out a))
                {
                    Console.Write("Please enter a correct number: ");
                    temp = Console.ReadLine();
                }
                if (a == 1) Console.WriteLine("Value is 1, ie: " + a);
                else if (a == 2) Console.WriteLine("Value is 2, ie: " + a);
                else if (a == 3) Console.WriteLine("Value is 3, ie: " + a);
                else if (a == 4) Console.WriteLine("Value is 4, ie: " + a);
                else if (a == 5) Console.WriteLine("Value is 5, ie: " + a);
                else Console.WriteLine("Value is shown, ie: " + a);
                Console.WriteLine();
                Console.Write("Do you wish to continue (Enter 'y' or 'n'): ");
                loop = Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
