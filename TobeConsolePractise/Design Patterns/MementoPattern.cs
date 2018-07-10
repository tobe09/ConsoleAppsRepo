using System;
using System.Collections.Generic;

namespace TobeConsolePractise.Design_Patterns
{
    class MementoPattern
    {
        public static void Run()
        {
            Test<int>.Dict.Add("one", 1);
            Test<string>.Dict.Add("one", "oneone");

            Console.WriteLine(Test<int>.Dict["one"]);
            Console.WriteLine(Test<string>.Dict["one"]);
        }

        class Test<T>
        {
            static Test()
            {
                Dict = new Dictionary<string, T>();
            }

            public static Dictionary<string, T> Dict { get; set; }
        }
    }
}
