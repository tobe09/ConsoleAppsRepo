using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class MediaStorage
    {
        //deegate to handle simulation of media file play
        public delegate int PlayMedia();

        public void reportResult(PlayMedia status)
        {
            int statusInt = status();
            if (statusInt >= 0) Console.WriteLine("The file played succesfully");
            else if (statusInt == -99999) Console.WriteLine("The operation was abandoned!");
            else if (statusInt < 0) Console.WriteLine("Error playing the file, the format was unsupported");
            else Console.WriteLine("Impossible"); //never going to happen, but you can not be too careful
        }

    }
}
