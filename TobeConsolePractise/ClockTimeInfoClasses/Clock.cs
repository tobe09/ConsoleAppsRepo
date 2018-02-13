using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// The Clock class which publishes the time event
    /// </summary>
    class Clock
    {
        int hour;
        int minute;
        int second;
        public delegate void SecondChangedHandler(object clock, TimeInfoEventArgs timeInfo); //
        public SecondChangedHandler secondChanged; //instance of handler delegate

        /// <summary>
        /// This will raise an event and run every half a second
        /// </summary>
        public void run()
        {
            Console.WriteLine("This will print the time 5 times\r\n");
            for (int count = 0; count < 5; count++) //same as for (; ; )
            {
                System.Threading.Thread.Sleep(1000); //sleep 0.5 seconds
                System.DateTime dt = System.DateTime.Now; //get the time
                if (dt.Second != second) //if second changed, notify subscribers
                {
                    //TimeInfoEventArgs timeInfo1 = new TimeInfoEventArgs(); //default constructor
                    TimeInfoEventArgs timeInfo = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second); //overloaded constructor
                    if (secondChanged != null)
                    {
                        secondChanged(this, timeInfo);
                    }
                }
                this.hour = dt.Hour;
                this.minute = dt.Minute;
                this.second = dt.Second;
            }
        }
    }
}
