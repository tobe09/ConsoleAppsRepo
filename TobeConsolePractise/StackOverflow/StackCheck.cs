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
        const int stackSize = 1024800; // Approximate Maximum stack space for operation. Default?

        // The function is 84 bytes, but we need space to unwind the exception.
        const int spaceRequired = 1; //trying to push the limits of the stack, it passed

        public unsafe static void Test()
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
                if (remaining < spaceRequired)
                {
                    throw new Exception("The number of recursions is: " + n);
                }
                n++;
                recurse();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
