using System;

namespace TobeConsolePractise
{
    /// <summary>
    /// The publishing class for ClockObject
    /// </summary>
    class ClockObject
    {
        public ClockObject()
        {
            Month = DateTime.Now.Month;
            Day = DateTime.Now.Day;
            Second = DateTime.Now.Second;
        }

        public int Month { get; set; }
        public int Day { get; set; }
        public int Second { get; set; }

        public delegate void SecondChanged(ClockObject clk, EventArgs e);
        public event SecondChanged secondChanged;  //published event handler

        public void run()
        {
            Console.WriteLine("This will print the month, day and new second 5 times\r\n");
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                DateTime dt = System.DateTime.Now;
                if (secondChanged != null && dt.Second != Second)
                {
                    EventArgs e = new EventArgs();
                    secondChanged(this, e);
                }
                this.Month = dt.Month;
                this.Day = dt.Day;
                this.Second = dt.Second;
            }
        }
    }
}
