using System;
using System.Diagnostics;

namespace TobeConsolePractise
{
    class LargestPrimeFactor
    {
        public long LargestPrime(long no)
        {
            long largest = 1;

            long end = no / 2;    //(long)Math.Sqrt(no);
            //check if values less than half of the number is a factor
            for (long innerLoop = 2; innerLoop <= end; innerLoop++)
            {
                if (no % innerLoop == 0)
                {
                    long rootInnerLoop = (long)Math.Sqrt(innerLoop);
                    //check if innerLoop value is prime
                    int primeCountInnerLoop = 0;
                    for (int outerLoop = 2; outerLoop <= rootInnerLoop; outerLoop++)
                    {
                        if (innerLoop % outerLoop == 0) primeCountInnerLoop++;  //if it is not prime, the count value will be greater than zero
                    }

                    if (primeCountInnerLoop == 0 && innerLoop > largest) largest = innerLoop;
                    end = no / innerLoop;
                }
            }

            if (largest == 1) largest = no;     //the number is prime which implies that it is its biggest prime factor

            return largest;
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
