using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// An EventHandler class to hold time events
    /// </summary>
    class TimeInfoEventArgs : EventArgs
    {
        private int hour;
        private int minute;
        private int second;

        public int Hour { set { hour = value; } get { return hour; } }
        public int Minute { set { minute = value; } get { return minute; } }
        public int Second { set { second = value; } get { return second; } }

        //public TimeInfoEventArgs() { }  //default constructor is overwritten except explicitly declared

        public TimeInfoEventArgs(int h, int m, int s) //overloaded constructor, overwites the default construtor
        {
            this.Hour = h;
            this.Minute = m;
            this.Second = s;
        }
    }
}
