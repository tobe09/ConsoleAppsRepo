using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public class DisplayClockObjectTester
    {

        /// <summary>
        ///A method to run the subscribed DisplayClockObject method
        /// </summary>
        public static void run()
        {
            ClockObject clk = new ClockObject();
            new DisplayClockObject().subscribe(clk);
            //DisplayClockObject dco = new DisplayClockObject(); dco.subscribe(clk); //also permissible
            clk.run();
            Console.ReadKey();
        }
    }
}
