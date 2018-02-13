using System;
using System.Diagnostics;

namespace TobeConsolePractise
{
    class SumOfMult
    {
        public int ThreeFive(int end)
        {
            int sum = 0;

            for (int i = 0; i < end; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }

            return sum;
        }

        public static void Run(int end = 1000)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int sum = new SumOfMult().ThreeFive(end);
            double time = stopWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("The sum of integer multiples of 3 or 5 between 1 and " + end + " is: " + sum);
            Console.WriteLine("Time taken: " + time + " milliseconds");
            Console.ReadKey();
        }
    }
}
