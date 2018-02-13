using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    interface ISort
    {
        void Sort(bool showDetail = true);
    }

    abstract class SortBase : ISort
    {
        protected virtual List<int> values { get; set; }

        public static List<int> DefaultValues
        {
            get { return new List<int>() { 20, 30, 70, 0, 40, 50, 10, 90, 60, 80, 100, 110, 120, 170, 180, 190, 200, 130, 140, 150, 160 }; }
        }

        public SortBase(int length = 20, int minNo = 0, int maxNo = 1000)
        {
            values = new List<int>();

            Random rand = new Random();
            for (int i = 0; i < length; i++)
                values.Add(rand.Next(minNo, maxNo));
        }

        public SortBase(List<int> values)
        {
            this.values = values;
        }

        public virtual List<int> GetValues()
        {
            return values;
        }

        public virtual int Count()
        {
            return values.Count;
        }

        protected static void DashedLine(int count = 100)
        {
            for (int i = 0; i < count - 1; i++)
                Console.Write("=");
            Console.WriteLine("=\r\n");
        }

        public virtual void PrintLine()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string vals = "[";

            for (int i = 0; i < Count(); i++)
            {
                vals += values[i] + ", ";
            }

            if (vals.Length > 2) vals = vals.Remove(vals.Length - 2) + "]";

            return vals;
        }

        public virtual void Sort(bool showDetail = true)
        {
            throw new NotImplementedException();
        }

        public static void Run(SortBase sorter, List<int> values = null, bool showDetail = true)
        {
            System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine("Sort type: " + sorter.GetType().Name + "\r\n");
            SortBase list = sorter;
            if (values != null)
                list.values = values;
            Console.WriteLine("Unsorted Input List");
            list.PrintLine();

            Console.WriteLine("\r\nSorting...\r\n");
            list.Sort(showDetail);
            Console.WriteLine("\r\nSorted Output List");

            list.PrintLine();
            double time = stopWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine("\r\nTime taken: " + time + " milliseconds");
            DashedLine();

            Console.ReadKey();
        }
    }
}
