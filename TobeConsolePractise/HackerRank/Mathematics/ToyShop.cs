using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class ToyShop
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] w_temp = Console.ReadLine().Split(' ');
            int[] w = Array.ConvertAll(w_temp, Int32.Parse);
            int result = toys(w);
            Console.WriteLine(result);

            Console.ReadKey();
        }

        static int toys(int[] w)
        {
            // Complete this function
            int cost = 0;

            List<int> toyList = new List<int>();
            foreach (int toy in w)
                toyList.Add(toy);

            toyList.Sort();

            int i = 0;
            while (i < toyList.Count)
            {
                cost++;

                int weight = toyList[i];
                do
                {
                    i++;
                    if (i >= toyList.Count) break;
                }
                while (toyList[i] - weight <= 4);
            }

            return cost;
        }
    }
}
