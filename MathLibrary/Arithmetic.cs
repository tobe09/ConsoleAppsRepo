using System;

/// <summary>
/// Library for performing mathematical calculations (xml comments for namespace not automatically generated or used)
/// </summary>
namespace MathLibrary
{
    /// <summary>
    ///Holds methods for performing basic arithmetic operations
    /// </summary>
    public class Arithmetic
    {
        /// <summary>
        ///Holds methods for performing basic arithmetic operations (constructor)
        /// </summary>
        public Arithmetic()
        {

        }

        /// <summary>
        /// A method to add two numbers
        /// </summary>
        /// <param name="a">The first parameter</param>
        /// <param name="b">The second parameter</param>
        /// <returns>double</returns>
        /// <exception cref = "IndexOutOfRangeException" ></exception >
        /// <exception cref="FormatException"></exception>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// A method to substract two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>double</returns>
        public double Substract(double a, double b)
        {
            return _Substract(a, b);
        }

        /// <summary>
        /// A method to return the difference between two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>double</returns>
        public double Difference(double a, double b)
        {
            return Math.Abs(_Substract(a, b));
        }

        /// <summary>
        /// Generates the absolute value of a number
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static double MathAbs(double a)
        {
            return OuterClass.MathAbsolute(a);
        }

        private double _Substract(double a, double b)
        {
            return a - b;
        }
    }

    class OuterClass
    {
        internal static double MathAbsolute(double a)
        {
            return Math.Abs(a);
        }
    }
}