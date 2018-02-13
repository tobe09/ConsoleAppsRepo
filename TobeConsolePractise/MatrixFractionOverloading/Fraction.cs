using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TobeConsolePractise
{
    /// <summary>
    /// Create an instance of a fraction
    /// </summary>
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction() : this(1, 1) { }
        public Fraction(int num, int den)
        {
            this.Numerator = num;
            this.Denominator = den;
        }

        //Override operators
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            c.Denominator = a.Denominator * b.Denominator;
            return Fraction.lowestTerm(c);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            c.Denominator = a.Denominator * b.Denominator;
            return Fraction.lowestTerm(c);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = a.Numerator * b.Numerator;
            c.Denominator = a.Denominator * b.Denominator;
            return Fraction.lowestTerm(c);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction c = new Fraction();
            c.Numerator = a.Numerator * b.Denominator;
            c.Denominator = a.Denominator * b.Numerator;
            return Fraction.lowestTerm(c);
        }
        /// <summary>
        /// reduce a fraction to its lowest term
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction lowestTerm(Fraction a)
        {
            for (int i = 2; i <= Math.Abs(a.Numerator); i++)
            {
                if ((double)a.Numerator % i == 0 && (double)a.Denominator % i == 0)
                {
                    a.Numerator = a.Numerator / i;
                    a.Denominator = a.Denominator / i;
                    i = 1;  //because of increment
                }
            }
            return a;
        }

        //perform implicit casting from basic variable types to fraction
        public static implicit operator Fraction(int a) { return new Fraction(a, 1); }

        public static implicit operator Fraction(double a)
        {
            return Fraction.lowestTerm(new Fraction((int)((a * 100000000) - (a * 10000)), 100000000 - 10000));
        }

        public static implicit operator Fraction(string s)
        {
            while (!Regex.IsMatch(s, @"^(\+|\-)?\d+/\d+$"))
            {
                Console.Write("Please enter fraction in the correct format (i.e. x/y): ");
                s = Console.ReadLine();
            }
            Fraction a = new Fraction();
            int slash = s.LastIndexOf("/");
            a.Numerator = int.Parse(s.Substring(0, slash));
            a.Denominator = int.Parse(s.Substring(slash + 1));
            return a;
        }

        //perform implicit conversions from fraction to basic variable types
        public static implicit operator int(Fraction a) { return a.Numerator / a.Denominator; }
        public static implicit operator double(Fraction a) { return (double)a.Numerator / a.Denominator; }
        public override string ToString() { return this.Numerator + "/" + this.Denominator; }

        /// <summary>
        /// To test functionalities
        /// </summary>
        public static void run()
        {
            Console.WriteLine("An application to carry out arithmetic operations on fractions!\r\n");
            Console.WriteLine("What Operation do you wish to perform? ");
            Console.WriteLine("Enter '1' for addition, '2' for substraction,");
            Console.WriteLine("'3' for multiplication, '4' for division,");
            Console.WriteLine("'5' to change a fraction to a decimal, '6' to change a decimal to a fraction,");
            Console.WriteLine("and '7' to reduce a fraction to its lowest term.");
            string cont = "y";
            while (cont.ToUpper() == "Y" || cont.ToUpper() == "YES")
            {
                Console.Write("\r\nEnter the operation code for your operation: ");
                string chkInt = Console.ReadLine();
                while (!Regex.IsMatch(chkInt, "^(1|2|3|4|5|6|7)$") && chkInt.ToUpper() != "exit".ToUpper())
                {
                    Console.Write("Please enter an appropriate operation number (or 'exit' to stop program): ");
                    chkInt = Console.ReadLine();
                }
                if (chkInt.ToUpper() == "exit".ToUpper()) goto end;  //Environment.Exit(0);  
                int op = int.Parse(chkInt);
                Console.Write("\r\nOperation code: " + op);
                string ops = "";
                if (op == 1) ops = "Sum";
                else if (op == 2) ops = "Difference";
                else if (op == 3) ops = "Multiplication";
                else if (op == 4) ops = "Division";
                else if (op == 5) ops = "Convert fraction to decimal";
                else if (op == 6) ops = "Convert decimal to fraction";
                else ops = "Lowest term reduction";
                Console.WriteLine(" <=> (" + ops + " Operation).");
                Console.WriteLine("\r\nNOTE: You must enter a fraction in the form x/y\r\n");
                if (op >= 1 && op <= 4)
                {
                    Console.Write("Enter the first fraction: ");
                    Fraction a = Console.ReadLine();
                    Console.Write("\r\nEnter the second fraction: ");
                    Fraction b = Console.ReadLine();
                    Fraction c = new Fraction();
                    string sign = "";
                    if (op == 1) { c = a + b; sign = " + "; }
                    else if (op == 2) { c = a - b; sign = " - "; }
                    else if (op == 3) { c = a * b; sign = " * "; }
                    else { c = a / b; sign = " / "; }
                    Console.WriteLine("\r\nFirst Fraction: " + a.ToString());
                    Console.WriteLine("Second Fraction: " + b.ToString());
                    Console.WriteLine("Answer: " + c.ToString() + "\r\n");
                    Console.WriteLine(a.ToString() + sign + b.ToString() + " = " + c.ToString());
                }
                if (op == 5 || op == 6 || op == 7)
                {
                    if (op == 5)
                    {
                        Console.Write("Enter the fraction: ");
                        Fraction a = Console.ReadLine();
                        Console.WriteLine("\r\nThe decimal equivalent is: " + (double)a);
                    }
                    else if (op == 6)
                    {
                        Console.Write("Enter the decimal: ");
                        Fraction a = CheckClass.checkDouble(Console.ReadLine());
                        Console.WriteLine("\r\nThe decimal equivalent is: " + a.ToString());
                    }
                    else
                    {
                        Console.Write("Enter the unresolved fraction: ");
                        Fraction a = Console.ReadLine();
                        Console.WriteLine("\r\nThe resolved fraction is: {0}", Fraction.lowestTerm(a));
                    }
                }
                Console.Write("\r\nDo you wish to continue? Enter 'y' for yes and 'n' for no: ");
                cont = Console.ReadLine();
            }
        end: Console.WriteLine("\r\nTHE END!      (press any key to exit)");
            Console.ReadKey();
        }
    }
}
