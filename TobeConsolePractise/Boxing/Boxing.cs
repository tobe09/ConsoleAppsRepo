using System;
using System.Diagnostics;

namespace TobeConsolePractise
{
    public class Boxing
    {
        public static void run()
        {
            int freq = 100000000;
            Stopwatch stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < freq; i++)
            {
                object obj = 10;
                int objInt = (int)obj;
            }
            string time = stopWatch.Elapsed.Milliseconds.ToString();
            Console.WriteLine("Time elapsed for boxing/unboxing an integer, " + freq + " times: " + time + " milli-seconds");
            stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < freq; i++)
            {
                int obj = 10;
                int objInt = (int)obj;
            }
            time = stopWatch.Elapsed.Milliseconds.ToString();
            Console.WriteLine("Time elapsed for strongly typed assignment of an integer, " + freq + " times: " + time + " milli-seconds");
            Console.WriteLine("\r\nHence the need for strongly typed generic list for improved speed and to avoid boxing and unboxing.\r\n\r\nTHE END");
            Console.ReadKey();
        }
    }
}
