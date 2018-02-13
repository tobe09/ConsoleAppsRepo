using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class LargestPrimeFactor
    {
        public long LargestPrime(long no)
        {
            long largest = 1;

            long rootNo=(long)Math.Sqrt(no);
            //check if values less than root of the number is a factor
            for (int innerLoop = 2; innerLoop <= rootNo; innerLoop++)
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
                }
            }

            if (largest == 1) largest = no;     //the number is prime which implies that it is its biggest prime factor

            return largest;
        }

        public static void Run(long no = 600851475143)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            long largestPrime = new LargestPrimeFactor().LargestPrime(no);
            double time = stopWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("The largest prime factor of " + no + " is: " + largestPrime);
            Console.WriteLine("Time taken: " + time + " milliseconds");
            Console.ReadKey();
        }
    }
}
