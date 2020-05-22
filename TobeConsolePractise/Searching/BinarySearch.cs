using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class BinarySearch : Search
    {
        public BinarySearch(int start = 0, int end = 200, int margin = 10, int maxIndex = 99999999) : base(start, end, margin, maxIndex) { }

        public BinarySearch(List<int> values) : base(values) { }

        private int MidPoint(int lowerBound, int upperBound)
        {
            return lowerBound + ((upperBound - lowerBound) / 2);
        }

        public override int Find(object data)
        {
            int intData = (int)data;
            int lowerBound = 0, upperBound = Count() - 1, comparisons = 0, index = -1;

            while (lowerBound <= upperBound)
            {
                comparisons++;
                Console.WriteLine("Comparison " + comparisons);
                Console.WriteLine("LowerBound: {0}, Values[{1}]: {2}", lowerBound, lowerBound, values[lowerBound]);
                Console.WriteLine("UpperBound: {0}, Values[{1}]: {2}", upperBound, upperBound, values[upperBound]);

                int midPoint = MidPoint(lowerBound, upperBound);

                if (values[midPoint] == intData)        //data found
                {
                    index = midPoint;
                    break;
                }
                else if (values[midPoint] < intData)    //value is larger
                    lowerBound = midPoint + 1;          //data in lower half
                else
                    upperBound = midPoint - 1;
            }

            Console.WriteLine("Comparisons made: " + comparisons);

            return index;
        }

        public static void Run()
        {
            System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            Search lsr = new BinarySearch(0, 60000);
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
