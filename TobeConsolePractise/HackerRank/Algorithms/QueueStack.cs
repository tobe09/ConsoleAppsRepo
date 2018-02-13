using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class QueueStack
    {
        static Stack<object> _top = new Stack<object>();
        static Stack<object> Top
        {
            get { return _top; }
            set { _top = value; }
        }

        static Stack<object> _bottom = new Stack<object>();
        static Stack<object> Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        public static void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] value = Console.ReadLine().Split(' ');
                int operation = int.Parse(value[0]);

                if (operation == 1) Enqueue(value[1]);
                else if (operation == 2) Dequeue();
                else Console.WriteLine(Peek());
            }
        }

        public static void Enqueue(object value)
        {
            Top.Push(value);
        }

        public static object Peek()
        {
            Adjust();
            return Bottom.Peek();
        }

        public static object Dequeue()
        {

            Adjust();
            return Bottom.Pop();

        }

        public static void Adjust()
        {
            if (Bottom.Count == 0)
                while (Top.Count > 0)
                    Bottom.Push(Top.Pop());
        }

        public static void Run(int diff)
        {
            Enqueue(1);
            Enqueue(2);
            Enqueue(3);
            Enqueue(4);
            Dequeue();
            Dequeue();
            Peek();
            Enqueue(5);
            Enqueue(6);
            Dequeue();
            Peek();
            Enqueue(7);
            Enqueue(8);
            Dequeue();
            Dequeue();
            Dequeue();
            Peek();
            Console.ReadKey();
        }
    }
}
