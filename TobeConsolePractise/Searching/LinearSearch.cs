
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class LinearSearch : Search
    {
        public LinearSearch(int start = 0, int end = 200, int margin = 10, int maxIndex = 99999999) : base(start, end, margin, maxIndex) { }

        public LinearSearch(List<int> values) : base(values) { }

        public override int Find(object data)
        {
            int intData = (int)data;
            int comparisons = 0, index = -1;

            for (int i = 0; i < Count(); i++)
            {
                comparisons++;
                if (intData == values[i])
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine("Comparisons made: " + comparisons);

            return index;
        }

        public static void Run()
        {
            System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            Search lsr = new LinearSearch(end :60000);
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
