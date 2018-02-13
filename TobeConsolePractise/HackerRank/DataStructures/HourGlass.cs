using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class HourGlass
    {
        public static void Run()
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            int max = int.MinValue;   //or, -9 * 6 = -54
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
                        arr[i + 1][j + 1] +
                        arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

                    if (sum > max) max = sum;
                }
            }

            Console.WriteLine(max);

            Console.ReadKey();
        }
    }
}
