using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; 

namespace TobeConsolePractise
{
    class VideoFile
    {
        //Simulating a video file playing experience
        public static int playVideo()
        {
            Console.WriteLine("A method that simulates playing of a video file!");
            Console.Write("Enter a positive integer for successful play and anything else for unsuccessful play: ");
            string playString = Console.ReadLine();
            while (!Regex.IsMatch(playString, @"(^(\+|\-)?\d+$)|exit|n"))
            {
                Console.Write("Please enter a positive or negative integer (Enter 'exit' or 'n' to exit): ");
                playString = Console.ReadLine();
            }
            if (playString == "exit" || playString == "n") return -99999;
            else
            {
                int playInt = int.Parse(playString);
                return playInt;
            }
        }
    }
}
