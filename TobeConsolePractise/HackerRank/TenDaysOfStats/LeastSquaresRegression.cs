using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class LeastSquaresRegression
    {
        public static void Run()
        {
            int[] maths = { 95, 85, 80, 70, 60 };
            int[] stats = { 85, 95, 70, 65, 70 };

            //Y = a + bX, b = p * stdY / stdYX, a = Y - bX
            double b = PearsonCoeff(maths, stats) * StandardDeviation(stats) / StandardDeviation(maths);
            double a = Mean(stats) - b * Mean(maths);

            //when x (maths) = 80
            double stat = a + b * 80;

            Console.WriteLine("{0:f3}", stat);

            Console.ReadKey();
        }

        public static double PearsonCoeff(int[] valuesX, int[] valuesY)
        {
            double pearsonCoeff = 0;

            for (int i = 0; i < valuesX.Length; i++)
                pearsonCoeff += (valuesX[i] - Mean(valuesX)) * (valuesY[i] - Mean(valuesY));

            pearsonCoeff = pearsonCoeff / (valuesX.Length * StandardDeviation(valuesX) * StandardDeviation(valuesY));

            return pearsonCoeff;
        }

        public static double StandardDeviation(int[] values)
        {
            double std = 0;

            foreach (double value in values)
                std += Math.Pow((value - Mean(values)), 2);

            std = Math.Sqrt(std / values.Length);

            return std;
        }

        public static double Mean(int[] values)
        {
            double mean = 0;

            foreach (double i in values)
                mean += i;

            mean = mean / values.Length;

            return mean;
        }
    }
}
