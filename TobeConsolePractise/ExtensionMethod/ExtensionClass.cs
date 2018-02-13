using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// A class whose method is extended by MethodClass
    /// </summary>
    public static class ExtensionClass
    {
        public static double extSum(this MethodClass a, double b)
        {
            return a.A + a.B + b;
        }
    }
}
