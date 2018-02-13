using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class CircularRotation
    {

        public static void Rotate()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int q = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            int[] vals = new int[n];
            int pos;
            for (int j = 0; j < n; j++)
            {
                pos = (j + k) % n;
                vals[pos] = a[j];
            }
            a = vals;

            for (int a0 = 0; a0 < q; a0++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(a[m]);
            }
            Console.ReadKey();
        }

        public static void Rotate2()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int q = Convert.ToInt32(tokens_n[2]);
            string[] a_temp = CharIntValues.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            int[] vals = new int[n];
            int pos;
            for (int j = 0; j < n; j++)
            {
                pos = (j + k) % n;
                vals[pos] = a[j];
            }
            a = vals;

            int[] arr = new int[q];
            for (int a0 = 0; a0 < q; a0++)
            {
                int m = Convert.ToInt32(Console.ReadLine());
                arr[a0] = m;
            }

            Console.WriteLine("\r\nANSWERS");
            for (int j = 0; j < q; j++)
                Console.WriteLine(a[arr[j]]);

            Console.ReadKey();
        }

        public static void Run()
        {
            Rotate();
        }
    }
}
