using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class ArrayManipulation
    {
        /*For example, consider a list a of size 3. The initial list would be a = [0,0,0]  and after performing the update 0{a,b,k}={2,3,30}, 
         * the new list would be = [0,30,30]. Here, we've added value 30 to elements between indices 2 and 3. Note the index of the list starts from 1.*/
        public static void Run()
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);

            int[] values = new int[n];
            for (int a0 = 0; a0 < m; a0++)
            {
                string[] tokens_a = Console.ReadLine().Split(' ');
                int a = Convert.ToInt32(tokens_a[0]);
                int b = Convert.ToInt32(tokens_a[1]);
                int k = Convert.ToInt32(tokens_a[2]);

                values[a - 1] += k;
                if (b < n) values[b] -= k;
            }

            long temp = 0;
            long max = 0;
            for (int i = 0; i < n; i++)
            {
                temp += values[i];
                if (temp > max) max = temp;
            }

            Console.WriteLine(max);
        }
    }
}
