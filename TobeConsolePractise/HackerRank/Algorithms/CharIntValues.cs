using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class CharIntValues
    {
        public static void Run(int bufferSize)
        {
            //string s = Console.ReadLine(); //limited input length
            string s = ReadLine(bufferSize);
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

            //dictionary foreach loop
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

            Console.ReadKey();
        }

        public static string ReadLine(int bufferSize = 100000)
        {
            System.IO.Stream inputStream = Console.OpenStandardInput(bufferSize);
            byte[] bytes = new byte[bufferSize];
            int outputLength = inputStream.Read(bytes, 0, bufferSize);
            char[] chars = System.Text.Encoding.UTF7.GetChars(bytes, 0, outputLength);
            string values = new string(chars);
            if ((values[values.Length - 2] == '\r' || values[values.Length - 2] == '\r') ||
                (values[values.Length - 1] == '\r' || values[values.Length - 1] == '\r'))
                values = values.Remove(values.Length - 2);
            return values;
        }
    }
}
