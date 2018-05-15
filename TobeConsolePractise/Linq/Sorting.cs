using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Sorting
    {
        /// <summary>
        /// Order by, order by descending, then by, then by descending, reverse(not available)
        /// </summary>
        public static void Run()
        {
            int[] nums = { -20, 12, 6, 10, 0, -3, 1 };
            var query = from num in nums orderby num descending select num;

            foreach (int num in query)
                Console.WriteLine(num);

            List<Values> values = new List<Values>() { new Values { IntOne = 1, IntTwo = 22 }, new Values { IntOne = -1, IntTwo = -21 }, new Values { IntOne = 1, IntTwo = 21 } };
            var query2 = from val in values orderby val.IntOne, val.IntTwo descending select val;

            foreach (Values num in query2)
                Console.WriteLine(num.IntOne + " " + num.IntTwo);

            Console.ReadKey();
        }

        class Values
        {
            public int IntOne { get; set; }
            public int IntTwo { get; set; }
        }
    }
}
