using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Prime
    {
        static long LargestPrimeFactor(long no)
        {
            long largest = 1;

            long end = no / 2;    
            //check if values less than half the number is a factor
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

        static bool OnlyPrime(int[][] arr)
        {
            bool onlyPrime = true;

            for (int i = 0; i < arr[0].Length; i++)
            {
                for (int j = 0; j < arr[0].Length; j++)
                {
                    if (!IsPrime(arr[i][j]))
                    {
                        onlyPrime = false;
                        break;
                    }
                }
            }

            return onlyPrime;
        }
        
        static bool IsPrime(int n)
        {
            bool isPrime = true;

            n = Math.Abs(n);
            if (n > 2)
            {
                int sqrtN = (int)Math.Ceiling(Math.Sqrt(n));
                for (int i = 2; i <= sqrtN; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
            else if (n == 2)
            {
                isPrime = true;
            }
            else
            {
                isPrime = false;
            }

            return isPrime;
        }

        //not optimized
        public string primeNumbers(int i, int n)
        {
            string values = "The prime numbers between " + i + " and " + n + " are: ";
            if (!(n == 0 || n == 1 || n == 2) && n > i)
            {
                for (int x = i; x <= n; x++) //loops from the initial to the final number as x
                {
                    int countPrime = 0; //checks if a number is prime
                    for (int y = 2; y < x; y++) //loops each x value for primes as y
                    {
                        if (x % y == 0) countPrime++;
                    }
                    if (countPrime == 0 && x != 0 && x != 1 && x != 2) values += x + ", ";
                }
                values = values.Remove(values.Length - 2) + ".";
            }
            else
            {
                if (n <= i) values = "The End Point must be greater than the Start Point!";
                else values = "Your end point should be greater than 2!";
            }
            return values;
        }
    }
}
