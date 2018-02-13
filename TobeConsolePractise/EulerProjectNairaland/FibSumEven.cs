using System;
using System.Diagnostics;

namespace TobeConsolePractise
{
    class FibSumEven
    {
        public string EvenSum(int end) 
        {
            int evenSum = 0;
            int count = 0;
            int previous;
            int next = 1;
            int present = 1;

            while (present <= end)
            {
                previous = present;
                present = next;
                next = present + previous;
                if (present % 2 == 0) evenSum += present;
                count++;
            }

            return evenSum + "," + count;
        }

        public static void Run(int end=4000000)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            string values = new FibSumEven().EvenSum(end);
            double time = stopWatch.Elapsed.TotalMilliseconds;
            string[] sumAndCount = values.Split(',');
            Console.WriteLine("The sum of even fibonacci values less than " + end + " is: " + sumAndCount[0]);
            Console.WriteLine("The number of iterations taken is: " + sumAndCount[1]);
            Console.WriteLine("Time taken: " + time + " milliseconds");
            Console.ReadKey();
        }
    }
}
