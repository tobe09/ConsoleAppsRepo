using System;
using System.Collections.Generic;

namespace TobeConsolePractise
{
    class WeekDay
    {
        public static void Run()
        {
            Console.WriteLine("DayOfWeek ENUMERATION");
            int a = (int)DayOfWeek.Monday;
            Console.WriteLine(DayOfWeek.Monday + ": " + a);
            a = (int)DayOfWeek.Saturday;
            Console.WriteLine(DayOfWeek.Saturday + ": " + a);
            a = (int)DayOfWeek.Sunday;
            Console.WriteLine(DayOfWeek.Sunday + ": " + a);
            Console.WriteLine("\r\nWeekDays ENUMERATION");
            a = (int)WeekDays.monday;
            Console.WriteLine(WeekDays.monday + ": " + a);
            a = (int)WeekDays.saturday;
            Console.WriteLine(WeekDays.saturday + ": " + a);
            a = (int)WeekDays.sunday;
            Console.WriteLine(WeekDays.sunday + ": " + a);
            Console.ReadKey();
        }
    }
}
