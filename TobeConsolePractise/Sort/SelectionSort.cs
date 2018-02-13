using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class SelectionSort : SortBase
    {
        public SelectionSort(int length = 20, int minNo = 0, int maxNo = 1000) : base(length, minNo, maxNo) { }

        public SelectionSort(List<int> values) : base(values) { }

        public override void Sort(bool showDetail = true)
        {
            int minIndex, max = Count(), swaps = 0;

            for (int i = 0; i < max - 1; i++)   //loop through all numbers
            {
                minIndex = i;           //set current index as min

                if (showDetail) Console.WriteLine("Iteration {0}", i + 1);
                for (int j = i + 1; j < max; j++)   //check for minimum element
                {
                    if (values[j] < values[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                {
                    int temp = values[minIndex];
                    values[minIndex] = values[i];
                    values[i] = temp;
                    swaps++;
                    if (showDetail) Console.WriteLine("Item swapped: {0} and {1}", values[i], values[minIndex]);
                }
                else
                    if (showDetail) Console.WriteLine("No Swap");
            }

            Console.WriteLine("Number of swaps: " + swaps);
        }

        public static void Run(int iteration = 200)
        {
            SortBase.Run(new SelectionSort(iteration), showDetail: false);
        }
    }
}
