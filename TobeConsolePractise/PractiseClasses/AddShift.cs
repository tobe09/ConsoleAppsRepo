using System;

namespace TobeConsolePractise
{
    class AddShift
    {
        public static void Run()
        {
            int sum = Add(5, 6);
            Console.WriteLine(sum);
            int sum1 = Add1(5, 6);
            Console.WriteLine(sum1);
            int sum2 = AddI(5, 6);
            Console.WriteLine(sum2);
            int sum3 = AddR(5, 6);
            Console.WriteLine(sum3);
        }

        static int Add(int x, int y)
        {
            // Iterate till there is no carry
            while (y != 0)
            {
                // carry now contains common
                // set bits of x and y
                int carry = x & y;

                // Sum of bits of x and 
                // y where at least one 
                // of the bits is not set
                x = x ^ y;

                // Carry is shifted by 
                // one so that adding it 
                // to x gives the required sum
                y = carry << 1;
            }
            return x;
        }

        //basic add
        static int Add1(int x, int y)
        {
            int a, b;
            do
            {
                a = x & y;
                b = x ^ y;
                x = a << 1;
                y = b;
            } while (x > 0);

            return b;
        }

        // Recursive solution
        static int AddR(int x, int y)
        {

            if (y == 0) return x;
            int sum = x ^ y; //SUM of two integer is X XOR Y
            int carry = (x & y) << 1;  //CARRY of two integer is X AND Y

            return AddR(sum, carry);
        }

        //Iterative solution
        static int AddI(int x, int y)
        {
            while (y != 0)
            {
                int carry = (x & y); //CARRY is AND of two bits
                x = x ^ y; //SUM of two bits is X XOR Y
                y = carry << 1; //shifts carry to 1 bit to calculate sum
            }

            return x;
        }
    }
}
