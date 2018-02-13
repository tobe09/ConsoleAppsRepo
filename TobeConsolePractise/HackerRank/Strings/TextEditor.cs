using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class TextEditor
    {
        //1- append, 2- delete, 3- print, 4- undopublic class Solution 
        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            string s = "";
            Stack<string> str = new Stack<string>();
            str.Push(s);

            for (int i = 0; i < n; i++)
            {
                string[] query = Console.ReadLine().Split(' ');
                int t = int.Parse(query[0]);
                if (t == 1)
                {
                    s += query[1]; ;
                    str.Push(s);
                }
                else if (t == 2)
                {
                    int pos = int.Parse(query[1]);
                    s = s.Substring(0, s.Length - pos);
                    str.Push(s);
                }
                else if (t == 3)
                {
                    int pos = int.Parse(query[1]);
                    Console.WriteLine(s[pos - 1]);
                }
                else
                {
                    str.Pop();
                    s = str.Peek();
                }
            }
        }
    }
}
