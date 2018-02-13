using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class NormalDistribution
    {
        public static void Run()
        {
            //Run1();
            Run2();

            Console.ReadKey();
        }

        public static void Run1()
        {
            double mean = 20;
            double std = 2;

            //less then 19.5 hours
            double cummProb = CummulativeProbability(19.5, mean, std);
            Console.WriteLine(cummProb);

            //between 20 and 22 hours
            cummProb = CummulativeProbability(22, mean, std) - CummulativeProbability(20, mean, std);
            Console.WriteLine(cummProb);
        }

        public static void Run2()
        {
            double mean = 70;
            double std = 10;

            //greater then 80 marks
            double cummProb = 1 - CummulativeProbability(80, mean, std);
            cummProb = cummProb * 100;
            Console.WriteLine("{0:f2}", cummProb);

            //greater than or equal to 60
            cummProb = 1 - CummulativeProbability(60, mean, std);
            cummProb = cummProb * 100;
            Console.WriteLine("{0:f2}", cummProb);

            //less than 60
            cummProb = 1 - cummProb / 100;
            cummProb = cummProb * 100;
            Console.WriteLine("{0:f2}", cummProb);
        }

        public static double CummulativeProbability(double x, double mean, double std)
        {
            double cummProb;

            double z = (x - mean) / (std * Math.Sqrt(2));
            cummProb = 0.5 * (1 + Erf(z));

            return cummProb;
        }

        //erf(x)=2/sqrt(pi) * (integral,x,0)=>e^(-x^2)  
        public static double Erf(double z)
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
