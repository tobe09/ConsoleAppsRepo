using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// This class writes a log to the console using the subscribe method
    /// </summary>
    class LogCurrentTime
    {
        /// <summary>
        /// Subsribes to the second changed event and logs the time (does not really log it, just for simulation purposes)
        /// </summary>
        /// <param name="theClock"></param>
        public void subscribe(Clock theClock)
        {
            //theClock.secondChanged += new Clock.SecondChangedHandler(writeLogEntry); //This is the same as below
            theClock.secondChanged += writeLogEntry;
            //This is an anonymous method
            theClock.secondChanged += delegate(object Clock, TimeInfoEventArgs ti) //ti gets its values from TimeInfoEventArgs class
            {
                Console.WriteLine("Anonymous time: {0}:{1}:{2}", ti.Hour, ti.Minute, ti.Second);
            };
            //Other styles of passing methods to a delegate include; lambda expressions. The syntax is shown below
            //theClock.secondChanged += (object Clock, TimeInfoEventArgs t) => { };
        }
        public void writeLogEntry(object theClock, TimeInfoEventArgs t)
        {
            Console.WriteLine("Logging the current time: {0}:{1}:{2}", t.Hour, t.Minute, t.Second);
        }
    }
}
