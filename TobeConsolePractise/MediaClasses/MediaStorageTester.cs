using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class MediaStorageTester
    {
        //To test the delegate
        public static void run()
        {
            string check = "y";
            while (!(check == "exit" || check == "n"))
            {
                MediaStorage.PlayMedia audioDelegate = new MediaStorage.PlayMedia(AudioFile.playAudio);
                MediaStorage.PlayMedia videoDelegate = new MediaStorage.PlayMedia(VideoFile.playVideo);
                MediaStorage store = new MediaStorage();
                store.reportResult(audioDelegate); //non-static field needs object reference
                Console.WriteLine();
                store.reportResult(videoDelegate);
                Console.Write("\r\nEnter any character to continue (Enter 'exit' or 'n' to quit): ");
                check = Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
