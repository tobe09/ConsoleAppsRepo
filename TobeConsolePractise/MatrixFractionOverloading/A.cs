using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{

    interface I
    {
        void Show();
    }

    partial class A : I
    {
        public virtual void Show() { Console.WriteLine("A"); }
    }
    partial class B : A
    {
        public override void Show() { Console.WriteLine("B"); }
    }


    partial class A
    {
        public virtual void show() { Console.WriteLine("Class A"); }
    }
    partial class B
    {
        public new void show() { Console.WriteLine("Class new B"); }
        public void show(string a) { Console.WriteLine("Class B: "+a); }
    }
    partial class C:A
    {
        public override void show() { Console.WriteLine("Class C"); }
    }
    class ATester
    {
        public static void run()
        {
            A a1 = new A();
            a1.show();
            A a2 = new B();
            a2.show();
            A a3 = new C();
            a3.show();
            B b1 = new B();
            b1.show("yes");

            I i1 = new A();
            i1.Show();
            Console.ReadKey();
        }
    }
}
