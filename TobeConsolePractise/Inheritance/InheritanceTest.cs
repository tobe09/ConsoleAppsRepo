using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class InheritanceTest
    {
        class a
        {
            protected int aa = 5;
        }

        class b : a
        {
            protected int bb = 5;
            int c = new b().aa;
        }

    }

    abstract class c
    {
        //force the inheriting class to implement the method
        protected abstract int ss();

        //Note: Abstract methods in an abstract class and partial methods in a partial class. Extern methods from an external source.
    }

    class d : c
    {
        protected override int ss() { return 1; }
        public void Run()
        {
            Console.WriteLine(ss());
            Console.ReadKey();
        }
    }
}
