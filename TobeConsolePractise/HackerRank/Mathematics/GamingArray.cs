using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class GamingArray
    {
        public static void Run()
        {
            int g = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < g; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                int max = 0;
                bool flag = true;       //Bob starts

                for (int i = 0; i < n; i++)
                {
                    int value = data[i];
                    if (max < value)
                    {
                        max = value;
                        flag = !flag;
                    }
                }

                Console.WriteLine(flag ? "ANDY" : "BOB");
            }

            Console.ReadKey();
        }

        public static void Run2()
        {
            int g = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < g; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] data = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(GameWinner(data));
            }

            Console.ReadKey();
        }

        static string GameWinner(int[] data)
        {
            bool flag = true;       //for Bob starts

            while (data.Length > 0)
            {
                int maxPos = MaxPosition(data);
                data = ReducedArray(data, maxPos);
                flag = !flag;
            }

            if (flag) return "ANDY";
            else return "BOB";
        }

        static int MaxPosition(int[] data)
        {
            int max = int.MinValue, pos = 0, n = data.Length;

            for (int i = 0; i < n; i++)
            {
                if (data[i] > max)
                {
                    max = data[i];
                    pos = i;
                }
            }

            return pos;
        }

        static int[] ReducedArray(int[] data, int pos)
        {
            int[] arr = new int[pos];

            for (int i = 0; i < pos; i++)
                arr[i] = data[i];

            return arr;
        }
    }
}
