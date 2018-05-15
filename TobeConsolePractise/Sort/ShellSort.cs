using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class ShellSort : SortBase
    {
        public ShellSort(int length = 20, int minNo = 0, int maxNo = 1000) : base(length, minNo, maxNo) { }

        public ShellSort(List<int> values) : base(values) { }

        public override void Sort(bool showDetail = true)
        {
            int inner, outer, valueToInsert, interval = 1, max = Count(), i = 0, swaps = 0;

            while (interval <= max / 3)
                interval = interval * 3 + 1;

            while (interval > 0)
            {
                if (showDetail) Console.WriteLine("Iteration " + (i + 1));

                for (outer = interval; outer < max; outer++)
                {
                    valueToInsert = values[outer];
                    inner = outer;
                    while (inner >= interval && values[inner - interval] >= valueToInsert)
                    {
                        values[inner] = values[inner - interval];
                        inner -= interval;
                        swaps++;
                        if (showDetail) Console.WriteLine("Item moved: " + values[inner]);
                    }
                    values[inner] = valueToInsert;
                    if (showDetail) Console.WriteLine("Item inserted: {0}, at position: {1}", valueToInsert, inner);
                }
                interval = (interval - 1) / 3;
                i++;
            }
            Console.WriteLine("i: {1}, Total swaps: {0}", swaps, i);
        }

        public static void Run(int iteration = 200)
        {
            Run(new ShellSort(iteration), showDetail: false);
        }
    }
}
