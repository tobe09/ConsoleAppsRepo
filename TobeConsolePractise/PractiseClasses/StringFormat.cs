using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TobeConsolePractise
{
    class StringFormat
    {
        public static void run()
        {
            double d = 1234567.8901;
            Console.WriteLine("Number: " + d);
            Console.WriteLine("Alignment: 5,\tFormat Code: F2,\tFormatted value: {0 ,5 :f2}", d); //no space between colon and format code
            Console.WriteLine("Alignment: 20.\tFormat Code: N2.\tFormatted value: {0, 20 :N3}", d);  
            Console.WriteLine("Alignment: -15.\tFormat Code: N3.\tFormatted value: {0, -15 :n2}", d);  //format code is not case sensitive
            Console.WriteLine("{0,37}\r\nAlignment gives the number of spaces and its sign gives the orientation.", "NOTE");
            Console.WriteLine("Positive means right justified and vice versa.");
            Console.WriteLine("Format code denotes its display and approximation.");
            Console.WriteLine("F2 or f2 means floating point number approximated to two decimal places, etc.");
            //N vs F

            string s = "Y";
            while (s.ToUpper() == "Y" || s.ToUpper()=="YES")
            {
                try
                {
                    string hold;
                    Console.WriteLine("\r\n\r\nEnter your own number, alignment and format.\r\n");
                    Console.Write("Enter your number: ");
                    double num;
                    hold = Console.ReadLine();
                    while (!double.TryParse(hold, out num))
                    {
                        Console.WriteLine("Please enter a valid real number!");
                        Console.Write("(or enter 'd' to use a default value, or enter 'exit' to exit): ");
                        hold = Console.ReadLine();
                        if (hold.ToUpper() == "D") { hold = "1234567.8901"; break; }
                        if (hold.ToUpper() == "EXIT") break;
                    }
                    if (hold.ToUpper() == "EXIT") break;
                    num = double.Parse(hold);

                    Console.Write("Enter your alignment integer: ");
                    int al;
                    hold = Console.ReadLine();
                    while (!int.TryParse(hold, out al))
                    {
                        Console.WriteLine("Please enter a valid integer!");
                        Console.Write("(or enter 'd' to use a default value, or enter 'exit' to exit): ");
                        hold = Console.ReadLine();
                        if (hold.ToUpper() == "D") { hold = "0"; break; }
                        if (hold.ToUpper() == "EXIT") break;
                    }
                    if (hold.ToUpper() == "EXIT") break;
                    al = int.Parse(hold);

                    Console.Write("Enter your format code: ");
                    string format;
                    hold = Console.ReadLine();
                    while (!Regex.IsMatch(hold, "^(c|C|d|D|e|E|f|F|g|G|n|N|p|P|r|R|x|X)(\\d)?$"))
                    {
                        Console.WriteLine("Please enter a correct format code!");
                        Console.Write("(or enter 'def' to use a default value, or enter 'exit' to exit): ");
                        hold = Console.ReadLine();
                        if (hold.ToUpper() == "DEF") { hold = "N"; break; }
                        if (hold.ToUpper() == "EXIT") break;

                    }
                    if (hold.ToUpper() == "EXIT") break;
                    format = hold;

                    Console.WriteLine("\r\nNumber Entered: " + num);
                    Console.Write("Alignment: " + al + "\tFormat Code: " + format);
                    if (Regex.IsMatch(format, "^(x|X)(\\d)?$"))
                        Console.WriteLine("\r\nFormatted value (integer to hexadeximal): " + "{0," + al + ":" + format + "}", (int)num);
                    else if (Regex.IsMatch(format, "^(d|D)(\\d)?$"))
                        Console.WriteLine("\r\nFormatted value (integer only): " + "{0," + al + ":" + format + "}", (int)num); 

                    else Console.WriteLine("\r\nFormatted value: " + "{0," + al + ":" + format + "}", num);     //actual formatting
                }

                catch (Exception ex) { Console.WriteLine("\r\nError: " + ex.Message); }

                Console.Write("\r\nDo you wish to continue? Enter 'y' or 'yes' to continue:");
                s = Console.ReadLine();
            }

            Console.Write("\r\nTHE END.\nPress any key to exit:");
            Console.ReadKey();
        }

    }
}
