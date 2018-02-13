using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public class CentralLimitTheorem
    {
        public static void Run()
        {
            //Run1();
            //Run2();
            Run3();

            Console.ReadKey();
        }

        public static void Run1()
        {
            double mean = 205, std = 15, weight = 9800;
            int n = 49;

            /* Formulas are from problem's tutorial */
            double commonMean = n * mean;
            double commonStd = Math.Sqrt(n) * std;

            Console.WriteLine("{0:f4}", TotalProb(commonMean, commonStd, weight));
        }
        public static void Run2()
        {
            double mean = 2.4, std = 2, ticketRemaining = 250;
            int n = 100;

            /* Formulas are from problem's tutorial */
            double commonMean = n * mean;
            double commonStd = Math.Sqrt(n) * std;

            Console.WriteLine("{0:f4}", TotalProb(commonMean, commonStd, ticketRemaining));
        }

        public static void Run3()
        {
            double mean = 500, std = 80, z = 1.96;      //95% confidence interval
            int n = 100;

            double diff = z * std / Math.Sqrt(n);

            /* Print output */
            Console.WriteLine("{0:f2}", mean - diff);
            Console.WriteLine("{0:f2}", mean + diff);
        }

        /* Calculates cumulative probability */
        static double TotalProb(double mean, double std, double val)
        {
            double value = (val - mean) / (std * Math.Sqrt(2));

            return (0.5) * (1 + Erf(value));
        }

        static double Erf(double z)
        {
            double t = 1.0 / (1.0 + 0.5 * Math.Abs(z));

            // use Horner's method
            double ans = 1 - t * Math.Exp(-z * z - 1.26551223 + t * (1.00002368 + t * (0.37409196 + t * (0.09678418 + t * (-0.18628806 +
                t * (0.27886807 + t * (-1.13520398 + t * (1.48851587 + t * (-0.82215223 + t * (0.17087277))))))))));

            if (z >= 0) return ans;
            else return -ans;
        }
    }
}
