using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Anagram
    {
        public static void Run()
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            int count = 0;

            while (a.Length > 0)
            {
                int pos = b.IndexOf(a[0]);

                if (pos >= 0)
                    b = b.Remove(pos, 1);
                else
                    count++;

                a = a.Remove(0, 1);
            }

            count += b.Length;

            Console.WriteLine(count);

            Console.ReadKey();
        }
    }
}
