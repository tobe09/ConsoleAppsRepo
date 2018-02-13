using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class PearsonCorrCoeff
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            double[] valuesX = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToDouble);
            double[] valuesY = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse); 
            if (n != valuesX.Length || n != valuesY.Length)
                throw new ArgumentException();

            Console.WriteLine("{0:f3}", PearsonCoeff(valuesX, valuesY));

            Console.ReadKey();
        }

        public static double PearsonCoeff(double[] valuesX, double[] valuesY)
        {
            double pearsonCoeff = 0;

            double meanX = Mean(valuesX);
            double meanY = Mean(valuesY);
            double stdX = StandardDeviation(valuesX, meanX);
            double stdY = StandardDeviation(valuesY, meanY);

            for (int i = 0; i < valuesX.Length; i++)
                pearsonCoeff += (valuesX[i] - meanX) * (valuesY[i] - meanY);

            pearsonCoeff = pearsonCoeff / (valuesX.Length * stdX * stdY);

            return pearsonCoeff;
        }

        public static double Mean(double[] values)
        {
            double mean = 0;

            foreach (double i in values)
                mean += i;

            mean = mean / values.Length;

            return mean;
        }

        public static double StandardDeviation(double[] values, double mean)
        {
            double std = 0;

            foreach (double value in values)
                std += Math.Pow((value - mean), 2);

            std = Math.Sqrt(std / values.Length);

            return std;
        }
    }
}
