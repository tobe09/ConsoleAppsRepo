using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class MergeSort : SortBase
    {
        public MergeSort(int length = 20, int minNo = 0, int maxNo = 1000) : base(length, minNo, maxNo) { }

        public MergeSort(List<int> values) : base(values) { }

        private List<int> _tempValues = new List<int>();
        private List<int> tempValues
        {
            get 
            {
                if (_tempValues.Count == 0)
                {
                    for (int i = 0; i < Count(); i++)
                        _tempValues.Add(0);
                }
                return _tempValues; 
            }
            set { tempValues = value; }
        }

        private void Merging(int low, int mid, int high)
        {
            int l1, l2, i;

            for (l1 = low, l2 = mid + 1, i = low; l1 <= mid && l2 <= high; i++)
            {
                if (values[l1] <= values[l2])
                    tempValues[i] = values[l1++];
                else
                    tempValues[i] = values[l2++];
            }

            while (l1 <= mid)
                tempValues[i++] = values[l1++];

            while (l2 <= high)
                tempValues[i++] = values[l2++];

            for (i = low; i <= high; i++)
                values[i] = tempValues[i];
        }

        private void Sort(int low, int high)
        {
            int mid;

            if (low < high)
            {
                mid = (low + high) / 2;
                Sort(low, mid);
                Sort(mid + 1, high);
                Merging(low, mid, high);
            }
            else
                return;
        }

        public override void Sort(bool showDetail = true)
        {
            Sort(0, Count() - 1);
        }

        public static void Run(int iteration = 200)
        {
            //SortBase.Run(new MergeSort(iteration), showDetail: false);
            var a = new MergeSort(new List<int> { 3, 5, 2, 44, 4, 7, 8, 96, 45, 63, 24, 56, 7, 8, 975, 456, 321, 34, 5 });
            a.Sort(false);
            a.PrintLine();
        }
    }
}
