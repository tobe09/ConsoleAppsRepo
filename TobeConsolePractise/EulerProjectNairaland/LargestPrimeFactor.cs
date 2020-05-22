using System;
using System.Diagnostics;

namespace TobeConsolePractise
{
    class LargestPrimeFactor
    {
        public long LargestPrime(long no)
        {
            if (IsPrime(no))
                return no;

            long largest = 1;

            long end = (long)Math.Sqrt(no);
            for (long value = 2; value <= end; value++)
            {
                if (no % value == 0)
                {
                    if (IsPrime(value) && value > largest)
                        largest = value;

                    long result = no / value;
                    if (IsPrime(result))
                        return result;
                }
            }

            return largest;
        }

        private bool IsPrime(long no)
        {
            long root = (long)Math.Sqrt(no);
            for (int i = 2; i < root; i++)
            {
                if (no % i == 0)
                    return false;
            }

            return true;
        }

        public static void Run(long no = 600851475143)
        {
            //no = 2 * 3 * 6 * 9 * 23 * 17 * 29 * 62;
            Stopwatch stopWatch = Stopwatch.StartNew();
            long largestPrime = new LargestPrimeFactor().LargestPrime(no);
            double time = stopWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("The largest prime factor of " + no + " is: " + largestPrime);
            Console.WriteLine("Time taken: " + time + " milliseconds");
        }
    }
}