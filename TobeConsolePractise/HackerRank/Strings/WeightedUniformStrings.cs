using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class WeightedUniformStrings
    {
        public static void Run()
        {
            string s = ReadLine();
            int n = int.Parse(ReadLine());
            int occurence = 1, lastNum = 0;

            HashSet<int> numList = new HashSet<int>();      //to ensure uniqueness of values
            for (int i = 0; i < s.Length; i++)
            {
                int num = s[i] - 'a' + 1;

                if (num == lastNum)
                    occurence++;
                else
                {
                    occurence = 1;
                    lastNum = num;
                }

                numList.Add(num * occurence);
            }

            for (int a0 = 0; a0 < n; a0++)
            {
                int x = int.Parse(ReadLine());
                if (numList.Contains(x))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }

            Console.ReadKey();
        }

        public static void Run2()
        {
            //string s = Console.ReadLine(); //limited input length
            string s = ReadLine(100000);
            int n = Convert.ToInt32(Console.ReadLine());

            Dictionary<char, int> charDict = new Dictionary<char, int>();
            int start = 1;
            for (char c = 'a'; c <= 'z'; c++)
                charDict.Add(c, start++);

            List<char> distinctChar = new List<char>();
            Dictionary<char, int> charAppr = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z')
                {
                    if (charAppr.ContainsKey(s[i]))
                        charAppr[s[i]]++;
                    else
                    {
                        charAppr.Add(s[i], 1);
                        distinctChar.Add(s[i]);
                    }
                }
            }

            List<int> acceptedValues = new List<int>();
            for (int i = 0; i < distinctChar.Count; i++)
            {
                for (int j = 1; j <= charAppr[distinctChar[i]]; j++)
                {
                    int acceptedInt = charDict[distinctChar[i]] * j;
                    acceptedValues.Add(acceptedInt);
                }
            }

            for (int a0 = 0; a0 < n; a0++)
            {
                int x = Convert.ToInt32(Console.ReadLine());

                if (acceptedValues.Contains(x))
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
            }
        }

        static string ReadLine(int bufferSize = 100000)
        {
            System.IO.Stream inputStream = Console.OpenStandardInput(bufferSize);
            byte[] bytes = new byte[bufferSize];
            int outputLength = inputStream.Read(bytes, 0, bufferSize);
            char[] chars = System.Text.Encoding.UTF7.GetChars(bytes, 0, outputLength - 2);      //remove \r and \n
            return new string(chars);
        }
    }
}
