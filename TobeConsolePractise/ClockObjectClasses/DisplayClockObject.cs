using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// Subscriber to ClockObject event handler
    /// </summary>
    class DisplayClockObject
    {
        public void subscribe(ClockObject clk)
        {
            clk.secondChanged += timeChange; //made static to enable referencing
            //theClock.secondChanged += new Clock.SecondChangedHandler(timeHasChanged); This is the same
        }

        public void timeChange(ClockObject clk, EventArgs t)
        {
            Console.WriteLine("The new time values are (month), (day) and (second): {0}:{1}:{2}", clk.Month, clk.Day, clk.Second);
        }
    }
}
