using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class BalancedBrackets
    {
        public static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string expression = Console.ReadLine();

                string answer = "YES";

                //check if string length is even
                if (expression.Length % 2 == 1) answer = "NO";
                else
                {
                    Stack<char> s = new Stack<char>();
                    foreach (char bracket in expression)
                    {
                        switch (bracket)
                        {
                            case '{': s.Push('}'); break;
                            case '(': s.Push(')'); break;
                            case '[': s.Push(']'); break;
                            default:
                                if (s.Count == 0 || bracket != s.Pop()) answer = "NO";
                                break;
                        }
                        if (answer == "NO") break;
                    }

                    if (s.Count != 0) answer = "NO";
                }

                Console.WriteLine(answer);
            }

            Console.ReadKey();
        }

        static string isBalanced(string expression)
        {
            // Must be even
            if ((expression.Length & 1) == 1) return "NO";
            else
            {
                Stack<char> s = new Stack<char>();
                foreach (char bracket in expression)
                {
                    switch (bracket)
                    {
                        case '{': s.Push('}'); break;
                        case '(': s.Push(')'); break;
                        case '[': s.Push(']'); break;
                        default:
                            if (s.Count == 0 || bracket != s.Pop())
                                return "NO";
                            break;
                    }
                }

                return s.Count == 0 ? "YES" : "NO";
            }
        }
    }
}
