using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class HashTable
    {
        public static void Run()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int money = Convert.ToInt32(Console.ReadLine());
                int n = Convert.ToInt32(Console.ReadLine());
                string[] arr_temp = Console.ReadLine().Split(' ');
                int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
                Solve(arr, money);
            }

            Console.ReadKey();
        }

        static void Solve(int[] arr, int money)
        {
            HashMap<int, int> set = new HashMap<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int complement = money - arr[i];
                if (set.ContainsKey(complement))
                {
                    Console.WriteLine((set[complement] + 1) + " " + (i + 1));
                    return;
                }
                set.Add(arr[i], i);
            }
        }

        static int[] IceCreamParlor(int m, int[] arr)
        {
            int[] values = new int[2];

            HashMap<int, int> set = new HashMap<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int complement = m - arr[i];
                if (set.ContainsKey(complement))
                {
                    values[0] = set[complement] + 1;
                    values[1] = i + 1;
                    break;
                }
                set.Add(arr[i], i);
            }

            return values;
        }

        class HashMap<TKey, TVal>      
        {
            private Dictionary<TKey, TVal> _dict;
            
            public HashMap()
            {
                _dict = new Dictionary<TKey, TVal>();
            }

            public TVal this[TKey key]
            {
                get { return _dict[key]; }
            }

            public bool ContainsKey(TKey key)
            {
                return _dict.ContainsKey(key);
            }

            public void Add(TKey key, TVal i)
            {
                if (!_dict.ContainsKey(key))
                    _dict.Add(key, i);
            }
        }
    }
}
