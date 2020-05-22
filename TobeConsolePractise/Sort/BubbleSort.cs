using System;
using System.Collections.Generic;

namespace TobeConsolePractise
{
    class BubbleSort : SortBase
    {
        public BubbleSort(int length = 20, int minNo = 0, int maxNo = 1000) : base(length, minNo, maxNo) { }

        public BubbleSort(List<int> values) : base(values) { }

        public override void Sort(bool showDetail = true)
        {
            int max = Count(), swaps = 0;

            for (int i = 0; i < max - 1; i++)           //loop through values
            {
                if (showDetail) Console.WriteLine("\r\nIteration {0}", i + 1);
                bool swapped = false;
                for (int j = 0; j < max - i - 1; j++)   //loop through values ahead
                {
                    if (showDetail) Console.WriteLine("Item Compared: {0} and {1}", values[j], values[j + 1]);

                    if (values[j] > values[j + 1])      //check then swap and bubble if necessary
                    {
                        int temp = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = temp;

                        swapped = true;
                        swaps++;
                        if (showDetail) Console.WriteLine("Swapped {0} and {1}", values[j], values[j + 1]);
                    }
                    else
                        if (showDetail) Console.WriteLine("Not Swapped");
                }

                if (!swapped)               //completely sorted?
                    break;
            }
            Console.WriteLine("\r\nNumber of swaps: " + swaps);
        }

        public static void Run(int iteration = 200)
        {
            SortBase.Run(new BubbleSort(iteration), showDetail: false);
        }
    }
}
