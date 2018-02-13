using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class MeanMedianMode
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] weight = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.WriteLine(Mean(values));
            Console.WriteLine(Median(values));
            Console.WriteLine(Mode(values));
            double wMean = WeightedMean(values, weight, n);
            Console.WriteLine("{0 :f1}", wMean);

            Console.ReadKey();
        }

        public static double Mean(int[] values)
        {
            double mean;

            double sum = 0;
            foreach (int i in values) 
                sum += i;

            mean = sum / values.Length;

            return mean;
        }

        public static double WeightedMean(int[] values, int[] weight, int length)
        {
            double weightedMean;

            double sum = 0;
            for (int i = 0; i < length; i++)
                sum += values[i] * weight[i];
            int frequency = 0;
            foreach (int i in weight)
                frequency += i;

            weightedMean = sum / frequency;

            return weightedMean;
        }

        public static double Median(int[] values)
        {
            double median;

            int[] valuesClone = ArrayClone(values);

            Array.Sort(valuesClone);
            double pos = (double)(valuesClone.Length + 1) / 2;
            pos = pos - 1;
            if (pos == Math.Round(pos))
            {
                median = valuesClone[(int)pos];
            }
            else
            {
                median = (double)(valuesClone[(int)(pos - 0.5)] + valuesClone[(int)(pos + 0.5)]) / 2;
            }

            return median;
        }

        public static int Mode(int[] values)
        {
            int mode;

            int[] valuesClone = ArrayClone(values);

            Array.Sort(valuesClone);
            mode = valuesClone[0];
            int max = 1, count = 1;

            for (int i = 0; i < valuesClone.Length - 1; i++)
            {
                int currentVal = valuesClone[i];
                if (currentVal == valuesClone[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > max)
                    {
                        max = count;
                        mode = currentVal;
                    }
                    else if (count==max)
                    {
                        if (currentVal < mode)
                            mode = currentVal;
                    }
                    count = 1;
                }
            }

            return mode;
        }

        public static int[] ArrayClone(int[] values)
        {
            int[] valuesClone = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
                valuesClone[i] = values[i];

            return valuesClone;
        }
    }
}
