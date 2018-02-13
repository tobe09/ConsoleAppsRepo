using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    interface aaa
    {
        void Print();
    }

    //explicitly implementing an interface
    class aaaa : aaa
    {
        void aaa.Print()
        {
            Console.WriteLine("Hello a");
            Console.ReadKey();
        }
        public virtual void Print()
        {
        }
    }

    class bbbb : aaaa, aaa
    {
        void aaa.Print()
        {
        }

        public override void Print()
        {
            Console.WriteLine("Hello b");
            Console.ReadKey();
        }
    }
}
