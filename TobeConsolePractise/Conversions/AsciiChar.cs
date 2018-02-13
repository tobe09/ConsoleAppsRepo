using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class AsciiChar
    {
        public static void EncDecode()
        {
            //not very secure
            string s = "Happy";
            byte[] sByteEnc = Encoding.ASCII.GetBytes(s + "a");
            Console.WriteLine(s + " was encoded as " + sByteEnc);
            string t = Encoding.ASCII.GetString(sByteEnc);
            t = t.Substring(0, t.Length - 1);
            Console.WriteLine(sByteEnc + " was decoded as " + t);
            Console.ReadKey();
        }

        public static void AsciiCharacters()
        {
            try
            {
                for (int i = 0; i <= 260; i++)  //ascii characters keep counting after 255 and are implicitly encoded and converted correctly
                {
                    char asciiChar = (char)i;
                    Console.WriteLine("Character " + i + ": " + asciiChar);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("\r\nException: " + ex.Message);
            }
            Console.ReadKey();
        }

        public static void run()
        {
            EncDecode();
            Console.WriteLine("\r\nNext Program\r\n");
            AsciiCharacters();
        }
    }
}
