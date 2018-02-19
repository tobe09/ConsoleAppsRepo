
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class QuickSort : SortBase
    {
        public QuickSort(int length = 20, int minNo = 0, int maxNo = 1000) : base(length, minNo, maxNo) { }

        public QuickSort(List<int> values) : base(values) { }

        private void swap(int num1, int num2)
        {
            int temp = values[num1];
            values[num1] = values[num2];
            values[num2] = temp;
        }

        private int Partition(int left, int right, int pivot, bool showDetail)
        {
            int leftPointer = left - 1;
            int rightPointer = right;

            while (true)
            {
                while (values[++leftPointer] < pivot) { }   //do nothing
                while (rightPointer > 0 && values[--rightPointer] > pivot) { }  //do nothing

                if (leftPointer >= rightPointer)
                    break;
                else
                {
                    if (showDetail) Console.WriteLine("Item swapped: {0}, {1}", values[leftPointer], values[rightPointer]);
                    swap(leftPointer, rightPointer);
                }
            }

            if (showDetail) Console.WriteLine("Pivot swapped: {0}, {1}\n\r", values[leftPointer], values[right]);
            swap(leftPointer, right);
            if (showDetail)
            {
                Console.WriteLine("Updated Array: \n");
                PrintLine();
            }

            return leftPointer;
        }

        private void Sort(int left, int right, bool showDetail)
        {
            if (right <= left)
                return;
            else
            {
                int pivot = values[right];
                int partitionPoint = Partition(left, right, pivot, showDetail);
                Sort(left, partitionPoint - 1, showDetail);
                Sort(partitionPoint + 1, right, showDetail);
            }
        }

        public override void Sort(bool showDetail = true)
        {
            Sort(0, Count() - 1, showDetail);
        }

        //Basic quick sort algorithm
        static int[] QuickSortBasic(int[] arr)
        {
            if (arr.Length <= 1) return arr;

            int pivot = arr[0];
            List<int> lesser = new List<int>();
            List<int> greater = new List<int>();

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < pivot)
                {
                    lesser.Add(arr[i]);
                }
                else
                {
                    greater.Add(arr[i]);
                }
            }

            int[] less = QuickSortBasic(lesser.ToArray());
            int[] great = QuickSortBasic(greater.ToArray());

            int[] sortedArr = Concat(less, pivot, great);

            return sortedArr;
        }

        static int[] Concat(int[] lesser, int pivot, int[] greater)
        {
            int[] concatArr = new int[lesser.Length + greater.Length + 1];

            for (int i = 0; i < lesser.Length; i++)
            {
                concatArr[i] = lesser[i];
            }

            concatArr[lesser.Length] = pivot;

            for (int i = 0; i < greater.Length; i++)
            {
                int pos = lesser.Length + i + 1;
                concatArr[pos] = greater[i];
            }

            return concatArr;
        }

        public static void Run(int iteration = 200)
        {
            //SortBase.Run(new QuickSort(iteration), null, false);
            var a = new QuickSort(new List<int> { 3, 5, 2, 44, 4, 7, 8, 96, 45, 63, 24, 56, 7, 8, 975, 456, 321, 34, 5 });
            a.Sort(false);
            a.PrintLine();
        }
    }
}
