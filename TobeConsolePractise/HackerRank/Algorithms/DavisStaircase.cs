using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class DavisStaircase
    {
        public static void Run()
        {
            int s = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < s; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Steps(n));
            }

            Console.ReadKey();
        }

        public static int[][] Mul(int[][] a)
        {
            int[][] b = { new int[3] { 1, 1, 0 }, new int[3] { 1, 0, 1 }, new int[3] { 1, 0, 0 } };
            int[][] c = { new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 }, new int[3] { 0, 0, 0 } };

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        c[i][j] += a[i][k] * b[k][j];

            return c;
        }

        public static int Steps(int n)
        {
            int[][] a = { new int[3] { 1, 1, 0 }, new int[3] { 1, 0, 1 }, new int[3] { 1, 0, 0 } };

            if (n == 1) return 1;
            else if (n == 2) return 2;
            else if (n == 3) return 4;
            else
            {
                for (int i = 0; i < n - 2; i++)
                    a = Mul(a);

                return 4 * a[0][2] + 2 * a[1][2] + a[2][2];
            }
        }
    }
}
