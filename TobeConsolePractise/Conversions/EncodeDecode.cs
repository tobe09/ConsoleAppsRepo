using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class EncodeDecode
    {
        public static void Run()
        {
            string originalText = "PEOPLEPLUSNEW";
            string cipherText = Encrypt(originalText);
            string decodedText = Decrypt(cipherText);

            Console.WriteLine("Original Text: " + originalText);
            Console.WriteLine("Cipher Text: " + cipherText);
            Console.WriteLine("Decoded Text: " + decodedText);
        }

        public static string Encrypt(string clearText)
        {
            string cipherText = "";

            for (int i = 0; i < clearText.Length; i++)
            {
                cipherText += (char)(clearText[i] + 10);
            }

            return cipherText;
        }

        public static string Decrypt(string cipherText)
        {
            string clearText = "";

            for (int i = 0; i < cipherText.Length; i++)
            {
                clearText += (char)(cipherText[i] - 10);
            }

            return clearText;
        }
    }
}
