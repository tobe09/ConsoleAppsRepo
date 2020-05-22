using System;
using System.Diagnostics;
using System.Linq;

namespace TobeConsolePractise
{
    class PalindromicNo
    {
        public string PalindromicNoThree(int start, int end)
        {
            string values = "";

            int largestProduct = 0;
            //begin from start number and loop till the end
            for (int outerLoop = start; outerLoop <= end; outerLoop++)
            {
                int product;
                //for each number in outerLoop, multiply with values
                for (int innerLoop = start; innerLoop <= end; innerLoop++)
                {
                    product = outerLoop * innerLoop;
                    string productStr = product + "";       //convert to string
                    string reverseProductStr = string.Join("", productStr.Reverse());
                    //check if the string is palindromic and the product is bigger than previous palindromic product
                    if (string.Equals(productStr, reverseProductStr) && product > largestProduct)
                    {
                        largestProduct = product;
                        values = largestProduct + "," + outerLoop + "," + innerLoop;        //save values to be returned
                    }
                }
            }

            return values;
        }

        public static void Run(int start = 100, int end = 999)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();         //start timing
            string values = new PalindromicNo().PalindromicNoThree(start, end);
            double time = stopWatch.Elapsed.TotalMilliseconds;
            string[] valuesArray = values.Split(',');           //generate values as an array
            Console.WriteLine("The largest palindromic product between " + start + " and " + end + " (for " + end.ToString().Length + "-digit numbers) is: " + valuesArray[0]);
            Console.WriteLine("The two numbers are: " + valuesArray[1] + " and " + valuesArray[2]);
            Console.WriteLine("Time taken: " + time + " milliseconds");
            Console.ReadKey();
        }
    }
}
