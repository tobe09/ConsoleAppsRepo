using System;
using System.Collections.Generic;
using System.Linq;

namespace TobeConsolePractise
{
    class ArrayDifference
    {
        public static void Run()
        {
            int[] arr1 = Array.ConvertAll(Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None), int.Parse);
            int[] arr2 = Array.ConvertAll(Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None), int.Parse);
            int[] arrDiff = ArrayDiff(arr1, arr2);

            foreach (int i in arrDiff) Console.Write(i + " ");
        }

        public static int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> newList=new List<int>();

            List<int> b1 = b.ToList();
            foreach (int i in a)
            {
                if (!b1.Contains(i)) 
                    newList.Add(i);
            }

            return newList.ToArray();
        }
    }
}
