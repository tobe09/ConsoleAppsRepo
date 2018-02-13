using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class PointCheckerTester
    {
        public static void run()
        {
            Point p1 = PointChecker.createPoint("Enter the first x and y dimensions");
            Console.WriteLine("Distance and angle respectively are: " + p1.RadiusOrX + " and " + p1.AngleOrY + ".");
            Point p2 = PointChecker.createPoint("Enter the second x and y dimensions");
            Console.WriteLine("Distance and angle respectively are: " + p2.RadiusOrX + " and " + p2.AngleOrY + ".");
            double p1p2Dist = p1.distanceBetween(p2);
            Console.WriteLine("\r\n\r\nThe distance between both points is: " + p1p2Dist);
            Console.ReadKey();
            //Program.Main(new string[0]); new instance of main method, very dangerous
        }
    }
}
