using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    //public enum pointRep { polar = 1, rect }  //point representation made redundant
    /// <summary>
    /// Factory Method Class
    /// </summary>
    public class Point
    {
        public double RadiusOrX { get; set; }
        public double AngleOrY { get; set; }

        //better method
        public Point() : this(0, 0) { }
        public Point(double rx, double ay)
        {
            this.RadiusOrX = rx;
            AngleOrY = ay;  //also correct
        }
        public static Point makePolar(double r,double a)
        {
            return new Point(r,a);
        }
        public static Point makeRect(double x,double y)
        {
            return new Point(Math.Sqrt(x * x + y * y), Math.Atan2(y, x));
        }

        //Older method
        //public Point() : this(0, 0, pointRep.polar) { }  //overloaded constructor
        //public Point(double x, double y) : this(x, y, (pointRep)1) { }  //another overloaded constructor with casted integer
        //public Point(double x, double y, pointRep p)  
        //{
        //    if (p == pointRep.polar)
        //    {
        //        Radius = x;
        //        Angle = y;  //the 'this' keyword is optional
        //    }
        //    else
        //    {
        //        Radius = Math.Sqrt(x * x + y * y);
        //        Angle = Math.Atan2(y, x);
        //    }
        //}
    }
}
