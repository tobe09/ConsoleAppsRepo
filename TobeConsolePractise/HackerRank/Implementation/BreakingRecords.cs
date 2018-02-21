using System;

namespace TobeConsolePractise
{
    class BreakingRecords
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] score_temp = Console.ReadLine().Split(' ');
            int[] score = Array.ConvertAll(score_temp, Int32.Parse);
            int[] result = BreakingRecord(score);
            Console.WriteLine(String.Join(" ", result));


        }

        static int[] BreakingRecord(int[] score)
        {
            int most = score[0], least = score[0];
            int mostCount = 0, leastCount = 0;

            for (int i = 1; i < score.Length; i++)
            {
                if (score[i] > most)
                {
                    most = score[i];
                    mostCount++;
                }
                else if (score[i] < least)
                {
                    least = score[i];
                    leastCount++;
                }
            }

            return new int[2] { mostCount, leastCount };
        }
    }
}
