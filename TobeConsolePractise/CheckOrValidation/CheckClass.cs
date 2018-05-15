using System;

namespace TobeConsolePractise
{
    class CheckClass
    {
        public static int checkInt(string s)
        {
            int val;
            while (!int.TryParse(s, out val))
            {
                Console.Write("Please enter a valid integer: ");
                s = Console.ReadLine();
            }
            return val;
        }

        public static double checkDouble(string s)
        {
            double val;
            while (!double.TryParse(s, out val))
            {
                Console.Write("Please enter a valid number: ");
                s = Console.ReadLine();
            }
            return val;
        }
    }
}
