using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Contacts
    {
        public static void Run()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<string> names = new List<string>();

            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_op = Console.ReadLine().Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];
                if (op == "add")
                {
                    names.Add(contact);
                }
                else        //op = "find"
                {
                    int count = 0;
                    foreach (string name in names)
                    {
                        if (name.Contains(contact))
                            count++;
                    }
                    Console.WriteLine(count);
                }
            }

            Console.ReadKey();
        }
    }
}
