using System;

namespace TobeConsolePractise.Variance
{
    class VarianceTest
    {
        delegate T Get<out T>();
        delegate void Set<in T>(T a);

        /// <summary>
        /// Input is determined by interface method signature and output is determined by implementing class method signature
        /// </summary>
        public static void Run()
        {
            //contravariance: all One methods can return strings which are valid objects
            //but they cannot take an object parameter from IOne interface because it may not be a valid string
            IOne<object> a = new One<string>();

            //covarince: all Two methods can accept strings arguments declared by ITwo<in T> which are valid objects
            //but they cannot return an object which they declare because it may not be a valid string in ITwo<in T>
            ITwo<string> b = new Two<object>();        

            Console.WriteLine("Value: " + a.Get(new Two<object>()));

            var c = new Set<int>((int obj) => { });
            c?.Invoke(5);

            var d = new Get<object>(() => "");
            d?.Invoke();
        }

        //can use T as method argument but not a s return type
        interface ITwo<in T>  
        {
            int Get(T a);
        }

        class Two<T> : ITwo<T>
        {
            public int Get(T a)
            {
                return 1;
            }
        }

        //can use T as return type but not as method argument
        interface IOne<out T> where T : class  
        {
            T Get(ITwo<T> two);
        }

        class One<T> : IOne<T> where T : class
        {
            public T Get(ITwo<T> b)
            {
                return default(T);
            }
        }
    }
}
