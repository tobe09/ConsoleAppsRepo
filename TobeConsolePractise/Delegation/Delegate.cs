using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class DelegatePractise
    {
        delegate int Mdel();        //multicastdelegate returns void

        public static void Run()
        {
            Mdel m = (new Mdel(() =>
            {
            Console.WriteLine("One");
                return 1;
            })) + (new Mdel(() =>
            {
                Console.WriteLine("Two");
                return 2;
            }));
            m();
        }
    }
}
