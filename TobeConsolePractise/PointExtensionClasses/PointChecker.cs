using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public class PointChecker
    {
        public static Point createPoint(string prompt)
        {
            Console.WriteLine("\r\n" + prompt);
            Console.Write("Horizontal Length: ");
            double x;
            if (!double.TryParse(Console.ReadLine(), out x)) { Console.Write("Please enter a valid floating point number (x): "); }
            Console.Write("Vertical Length: ");
            double y;
            if (!double.TryParse(Console.ReadLine(), out y)) { Console.Write("Please enter a valid floating point number (y): "); }
            return Point.makeRect(x, y);
        }
    }
}
