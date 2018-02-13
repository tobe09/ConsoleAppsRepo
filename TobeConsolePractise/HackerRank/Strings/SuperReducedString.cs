using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class SuperReducedString
    {
        public static void Run()
        {
            string s = Console.ReadLine();

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    string start = s.Substring(0, i);
                    if (s.Length - i > 2) start += s.Substring(i + 2);
                    s = start;
                    i = -1;         //increments to zero
                }
            }

            if (s.Length == 0) Console.WriteLine("Empty String");
            else Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
