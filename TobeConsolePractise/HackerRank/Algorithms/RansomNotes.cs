using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class RanssomNote
    {
        public static void Run()
        {
            string[] tokens_m = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(tokens_m[0]);
            int n = Convert.ToInt32(tokens_m[1]);
            string[] magazine = CharIntValues.ReadLine(300000).Split(' ');
            string[] ransom = CharIntValues.ReadLine(300000).Split(' ');

            List<string> mag=magazine.ToList<string>();
            mag.Sort((str, str2) => str.CompareTo(str2));

            string available = "Yes";
            for (int i = 0; i < ransom.Length; i++)
            {
                if (!Remove(ransom[i], mag))
                {
                    available = "No";
                    break;
                }
            }

            Console.WriteLine(available);

            Console.ReadKey();
        }

        public static bool Remove(string data, List<string> listStr)        //binary search
        {
            bool status = false;
            int lowerBound = 0, upperBound = listStr.Count - 1, midPoint = -1, index = -1;

            while (lowerBound <= upperBound)
            {
                midPoint = lowerBound + ((upperBound - lowerBound) / 2);

                if (listStr[midPoint] == data)        //data found
                {
                    status = true;
                    index = midPoint;
                    break;
                }
                else if (listStr[midPoint].CompareTo(data) < 0)    //value is larger
                    lowerBound = midPoint + 1;                      //data in lower half
                else
                    upperBound = midPoint - 1;
            }

            if (index != -1) listStr.RemoveAt(index);

            return status;
        }
    }
}
