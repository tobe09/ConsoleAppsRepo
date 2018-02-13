using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class PoissonDistribution
    {
        public static void Run()
        {
            double lambda = 2.5;
            int k = 5;               //likelihood in 5 tries

            double poissonProb = PoissonValue(k, lambda);

            Console.WriteLine("{0:N2}", poissonProb);

            lambda = 0.88;
            double cost = 160 + (40 * (lambda + Math.Pow(lambda, 2)));

            Console.WriteLine("{0:N3}", cost);

            lambda = 1.55;
            cost = 128 + (40 * (lambda + Math.Pow(lambda, 2)));

            Console.WriteLine("{0:N3}", cost);

            Console.ReadKey();
        }

        static double PoissonValue(int k, double lambda)
        {
            return Math.Pow(lambda, k) * Math.Pow(Math.E, -lambda) / Factorial(k);
        }

        static int Factorial(int n)
        {
            if (n <= 1) return 1;
            else return n * Factorial(n - 1);
        }
    }
}
