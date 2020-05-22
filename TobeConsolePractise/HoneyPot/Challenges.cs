using System;
using System.Collections.Generic;
using System.Linq;

namespace TobeConsolePractise.HoneyPot
{
    class Challenges
    {
        public static void Run()
        {
            var value = HoneyPot("getltsrqjhe");             //get next greatest combination of alphabets
            Console.WriteLine(value);
            var result = HoneyPot2(new List<int>() { 1, 99, 5, 3, 7, 10, 14 });   //sort by binary 1's then by size if equal
            Console.WriteLine(string.Join(", ", result));
            var number = ConvertBaseToDecimal("214", 6);
            Console.WriteLine(number);
        }

        public static string HoneyPot(string word)
        {
            int length = word.Length;
            int index = -1;
            int replaceIndex = -1;

            for (int i = length - 1; i > 0; i--)
            {
                char current = word[i];
                char prev = word[i - 1];
                if (current > prev)
                {
                    index = i - 1;
                    char minCharFromIndex = current;
                    for (int j = i + 1; j < length; j++)
                    {
                        if (word[j] > prev && word[j] < minCharFromIndex)
                        {
                            replaceIndex = j;
                            minCharFromIndex = word[j];
                        }
                    }
                }

                if (index != -1)
                    break;
            }

            if (index == -1)
            {
                return "no answer";
            }
            else
            {
                string startWord = word.Substring(0, index) + word[replaceIndex];
                string unsortedEndWord = word.Substring(index, replaceIndex - index) + word.Substring(replaceIndex + 1);

                List<char> sortedEndWord = unsortedEndWord.QuickSort((a, b) => a.ToString().CompareTo(b.ToString()));
                string endWord = string.Join("", sortedEndWord);

                return startWord + endWord;
            }
        }

        public static List<int> HoneyPot2(List<int> elements)
        {
            List<BaseInfo> elementsGroup = elements
                .Select(i => GetBaseInfo(i))
                .ToList();

            var values = elementsGroup.QuickSort((a, b) =>
            {
                if (a.NoOfOnes != b.NoOfOnes)
                {
                    return a.NoOfOnes - b.NoOfOnes;
                }
                else
                {
                    if (a.Number != b.Number)
                        return a.Number - b.Number;
                    else
                        return 0;
                }
            });

            List<int> result = values.Select(x => x.Number).ToList();

            return result;
        }

        static BaseInfo GetBaseInfo(int number, int @base = 2)
        {
            if (@base < 2)
                throw new ArgumentOutOfRangeException("Enter a base greater than 2");

            string result = "";
            int onesCount = 0;
            double factor = (double)number / @base;

            while (factor > 0)
            {
                double wholeFactor = Math.Floor(factor);
                int remainder = (int)Math.Ceiling((factor - wholeFactor) * @base);

                result += remainder;

                if (remainder == 1)
                    onesCount += 1;

                factor = wholeFactor / @base;
            }

            result = string.Join("", result.Reverse());

            return new BaseInfo { Number = number, BaseValue = result, NoOfOnes = onesCount };
        }

        class BaseInfo
        {
            public int Number { get; set; }
            public string BaseValue { get; set; }
            public int NoOfOnes { get; set; }
        }

        static int ConvertBaseToDecimal(string baseValue, int @base = 2)
        {
            if (@base < 2)
                throw new ArgumentOutOfRangeException("Enter a base greater than 2");

            int result = 0;
            for (int i = baseValue.Length - 1; i >= 0; i--)
            {
                result += int.Parse(baseValue[i].ToString()) * (int)Math.Pow(@base, baseValue.Length - i - 1);
            }

            return result;
        }
    }

    public static class EnumerableHelper
    {
        public static List<T> QuickSort<T>(this IEnumerable<T> enumerable, Func<T, T, int> comparer)
        {
            List<T> values = enumerable.ToList();
            if (values.Count <= 1) return values;

            T pivot = values[0];
            List<T> lesser = new List<T>();
            List<T> greater = new List<T>();

            for (int i = 1; i < values.Count; i++)
            {
                T value = values[i];
                int comparison = comparer(value, pivot);

                if (comparison > 0)
                    lesser.Add(value);
                else
                    greater.Add(value);
            }

            List<T> less = QuickSort(lesser, comparer);
            List<T> great = QuickSort(greater, comparer);

            List<T> sortedArr = Concat(less, pivot, great);

            return sortedArr;
        }

        private static List<T> Concat<T>(IEnumerable<T> lesser, T pivot, IEnumerable<T> greater)
        {
            List<T> allValues = new List<T>();

            allValues.AddRange(lesser);
            allValues.Add(pivot);
            allValues.AddRange(greater);

            return allValues;
        }
    }
}