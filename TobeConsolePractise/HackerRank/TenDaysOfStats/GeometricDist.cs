using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class GeometricDist
    {
        public static void Run()
        {
            double p = 1.0 / 3;
            int x = 1;          //first inspection
            int n = 5;

            double ans = GeoDistribution(p, x, n);

            ans = Math.Round(ans, 3, MidpointRounding.AwayFromZero);

            Console.WriteLine(ans);

            //1st defect during the first 5 inspections
            double ans2 = 1 - GeoDistribution(p, 0, n);
            double ans3 = 1 - Math.Pow(2.0 / 3, 5);           //also correct

            ans2 = Math.Round(ans2, 3, MidpointRounding.AwayFromZero);

            Console.WriteLine(ans2);
            Console.WriteLine(ans3);

            Console.ReadKey();
        }

        static double GeoDistribution(double p, int x, int n)
        {
            double ans;

            ans = Combination(n - 1, x - 1) * Math.Pow(p, x) * Math.Pow(1 - p, n - x);

            return ans;
        }

        static int Combination(int n, int x)
        {
            if (x > n || x < 0) return 1;

            return Factorial(n) / (Factorial(x) * Factorial(n - x));
        }

        static int Factorial(int n)
        {
            if (n < 1) return 1;

            int fact = 1;

            for (int i = 2; i <= n; i++)
                fact *= i;

            return fact;
        }
    }
}
