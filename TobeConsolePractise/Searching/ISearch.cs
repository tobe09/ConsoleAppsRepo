using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    interface ISearch
    {
        int Find(object Data);
    }

    abstract class Search : ISearch
    {
        protected List<int> values { get; set; }

        public Search(int start = 0, int end = 200, int margin = 10, int maxIndex = 9999)
        {
            values = new List<int>();
            for (int i = start; i <= end; i += margin)
            {
                values.Add(i);
                if (i > maxIndex)
                    break;
            }
        }

        public Search(List<int> values)
        {
            this.values = values;
        }

        public virtual int this[int position]
        {
            get { return values[position]; }
        }

        public virtual int Count()
        {
            return values.Count;
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

            vals = vals.Remove(vals.Length - 2) + "]";

            return vals;
        }

        public virtual void Sort(List<int> values = null)
        {
            if (values == null)
                values = this.values;

            int end = values.Count;
            for (int i = 0; i < end; i++)
            {
                for (int j = i + 1; j < end; j++)
                {
                    if (values[i] > values[j])
                    {
                        int tempValue = values[j];
                        values[j] = values[i];
                        values[i] = tempValue;
                    }
                }
            }
        }

        public virtual int Find(object data)
        {
            throw new Exception("Please override Find() method");
        }
    }
}
