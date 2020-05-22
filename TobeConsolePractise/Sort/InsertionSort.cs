using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class InsertionSort : SortBase
    {
        public InsertionSort(int length = 20, int minNo = 0, int maxNo = 1000) : base(length, minNo, maxNo) { }

        public InsertionSort(List<int> values) : base(values) { }

        public override void Sort(bool showDetail = true)
        {
            int max = Count(), swaps = 0;

            for (int i = 0; i < max; i++)
            {
                int valueToInsert = values[i];
                int holePosition = i;

                if (showDetail) Console.WriteLine("Iteration {0}", (i + 1));
                while (holePosition > 0 && values[holePosition - 1] > valueToInsert)    //check previous number with value to insert
                {
                    values[holePosition] = values[holePosition - 1];
                    holePosition--;
                    swaps++;
                    if (showDetail) Console.WriteLine("Item moved: " + values[holePosition]);
                }

                if (holePosition != i)
                {
                    if (showDetail) Console.WriteLine("Item inserted: {0} at position {1}", valueToInsert, holePosition);
                    values[holePosition] = valueToInsert;       //insert the number at hole position
                }
            }

            Console.WriteLine("Number of swaps: " + swaps);
        }

        public static void Run(int iteration = 200)
        {
            SortBase.Run(new InsertionSort(iteration), showDetail: false);
        }
    }
}
