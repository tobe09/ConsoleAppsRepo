using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Projection
    {
        /// <summary>
        /// Select
        /// Select Many
        /// </summary>
        public static void Run()
        {
            string[] words ={ "an", "apple", "a", "day" };
            var query = from word in words select word.Substring(0, 1);

            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };
            var query2 = from phrase in phrases from word in phrase.Split(' ') select word.Substring(0, 1);

            foreach (string str in query)
                Console.WriteLine(str);

            foreach (string str in query2)
                Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
