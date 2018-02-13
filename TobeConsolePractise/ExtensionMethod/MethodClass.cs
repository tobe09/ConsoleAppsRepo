using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// A simple class to test extension methods in ExtensionClass
    /// </summary>
    public class MethodClass
    {
        public MethodClass() : this(0, 0) { } //3 and 4 are default values
        public MethodClass(double a, double b)
        {
            A = a;
            B = b;
        }
        public double A { get; set; }
        public double B { get; set; }
    }
}
