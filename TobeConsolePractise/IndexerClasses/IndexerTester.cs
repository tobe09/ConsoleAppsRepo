using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class IndexerTester
    {
        public static void run()
        {
            Indexer i1 = new Indexer();
            Indexer i2 = new Indexer(9);
            try
            {
                Console.WriteLine("This is a program to test indexing in a class.\r\n");
                Console.WriteLine("(Created without arguments)\t" + i1); //ToString not necessary because of override keyword
                Console.WriteLine("(Created with argument as 9)\t" + i2.ToString());
                i1[1] = 3; i1[2] = 4; i1[3] = 5;
                i2[1] = 7; i2[2] = 8; i2[3] = 9;
                Console.WriteLine("\r\nAfter setting values...\r\ni1: " + i1 + "\r\ni2:: " + i2+".\r\n");
                double a = i1[0];
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            finally
            {
                //i2[4] = 6;  //throws an error
            }
        }
    }
}
