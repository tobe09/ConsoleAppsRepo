using System;
using MathLibrary;      //project target framework must be the same or greater than imported dependencies

namespace TobeConsolePractise
{
    class TestMathLibrary
    {
        public static void Run()
        {
            var arith = new Arithmetic();
            double a = 5;
            double b = 15;
            double sum = arith.Add(a, b);
            double sub = arith.Substract(a, b);
            double diff = arith.Difference(a, b);
            Console.WriteLine("Numbers: {0} and {1}\r\n", a, b);
            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Substraction: " + sub);
            Console.WriteLine("Difference: " + diff);
            Console.WriteLine("Absolute value of -3: " + Arithmetic.MathAbs(-3));
        }
    }
}
