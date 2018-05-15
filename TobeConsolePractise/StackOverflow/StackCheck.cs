using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class StackCheck
    {
        static int n;      
        static int topOfStack;
        //stack size is 1MB (1024576) but space is required for the stack to unwind and for the runtime to perform other operations
        static int stackSize = 1024800; 
        static bool printed = false;    //to display basic info once

        // The function is 84 bytes, but we need space to unwind the exception.
        const int spaceRequired = 120;      //no definitive

        public unsafe static void Run()
        {
            int var;
            topOfStack = (int)&var;

            n = 0;
            recurse();
        }

        unsafe static void recurse()
        {
            try
            {
                int remaining;
                int spaceUsed = (topOfStack - (int)&remaining);
                remaining = stackSize - spaceUsed;

                if (remaining < spaceRequired && !printed)
                {
                    Console.WriteLine("Stack Limit set: " + stackSize);
                    Console.WriteLine("The number of recursions is: " + n);
                    Console.WriteLine();
                    printed = true;
                    return;       //end without testing the stack limit (which leads to stack overflow exception)
                }

                if (spaceUsed > stackSize)
                {
                    Console.WriteLine("New Limit: " + spaceUsed);       //to push the limit of the stack (ends with a stack overflow exception)
                }

                n++;
                recurse();
            }
            catch (Exception ex)        //cannot catch a stack overflow exception
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
