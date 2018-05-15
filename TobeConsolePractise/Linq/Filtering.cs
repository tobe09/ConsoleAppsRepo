using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// Linq Types:
    /// 1. Linq to objects, xml(XLINQ), dataset, sql(DLINQ) entities. Also microsoft's parallel linq(PLINQ).
    /// </summary>
    class Filtering
    {
        /// <summary>
        /// Where 
        /// OfType(not applicable for syntax expression)
        /// </summary>
        public static void Run()
        {
            int[] list = { 2, 4, 3, 5, 1 };
            IEnumerable<int> query = from val in list where val != 3 orderby val select val + 2;
            IEnumerable<int> query2 = list.Where(val => val != 3).OrderBy(val => val).Select(val => val + 2).OfType<int>();     //added OfType
            Console.WriteLine(Equals(query, query2));
            Console.ReadKey();
        }

        public static bool Equals(IEnumerable<int> query, IEnumerable<int> query2)
        {
            bool equal = true;

            if (query.Count() == query2.Count())
            {
                int count = query.Count();

                for (int i = 0; i < count; i++)
                {
                    if (query.ElementAt(i) != query2.ElementAt(i))
                    {
                        equal = false;
                        break;
                    }
                }
            }
            else
                equal = false;

            return equal;
        }
    }
}
