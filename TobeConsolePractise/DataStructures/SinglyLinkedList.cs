using System;

namespace TobeConsolePractise.DataStructures
{
    class SinglyLinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }

        public static void Run()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Remove(1);
            list.Remove(1);
            list.Remove(3);
            list.Remove(5);
            list.Clear();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.InsertAfter(6, 1);
            list.InsertAfter(7, 3);
            list.InsertAfter(8, 5);
            Console.WriteLine(list.Length());
            list.Traverse(node => Console.Write(Math.Pow(node.Data, 2) + " "));
            Console.WriteLine();
            list.Traverse(DisplayCube);
            Console.WriteLine();
            list.Display();
        }

        public static void DisplayCube(Node node)
        {
            int cube = (int)Math.Pow(node.Data, 3);
            Console.Write(cube + " ");
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        public void Add(int data)
        {
            Node link = new Node(data);

            if (Head == null)
            {
                Head = link;
                Tail = link;
            }
            else
            {
                Tail.Next = link;
                Tail = link;
            }
        }

        public bool Remove(int data)
        {
            bool status = false;

            Node previous = Head;
            Node current = Head;
            
            while (current != null)
            {
                if (current.Data == data)
                {
                    if (current == Head)
                    {
                        Head = Head.Next;
                    }
                    if (current == Tail)
                    {
                        Tail = previous;
                    }

                    status = true;
                    previous.Next = current.Next;
                }
                else
                {
                    previous = current;
                }

                current = current.Next;
            }

            return status;
        }

        public bool InsertAfter(int data, int refData)
        {
            bool status = false;

            Node current = Head;
            while (current != null)
            {
                if (current.Data == refData)
                {
                    Node node = new Node(data);
                    if (current == Tail)
                    {
                        Tail.Next = node;
                        Tail = node;
                    }
                    else
                    {
                        node.Next = current.Next;
                        current.Next = node;
                    }
                    status = true;
                }

                current = current.Next;
            }

            return status;
        }

        public int Length()
        {
            Node temp = Head;
            int count = 0;

            while (temp != null)
            {
                count++;
                temp = temp.Next;
            }

            return count;
        }

        public void Traverse(Action<Node> action)
        {
            Node temp = Head;

            while (temp != null)
            {
                action(temp);
                temp = temp.Next;
            }
        }

        public void Display()
        {
            Node temp = Head;

            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }


        public class Node
        {
            public Node(int data)
            {
                Data = data;
                Next = null;
            }

            public int Data { get; set; }
            public Node Next { get; set; }
        }
    }
}
