using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class GenericsTest
    {
        public static void Run()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            string defaultValues = numbers.ToString();
            string values = numbers.ToString<int>();

            Console.WriteLine(defaultValues);
            Console.WriteLine(values);
        }
    }

    public static class ExtensionGeneric
    {
        /// <summary>
        /// Returns a string representing the content of the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns>string</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="Exception"></exception>
        public static string ToString<T>(this List<T> list)
        {
            string stringValue = "[";

            foreach (T value in list)
            {
                stringValue += value + ", ";
            }
            stringValue = stringValue.Substring(0, stringValue.Length - 2) + "]";

            return stringValue;
        }
    }
}
