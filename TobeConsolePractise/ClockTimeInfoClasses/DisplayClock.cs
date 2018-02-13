using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// This class subscribes to the second changed event handler or delegate
    /// </summary>
    class DisplayClock
    {
        /// <summary>
        /// Subsribes to the second changed event
        /// </summary>
        /// <param name="theClock"></param>
        public void subscribe(Clock theClock)
        {
            theClock.secondChanged += timeHasChanged;
            //theClock.secondChanged += new Clock.SecondChangedHandler(timeHasChanged); This is the same
        }

        public void timeHasChanged(object theClock, TimeInfoEventArgs t)
        {
            Console.WriteLine("The time is {0}:{1}:{2}", t.Hour, t.Minute, t.Second);
        }
    }
}
