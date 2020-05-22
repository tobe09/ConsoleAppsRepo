using System;

namespace TobeConsolePractise.Cousant
{
    class EncryptDecrypt
    {
        public static void Run()
        {
            Console.WriteLine("String encryption and decryption");
            string cont = "y";

            while (cont.ToLower() == "y" || cont.ToLower() == "yes")
            {
                Console.Write("\nEnter your string: ");
                string value = Console.ReadLine();
                Console.WriteLine();

                string encryptedText = Encrypt(value);
                Console.WriteLine("Encrypted: " + encryptedText);

                string clearText = Decrypt(encryptedText);
                Console.WriteLine("Decrypted: " + clearText);
                Console.WriteLine();

                Console.Write("Do you wish to continue (y/n): ");
                cont = Console.ReadLine();
            }

            Console.WriteLine("THE END");
        }

        static string Encrypt(string clearText)
        {
            string encryptedText = "";

            clearText = clearText.ToLower();
            foreach (char c in clearText)
            {
                string str = "";
                int beforeLetterA = 'a' - 1;
                int val = c - beforeLetterA;           //using ascii character notation
                if (val % 2 == 0)
                {
                    str += "e";
                    str += (val / 2);
                }
                else
                {
                    str += "o";
                    str += ((val * 3) + 1);
                }

                encryptedText += str;
            }

            return encryptedText;
        }

        static string Decrypt(string encryptedText)
        {
            string clearText = "";

            int i = 0;
            while (i < encryptedText.Length)
            {
                int j = i + 1;
                int temp = 0;

                if (encryptedText[i] == 'o' || encryptedText[i] == 'e')
                {
                    string val = "";        //temporary string value of digits

                    //get next digits
                    while (j < encryptedText.Length && encryptedText[j] != 'o' && encryptedText[j] != 'e')
                    {
                        val += encryptedText[j];
                        j++;
                    }

                    //reverse transformation
                    if (encryptedText[i] == 'o') temp = (int.Parse(val) - 1) / 3;
                    else temp = int.Parse(val) * 2;
                }

                char c = (char)(temp + 96);     //generate original character

                clearText += c;     //append character to cleartext
                i = j;              //move to next value
            }

            return clearText;
        }

    }
}