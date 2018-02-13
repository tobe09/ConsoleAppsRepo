using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public delegate void MessageOut(string str); //delegate declared outside the class, all delegates must be public

    class InstanceDelegate
    {
        public delegate void Message(string str);
        private string sender;
        public Message message;  //delegate instance needed for instance methods

        public InstanceDelegate() : this("Default sender", delegate(string s) { Console.WriteLine("Default Constructor.\r\n(Arg)s now holds- " + s + "\r\n"); }) { }
        public InstanceDelegate(string sender, Message aMessage)
        {
            this.sender = sender;  //'this' keyword can be used for instance methods, it can be ommitted since it is declared by the class
            message = aMessage; //subscription is not persistent
            //message("Message from: " + sender);  //'message' delegate called without the 'doSend' method
        }

        /// <summary>
        /// Show that an instance delegate can only be executed from an instance method
        /// </summary>
        public void doSend() { message("Message from: " + sender); }  //method has been published

        /// <summary>
        /// To execute the InstanceDelegate class statements
        /// </summary>
        public static void run()
        {
            Basic a = new Basic();
            InstanceDelegate messanger1 = new InstanceDelegate("Tobe", a.basicMethod);
            messanger1.doSend();
            InstanceDelegate messanger2 = new InstanceDelegate("Tobe", new Basic(10).basicMethod); //anonymous object
            messanger2.doSend();
            new InstanceDelegate().doSend();
            InstanceDelegate messanger3 = new InstanceDelegate("Anonymous", s => { Console.WriteLine("Anonymous method.\r\n(Arg)s now holds- " + s + "\r\n"); });
            messanger3.doSend();
            Console.ReadKey();
        }
    }

    class Basic
    {
        private int state;

        public Basic(int i) { state = i; }
        public Basic() : this(1) { }

        public void basicMethod(string s)
        { Console.WriteLine("Class Basic has (int)state value of: "+ state +".\r\n(Arg)s now holds- " + s + "\n"); }
    }
}
