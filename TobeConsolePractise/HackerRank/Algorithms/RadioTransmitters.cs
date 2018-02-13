using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class RadioTransmitters
    {
        private static List<int> values { get; set; }

        //not yet optimal
        public static void Run()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] x_temp = Console.ReadLine().Split(' ');
            int[] x = Array.ConvertAll(x_temp, Int32.Parse);

            values = x.ToList();
            values.Sort();

            int count = 0, lowerbound = 0, startHouse = values[0], placeHouse, nextHouse, lastHouse = values[n - 1];
            while (startHouse <= lastHouse)
            {
                placeHouse = startHouse + k;
                while (!(bool)Contains(placeHouse, lowerbound)[1])
                {
                    placeHouse--;
                    if (placeHouse == startHouse) break;
                }

                nextHouse = placeHouse + k + 1;
                while (!(bool)Contains(nextHouse, lowerbound)[1])
                {
                    nextHouse++;
                    if (nextHouse > lastHouse) break;
                }

                startHouse = nextHouse;
                lowerbound = (int)Contains(startHouse, lowerbound)[0];
                count++;
            }

            Console.WriteLine(count);

            Console.ReadKey();
        }

        private static object[] Contains(int data, int lowerBound)
        {
            object[] content = new object[2] { -1, false };

            for (int i = lowerBound; i < values.Count; i++)
            {
                if (data == values[i])
                {
                    content[0] = i;
                    content[1] = true;
                    break;
                }
            }

            return content;
        }
    }
}
