using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class RegexTest
    {
        public static void Run()
        {
            string pattern = @"^\w+@gmail.com$";
            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);

            List<string[]> values = new List<string[]>();
            string firstName, email;
            List<string> matchingValues=new List<string>();
            List<string> sortList = new List<string>();

            int N = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < N; a0++)
            {
                string[] tokens_firstName = Console.ReadLine().Split(' ');
                firstName = tokens_firstName[0];
                email = tokens_firstName[1];
                values.Add(new string[2] { firstName, email });
            }

            for (int i = 0; i < values.Count; i++)
            {
                firstName = values[i][0];
                email = values[i][1];
                if (rgx.IsMatch(email))
                {
                    sortList.Add(firstName);
                    matchingValues.Add(firstName);
                }
            }

            sortList.Sort();
            matchingValues= matchingValues.OrderBy(x => x).ToList();

            for (int i = 0; i < matchingValues.Count; i++)
                Console.WriteLine(matchingValues[i]);

            Console.ReadKey();
        }
    }
}
