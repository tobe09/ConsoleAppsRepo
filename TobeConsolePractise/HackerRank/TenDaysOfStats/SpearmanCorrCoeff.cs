using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class SpearmanCorrCoeff
    {
        //with repetition, Sperarman(x,y) = Pearson(RankX[], RankY[])
        //without repetition, Spearman(x,y) = 1 - (6 * Summation(d)^2) / n * (n^2 - 1)
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            string x = Console.ReadLine();
            double[] X = Array.ConvertAll(x.Substring(0, x.Length - 1).Split(' '), double.Parse);
            double[] Y = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            //double[] X = ConvertStringToDouble(x.Substring(0, x.Length - 1), ' ');
            //double[] Y = ConvertStringToDouble(Console.ReadLine(), ' ');

            Console.WriteLine("{0:f3}", GetSpearmanUnique(X, Y, n));

            Console.ReadKey();
        }

        static double GetSpearmanUnique(double[] X, double[] Y, int n)
        {
            int[] rankX = GetRankArray(X);
            int[] rankY = GetRankArray(Y);

            double sumDsquared = 0;
            for (int i = 0; i < n; i++)
                sumDsquared += Math.Pow(rankX[i] - rankY[i], 2);

            double spearman = 1 - (6 * sumDsquared) / (n * (n * n - 1));

            return spearman;
        }

        static int[] GetRankArray(double[] values)
        {
            int[] rankArr = new int[values.Length];

            List<double> vallist = values.ToList();
            vallist.Sort();
            double[] valuesSorted = vallist.ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    if (values[i] == valuesSorted[j])
                    {
                        rankArr[i] = j + 1;
                        break;
                    }
                }
            }

            return rankArr;
        }

        static double[] ConvertStringToDouble(string s, char sep)
        {
            string[] sArr = s.Split(sep);
            double[] arr = new double[sArr.Length];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = double.Parse(sArr[i]);

            return arr;
        }
    }
}
