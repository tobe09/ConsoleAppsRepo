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
            SimpleGrouping();
            MultiGrouping();
        }

        static void SimpleGrouping()
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
        }

        static void MultiGrouping()
        {
            List<Test> tests = new List<Test>() {
                new Test{Name="OneOne", Title="First",ProfileName="First Profile"},
                new Test{Name="OneThree", Title="First",ProfileName="Third Profile"},
                new Test{Name="ThreeTwo", Title="Third",ProfileName="Second Profile"},
                new Test{Name="TwoOne", Title="Second",ProfileName="First Profile"}
            };

            var res1 = tests.GroupBy(th => th.ProfileName)
                            .SelectMany(grp1 => grp1.GroupBy(th => th.Title), (grp1, grp2) => new { grp1, grp2 })
                            .GroupBy(temp0 => temp0.grp1.Key, temp0 => temp0.grp2);

            var res2 = tests.GroupBy(t => t.Title);
        }

        class Test
        {
            public string Name { get; set; }
            public string Title { get; set; }
            public string ProfileName { get; set; }
        }
    }
}
