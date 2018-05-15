using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    //still being developed
    class CircularLinkedList : ILinkedList
    {
        public CircularLinkedList()
        {
            throw new Exception("Implementation errors exist"); //insertion logic
        }

        public Node Head { get; set; }

        public void PrintList()
        {
            Node temp = Head;

            Console.WriteLine("\n[ ");

            while (temp != null)
            {
                Console.WriteLine("Key: " + temp.Key + " Data: " + temp.Data);
                temp = temp.Next;
            }

            Console.WriteLine(" ]");
        }

        public void InsertFirst(int Key, int Data)
        {
            Node link = new Node();
            link.Key = Key;
            link.Data = Data;

            if (IsEmpty())
            {
                Head = link;
                Head.Next = Head;
            }
            else
            {
                link.Next = Head;       //points link to old first node
                Head = link;            //points head to new first node
            }
        }

        public Node DeleteFirst()
        {
            Node temp = new Node();

            if (Head.Next == Head)
            {
                Head = null;
                return temp;
            }

            Head = Head.Next;       //mark next to head link as head

            return temp;
        }

        public Node Delete(int key)
        {
            if (IsEmpty())
                return null;
            if (Head.Key == key)
                return DeleteFirst();

            Node current = Head.Next;
            Node previous = new Node();

            while (current.Key != key && current != Head)
            {
                if (current.Next == null) return null;
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }

            //update list after match found
            if (current == Head) Head = Head.Next;
            else previous.Next = current.Next;

            return current;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public int Length()
        {
            int length = 0;

            if (IsEmpty())
                return 0;

            for (Node current = Head.Next; current != Head; current = current.Next)
                length++;

            return length;
        }

        public Node Find(int key)
        {
            if (Head == null)
                return null;
            if (Head.Key == key)
                return Head;

            Node current = Head.Next;
            while (current.Key != key && current != Head)
            {
                if (current.Next == null)
                    return null;
                else
                    current = current.Next;
            }

            return current;
        }

        public static void Run()
        {
            CircularLinkedList list = new CircularLinkedList();
            list.InsertFirst(1, 10);
            list.InsertFirst(2, 20);
            list.InsertFirst(3, 30);
            list.InsertFirst(4, 40);
            list.InsertFirst(5, 50);
            list.InsertFirst(6, 60);
            list.InsertFirst(7, 70);
            list.InsertFirst(8, 80);
            Console.WriteLine("First to Last");
            list.PrintList();

            Console.WriteLine("After deleting the first record");
            list.DeleteFirst();
            list.PrintList();

            Console.WriteLine("Find item with key 3");
            Node foundNode = list.Find(3);
            if (foundNode == null)
                Console.WriteLine("Element not found");
            else
                Console.WriteLine("Element found: Key- " + foundNode.Key + ", Data- " + foundNode.Data);

            list.PrintList();

            Console.WriteLine("\nList after deleting key 6");
            list.Delete(6);
            list.PrintList();

            Console.WriteLine("Find deleted item with old key 6");
            foundNode = list.Find(6);
            if (foundNode == null)
                Console.WriteLine("Element not found");
            else
                Console.WriteLine("Element found: Key- " + foundNode.Key + ", Data- " + foundNode.Data);

            Console.WriteLine("\nList after deleting first item");
            list.DeleteFirst();
            list.PrintList();

            Console.ReadKey();
        }
    }
}
