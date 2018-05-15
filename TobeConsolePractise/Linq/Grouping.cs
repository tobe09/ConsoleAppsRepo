using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Grouping
    {
        /// <summary>
        /// GroupBy
        /// ToLookUp (not applicable)
        /// </summary>
        public static void Run()
        {
            List<int> nums = new List<int>() { 35, 44, 200, 84, 3847, 4, 199, 329, 446, 208 };
            IEnumerable<IGrouping<int, int>> query = from num in nums group num by num % 2;

            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? "Even Numbers" : "Odd Numbers");
                foreach (int i in group)
                    Console.WriteLine(i);
            }

            ILookup<bool, IGrouping<int, int>> lookUp = query.ToLookup(q => q.Key % 2 == 0);

            foreach (var grp in lookUp)
            {
                foreach (var group in grp)
                {
                    Console.WriteLine(group.Key == 0 ? "Even Numbers" : "Odd Numbers");
                    foreach (int i in group)
                        Console.WriteLine(i);
                }
            }

            Console.ReadLine();
        }
    }
}
