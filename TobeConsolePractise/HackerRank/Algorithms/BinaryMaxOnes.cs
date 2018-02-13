using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class BinaryMaxOnes
    {
        public string DecToBin(int n)
        {
            if (n < 1 || n > Math.Pow(10, 6)) throw new ArgumentOutOfRangeException();

            string bin = "";

            while (n > 1)
            {
                bin += n % 2;
                n = n / 2;
            }
            bin += n;

            IEnumerable<char> reverseBin = bin.Reverse();
            bin = "";
            foreach (var chr in reverseBin) bin += chr;

            return bin;
        }

        public int BinCountOnes(string bin)
        {
            int count = 0;
            int tempCount = 0;

            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == '1')
                {
                    tempCount++;
                }
                else
                {
                    if (tempCount > count) count = tempCount;
                    tempCount = 0;
                }
            }
            if (tempCount > count) count = tempCount;

            return count;
        }

        public static void Run()
        {
            try
            {
                Console.WriteLine("A PROGRAM TO DISPLAY MAXIMUM LENGTH OF CONSECUTIVE 1'S IN A BINARY NUMBER.");
                Console.Write("\r\nEnter a decimal number: ");
                string strValue = Console.ReadLine();

                int outInt;
                while (!int.TryParse(strValue, out outInt))
                {
                    Console.Write("Please enter a decimal number: ");
                    strValue = Console.ReadLine();
                }

                int value = int.Parse(strValue);
                string bin = new BinaryMaxOnes().DecToBin(value);
                Console.WriteLine("\r\nThe decimal number " + value + " in binary is: " + bin);

                int countOnes = new BinaryMaxOnes().BinCountOnes(bin);
                Console.WriteLine("The maximum number of consecutive one's is: " + countOnes);
            }
            catch(Exception ex)
            {
                Console.WriteLine("\r\n" + ex.Message);
                Console.WriteLine("(Accepted range is between 1 and 10^6 inclusiive");
            }
            Console.ReadKey();
        }
    }
}
