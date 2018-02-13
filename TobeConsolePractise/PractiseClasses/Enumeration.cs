using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{

    //default assignment starts from 1 for enumeration
    public enum WeekDays : byte
    {
        monday = 1, tuesday, wednesday, thursday, friday, saturday, sunday
    }

    /// <summary>
    /// Practise yield and ienumerable
    /// </summary>
    class Practise  //c# support disparate class name and class file name
    {
        internal static List<int> myList = new List<int>();
        internal static int p = 3; //Field p no internal by default
        //public static const int pp=5; //cannot be changed

        /// <summary>
        /// Fill up the list
        /// </summary>
        /// <param name="valueLength"></param>
        /// <returns>Created List</returns>
        internal static string fillWithValues(int valueLength)
        {
            myList.Clear();
            string stringValue = "\r\nContent(s) of list= {";
            Console.WriteLine();
            for (int i = 0; i < valueLength; i++)
            {
                Console.Write("Entry " + (i + 1) + ": ");
                myList.Add(int.Parse(Console.ReadLine()));
                stringValue += myList.Last() + ", ";
            }
            return stringValue.Remove(stringValue.Length - 2) + "}";
        }

        /// <summary>
        /// Using IEnumerable to yeild control to calling class
        /// </summary>
        /// <returns>Cosecutive sums</returns>
        public static IEnumerable<string> addListReturn()
        {
            int total = 0;
            int count = 1;
            Console.WriteLine("\r\nTheir sum is: ");
            foreach (int i in myList)
            {
                total += i;
                yield return "Sum " + count + "= " + total;
                count++;
            }
        }

        /// <summary>
        /// Filtering values with yeild
        /// </summary>
        /// <returns>Values greater than 3</returns>
        public static IEnumerable<int> greaterThanThree()
        {
            Console.Write("\r\nThe values greater than 3 are: ");
            foreach (int i in myList)
            {
                if (i > 3) yield return i;
                //yield break; To automatically return control to the calling code
            }
        }

        public static void run()
        {
            //Testing yeild and IEnumerable
            Console.WriteLine("This will Iteratively add values in an array");
            Console.Write("Enter the number of values to add: ");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(fillWithValues(count)); //static method does not need "this" keyword
            foreach (string i in Practise.addListReturn()) Console.WriteLine(i); //returning strings
            Console.WriteLine("\r\n\r\nThis will only display numbers greater than 3");
            Console.Write("Enter the number of values you wish to test with: ");
            int countTest = int.Parse(Console.ReadLine());
            Console.WriteLine(Practise.fillWithValues(countTest));
            foreach (int i in Practise.greaterThanThree()) Console.WriteLine(i); //returning integers
            Console.Write("\r\n\n\rEnum tuesday (from code definition) is: " + (int)WeekDays.tuesday + "\r\n\r\n"); //testing enumurations
            //Practise pr = new Practise(); //new instance 
            //Practise.pp=6; //impossible                       //this four cooments represents
            //Practise.p = 5; //access field p                  //attempts to access from main method
            //Console.WriteLine(Practise.p); //print p works
            Console.ReadKey();

            Test a = Test.a;
            int aa = (int)a;
            Console.WriteLine(aa);
            Test b = (Test)4;
            Console.WriteLine((int)b + ", " + b);
            Test c = (Test)5;
            Console.WriteLine(c);
            Test d = (Test)6;
            Console.WriteLine((int)d + ", " + d);
            Console.ReadKey();
        }

        public enum Test { a = 1, b = 4, c }
    }
}
