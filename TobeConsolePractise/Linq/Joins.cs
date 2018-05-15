using System;
using System.Collections.Generic;
using System.Linq;

namespace TobeConsolePractise
{
    class Joins
    {
        public static void Run()
        {
            ICollection<One> one = new List<One>();
            ICollection<Two> two = new List<Two>();
            ICollection<Three> three = new List<Three>();

            one.Add(new One { MyProperty1 = 1, MyProperty2 = "One1", MyProperty3 = true });
            one.Add(new One { MyProperty1 = 2, MyProperty2 = "One2", MyProperty3 = false });
            one.Add(new One { MyProperty1 = 3, MyProperty2 = "One3", MyProperty3 = true });

            two.Add(new Two { MyProperty1 = 1, MyProperty2 = "Two1", MyProperty3B = true });
            two.Add(new Two { MyProperty1 = 2, MyProperty2 = "Two2", MyProperty3B = true });
            two.Add(new Two { MyProperty1 = 3, MyProperty2 = "Two3", MyProperty3B = false });

            three.Add(new Three { MyProperty1 = 1, MyProperty2 = "Three1", MyProperty3C = true });
            three.Add(new Three { MyProperty1 = 2, MyProperty2 = "Three2", MyProperty3C = true });
            three.Add(new Three { MyProperty1 = 3, MyProperty2 = "Three3", MyProperty3C = false });

            var group = from o in one
                        join t in two
                        on o.MyProperty1 equals t.MyProperty1
                        into temp1
                        select temp1;

            var a = from o in one
                    join t in two
                    on new { o.MyProperty1, prop = o.MyProperty3 } equals new { t.MyProperty1, prop = t.MyProperty3B }
                    join t3 in three
                    on o.MyProperty3 equals t3.MyProperty3C
                    select new { o.MyProperty1, t3.MyProperty3C };

            var b = from o in one
                    from t in two
                    where o.MyProperty1 == t.MyProperty1
                    && o.MyProperty3 == t.MyProperty3B
                    select new { o.MyProperty1, t.MyProperty3B };

            Console.ReadKey();
        }
    }


    class One
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public bool MyProperty3 { get; set; }
    }

    class Two
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public bool MyProperty3B { get; set; }
    }

    class Three
    {
        public int MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public bool MyProperty3C { get; set; }
    }
}
