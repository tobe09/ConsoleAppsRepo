using System;

namespace TobeConsolePractise
{
    /// <summary>
    /// Using static methods to execute delegates
    /// </summary>
    class BasicDelegate
    {
        public delegate double NumericFunction(double d);  //a declared delegate with a specific signature
        //NumericFunction nf;  //declared but not used here due to static nature of context

        public static double cubic(double num) { return num * num * num; }  //a function with a signature of the declared delegate

        public static double twice(double num) { return num * 2; }  //another function with a signature of the declared delegate

        public static void printTableOfFunctions(NumericFunction f, string fName)  //declaring a function as a parameter
        {
            Console.WriteLine("Function to be executed: " + fName + "\r\n");
            Console.Write("Enter the start point: ");
            double from=double.Parse(Console.ReadLine());
            Console.Write("Enter the end point: ");
            double to=double.Parse(Console.ReadLine());
            Console.Write("Enter the granularity(step): ");
            double step=double.Parse(Console.ReadLine());
            for (double d = from; d <= to; d += step) { Console.WriteLine("{0, 10}({1, -4: F3}) = {2}", fName, d, f(d)); }
            Console.WriteLine("\r\n");
        }

        public static NumericFunction Compose(NumericFunction f, NumericFunction g)  //returns a method with a numeric function signature
        {
            return num => { return f(g(num)); };  //simplified lambda expression
        }
        /// <summary>
        /// To execute the BasicDelegate class statements
        /// </summary>
        public static void run()
        {
            printTableOfFunctions(Math.Log, "NaturalLog");    //passing a function as a parameter
            printTableOfFunctions(cubic, "Cube");   //passing the created function as a parameter
            printTableOfFunctions((double num) => { return Math.Sqrt(num); }, "Sqrt");  //basic lambda function notation (anonymous methods)
            printTableOfFunctions(num => num * num, "Square");  //simplified lambda expression
            printTableOfFunctions(Compose(cubic, twice), "CubeOfTwice");  //using the 'Compose' NumericFunction
            printTableOfFunctions(Compose(Math.Log, num => { return Math.Pow(Math.E, num); }), "LogAntilog");  //gives the same number
            Console.ReadKey();
        }
    }
}
