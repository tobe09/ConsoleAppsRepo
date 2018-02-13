using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public static class PointExtension
    {
        public static double distanceBetween(this Point p1,Point p2)  //using 'this' in an external method
        {
            double a = Math.Pow(p1.RadiusOrX - p2.RadiusOrX, 2);
            double b = Math.Pow(p1.AngleOrY - p2.AngleOrY, 2);
            return Math.Sqrt(a + b);
        }
    }
}
