using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    /// <summary>
    /// Indexer usage to treat a class as an array
    /// </summary>
    class Indexer
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Indexer() { }  //: this(0) { } //the '0' in 'this' is also the default value so no need for inheritance 
        public Indexer(double d) { A = B = C = d; }

        public double this[int i]
        {
            get
            {
                if (i == 1) return A;
                else if (i == 2) return B;
                else if (i == 3) return C;
                else throw new Exception("An index error has occured in getting values!");
            }
            set
            {
                switch (i)
                {
                    case 1: { A = value; break; }
                    case 2: { B = value; break; }
                    case 3: { C = value; break; }
                    default: throw new Exception("An index error has occured in setting values!");
                }
            }
        }

        public override string ToString()  { return "The values of A, B and C are: " + A + ", " + B + " and " + C + "."; }  //override keyword completely removes the deafault ToString class
    }
}
