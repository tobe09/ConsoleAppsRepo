using System;

namespace TobeConsolePractise
{
    class InsertionSortAdvanced
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int a0 = 0; a0 < n; a0++)
            {
                int count = int.Parse(Console.ReadLine());
                string[] strValues = Console.ReadLine().Split(' ');
                int[] values = Array.ConvertAll(strValues, int.Parse);
                int swaps = 0;

                for (int i = 1; i < count; i++)
                {
                    for (int j = i; j > 0; j--)
                    {
                        if (values[j] < values[j - 1])
                        {
                            int temp = values[j];
                            values[j] = values[j - 1];
                            values[j - 1] = temp;
                            swaps++;
                        }
                        else
                            break;
                    }
                }

                Console.WriteLine(swaps);
            }

            Console.ReadKey();
        }
    }
}
