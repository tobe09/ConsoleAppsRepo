using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public class DisplayClockTester
    {
        /// <summary>
        /// A method to run the timer delegate
        /// </summary>
        public static void run()
        {
            Clock theClock = new Clock(); // create a new clock
            DisplayClock dc = new DisplayClock(); // Create the display 
            dc.subscribe(theClock);  //Tell it to subscribe to the clock just created
            LogCurrentTime lct = new LogCurrentTime();  // create a Log object and tell it to subscribe to the clock
            lct.subscribe(theClock);  //Tell it to subscribe to the clock just created
            theClock.run(); //Run the clock
            //DateTime dt = System.DateTime.Now.AddHours(2);
            //TimeInfoEventArgs t = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);
            //theClock.secondChanged(theClock, t); //will not compile for an event delegate
            Console.ReadKey();
        }
    }
}
