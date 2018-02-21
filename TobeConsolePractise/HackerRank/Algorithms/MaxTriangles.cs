using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class MaxTriangles
    {
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            if (n != arr.Length) n = arr.Length;

            List<int> arrList = arr.ToList();
            arrList.Sort();
            arr = arrList.ToArray();

            int x = 0, y = 0, z = 0;
            //checck if subsequent sum of sides form a degenerate triangle
            for (x = n - 3, y = n - 2, z = n - 1; arr[x] + arr[y] <= arr[z]; x--, y--, z--)     
            {
                //if no degenerate sum is found at the end, print "-1"
                if (x == 0)
                {
                    Console.WriteLine("-1");
                    x = -1;
                    break;
                }
            }

            if (x != -1)        //degenerate triangle found
                Console.WriteLine("{0}, {1}, {2}", arr[x], arr[y], arr[z]);        
        }
    }
}
