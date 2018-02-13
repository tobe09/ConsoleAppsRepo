using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Quartiles
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] freqs = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            if (n != values.Length || n != freqs.Length)
                throw new ArgumentException();

            Console.WriteLine("\nLowerQuartile: {0}", LowerQuartile(values));
            Console.WriteLine("Median: {0}", Median(values));
            Console.WriteLine("UpperQuartile: {0}", UpperQuartile(values));
            Console.WriteLine("InterQuartileRange: {0:f1}", InterQuartileRange(values, freqs));

            Console.ReadKey();
        }

        static int LowerQuartile(int[] values)
        {
            int lowerQuartile;

            int[] valuesClone = ArrayIntClone(values);
            Array.Sort(valuesClone);

            double posX = (double)(valuesClone.Length + 1) / 2;
            double posL = Math.Ceiling(posX) / 2;

            //Math.Round(4.5, 0, MidpointRounding.AwayFromZero); //issues with Round() method ambiguity
            if (posL == Math.Ceiling(posL))
                lowerQuartile = valuesClone[(int)(posL - 1)];
            else
                lowerQuartile = (valuesClone[(int)(posL - 0.5)] + valuesClone[(int)(posL - 1.5)]) / 2;

            return lowerQuartile;
        }

        static int Median(int[] values)
        {
            int median;

            int[] valuesClone = ArrayIntClone(values);
            Array.Sort(valuesClone);

            double posX = (double)(valuesClone.Length + 1) / 2;

            if (posX == Math.Ceiling(posX))
                median = valuesClone[(int)(posX - 1)];
            else
                median = (valuesClone[(int)(posX - 0.5)] + valuesClone[(int)(posX - 1.5)]) / 2;

            return median;
        }

        static int UpperQuartile(int[] values)
        {
            int upperQuartile;

            int[] valuesClone = ArrayIntClone(values);
            Array.Sort(valuesClone);

            double posX = (double)(valuesClone.Length + 1) / 2;
            double posU = Math.Floor(posX) + Math.Ceiling(posX) / 2;

             if (posU == Math.Ceiling(posU))
                upperQuartile = valuesClone[(int)(posU - 1)];
            else
                upperQuartile = (valuesClone[(int)(posU - 0.5)] + valuesClone[(int)(posU - 1.5)]) / 2;

            return upperQuartile;
        }

        static int InterQuartileRange(int[] values, int[] freqs)
        {
            int intQ;

            List<int> cummValues = new List<int>();
            for (int i = 0; i < values.Length; i++)
            {
                int freq = freqs[i];

                for (int j = 0; j < freq; j++)
                    cummValues.Add(values[i]);
            }
            cummValues.Sort();

            intQ = UpperQuartile(cummValues.ToArray()) - LowerQuartile(cummValues.ToArray());

            return intQ;
        }

        static int[] ArrayIntClone(int[] values)
        {
            int[] valuesClone = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
                valuesClone[i] = values[i];

            return valuesClone;
        }
    }
}
