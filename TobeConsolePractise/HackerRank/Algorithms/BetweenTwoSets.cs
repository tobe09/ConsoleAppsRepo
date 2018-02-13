using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class BetweenTwoSets
    {
        public static void Run()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            string[] b_temp = Console.ReadLine().Split(' ');
            int[] b = Array.ConvertAll(b_temp, Int32.Parse);
            int total = getTotalX(a, b);
            Console.WriteLine(total);
        }

        static int getTotalX(int[] a, int[] b)
        {
            int count = 0;
            int lcm = Lcm(a);
            int hcf = Hcf(b);

            for (int i = 1; i <= hcf / lcm; i++)
            {
                if (hcf % (lcm * i) == 0) count++;
            }

            return count;
        }

        static int Hcf(int[] arr)
        {
            List<int> vals = arr.ToList();
            vals.Sort();

            int hcf = vals[vals.Count - 1];
            for (int i = vals.Count - 2; i >= 0; i--)
            {
                hcf = Hcf(hcf, vals[i]);
            }

            return hcf;
        }

        static int Lcm(int[] arr)
        {
            int lcm = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                lcm = Lcm(lcm, arr[i]);
            }

            return lcm;
        }

        static int Hcf(int bigger, int smaller)
        {
            if (smaller == 0)
                return bigger;

            return Hcf(smaller, bigger % smaller);
        }

        static int Lcm(int a, int b)
        {
            int a1 = a;
            int b1 = b;

            while (a1 != b1)
            {
                if (a1 < b1)
                    a1 += a;
                else
                    b1 += b;
            }

            return a1;
        }
    }
}
