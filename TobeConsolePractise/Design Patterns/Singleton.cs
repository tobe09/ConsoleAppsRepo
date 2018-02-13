using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object padLock = new object();

        public int id = 1;
        public string description = "First Singleton";

        private Singleton() { }

        //Single access via property using double check locking (for thread safety)
        public static Singleton getInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock ("") { if (_instance == null) _instance = new Singleton(); }
                }
                return _instance;
            }
        }
    }

    public class TestSingleton
    {
        Singleton instanceOne = Singleton.getInstance;
        Singleton instanceTwo = Singleton.getInstance;

        public void testSingletonUniqueness()
        {
            instanceOne.id = 2;
            instanceOne.description = "Modified";
            Console.WriteLine("instanceOne:   id= " + instanceOne.id + ", description= " + instanceOne.description);
            Console.WriteLine("instanceTwo:   id= " + instanceTwo.id + ", description= " + instanceTwo.description);
        }

        public static void run()
        {
            new TestSingleton().testSingletonUniqueness();
            Console.ReadKey();
        }
    }
}
