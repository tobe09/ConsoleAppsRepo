using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class InterpolationSearch : Search
    {
        public InterpolationSearch(int start=0, int end = 200, int margin = 10, int maxIndex = 99999999) : base(start, end, margin, maxIndex) { }

        public InterpolationSearch(List<int> values) : base(values) { }

        private int Mid(int data, int low, int high)
        {
            return low + ((high - low) * (data - values[low]) / (values[high] - values[low]));
        }

        public override int Find(object data)
        {
            int intData = (int)data;
            int low = 0, high = Count() - 1, mid = -1, comparisons = 0, index = -1;

            while (low <= high)
            {
                comparisons++;
                Console.WriteLine("Comparison " + comparisons);
                Console.WriteLine("Low: {0}, Values[{1}]: {2}", low, low, values[low]);
                Console.WriteLine("High: {0}, Values[{1}]: {2}", high, high, values[high]);

                mid = Mid(intData, low, high);
                Console.WriteLine("Mid :" + mid);

                if (values[mid] == intData)
                {
                    index = mid;
                    break;
                }
                else if (values[mid] < intData)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            Console.WriteLine("Total Comparisons Made: " + comparisons);

            return index;
        }

        public static void Run()
        {
            System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            Search lsr = new InterpolationSearch(0, 60000);
            Console.WriteLine("Values in the List:");
            lsr.PrintLine();
            Console.WriteLine();
            Console.WriteLine("Value at position 4: " + lsr[4]);
            Console.WriteLine();
            Console.WriteLine("Find index of data 13?");
            Console.WriteLine("Index: " + lsr.Find(13));
            Console.WriteLine();
            Console.WriteLine("Find index of data 50000?");
            Console.WriteLine("Index: " + lsr.Find(50000));
            double time = stopWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("\r\nTime taken: " + time + " milliseconds");
            Console.ReadKey();
        }
    }
}
