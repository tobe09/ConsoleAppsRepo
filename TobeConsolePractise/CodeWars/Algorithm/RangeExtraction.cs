using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class RangeExtraction
    {
        public static void Run()
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None), int.Parse);
            Console.WriteLine(Extract(arr));
        }

        public static string Extract(int[] args)
        {
            string result = "";

            int end = args.Length;
            for (int i = 0; i < end; i++)
            {
                object[] status = IsRange(i, args);
                if ((bool)status[0])
                {
                    int newI = (int)status[1];
                    result += "," + args[i] + "-" + args[newI];
                    i = newI;
                }
                else
                {
                    result += "," + args[i];
                }
            }

            return result.Substring(1);  
        }

        static object[] IsRange(int position, int[] args)
        {
            object[] status = new object[2];

            int end = args.Length;
            int i = position;
            int count = 1;
            while (i < end - 1 && args[i + 1] - args[i] == 1)
            {
                i++;
                count++;
            }

            status[1] = i;
            if (count >= 3) status[0] = true;
            else status[0] = false;

            return status;
        }
    }
}
