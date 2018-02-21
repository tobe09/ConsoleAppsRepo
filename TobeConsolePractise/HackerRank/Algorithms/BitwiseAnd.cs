using System;

namespace TobeConsolePractise
{
    class BitwiseAnd
    {
        public static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);

                int[] values = new int[n];
                for (int i = 0; i < n; i++)
                    values[i] = i + 1;

                int max = 0, binAnd;
                for (int i = 1; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        binAnd = values[i] & values[j];
                        if (binAnd > max && binAnd < k)
                            max = binAnd;
                    }
                }

                Console.WriteLine(max);

                Console.ReadKey();
            }
        }
    }
}
