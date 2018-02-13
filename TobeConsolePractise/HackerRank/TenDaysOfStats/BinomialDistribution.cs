using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class BinomialDistribution
    {
        public static void Run()
        {
            double boyRatio = 1.09, girlRatio = 1;
            double totalRatio = boyRatio + girlRatio;

            double boyProb = boyRatio / totalRatio;
            //double girlProb = 1 - boyProb;        //not necessary in a binomial experiment

            double prob = 0;
            for (int i = 3; i <= 6; i++)    //at least 3 (total 6)
                prob += SingleProbability(i, 6, boyProb);

            Console.WriteLine("{0:f3}", prob);

            double reject = 12.0 / 100;
            int n = 10;

            double bin = 0;

            //no more than 2 rejacts
            for (int i = 0; i <= 2; i++)
                bin += SingleProbability(i, n, reject);
            Console.WriteLine("{0:f3}", bin);

            //at least 2 rejects
            bin = 0;
            for (int i = 2; i <= 10; i++)
                bin += SingleProbability(i, n, reject);
            Console.WriteLine("{0:f3}", bin);

            Console.ReadKey();
        }

        static double SingleProbability(int x, int n, double p)
        {
            return Combination(n, x) * Math.Pow(p, x) * Math.Pow(1 - p, n - x);
        }

        static int Combination(int n, int x)
        {
            return Factorial(n) / (Factorial(x) * Factorial(n - x));
        }

        static int Factorial(int n)
        {
            if (n <= 1) return 1;
            else return n * Factorial(n - 1);
        }
    }
}
