using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class SinglyLinkedList : ILinkedList
    {
        public Node Head { get; set; }

        public void PrintList()
        {
            Node temp = Head;
            Console.WriteLine("\n[ ");
            while (temp != null)
            {
                Console.WriteLine(temp.Key + ": " + temp.Data + "\r\n");
                temp = temp.Next;
            }
            Console.WriteLine(" ]");
        }

        public void InsertFirst(int key, int data)
        {
            Node link = new Node();
            link.Key = key;
            link.Data = data;
            //point to old first node
            link.Next = Head;
            //point Head to new node
            Head = link;
        }

        public void InsertLast(int key, int data)
        {
            Node link = new Node();
            link.Key = key;
            link.Data = data;
            InsertLast(link);
        }

        public void InsertLast(Node link)
        {
            Node temp = Head;
            if (Head == null)
                Head = link;
            else if (Head.Next == null)
                Head.Next = link;
            else
            {
                Head = Head.Next;
                InsertLast(link);
            }
            Head = temp;
        }

        public void InsertLast(Node head, Node link)
        {
            if (head == null)
                head = link;
            else if (head.Next == null)
            {
                head.Next = link;
            }
            else
            {
                InsertLast(head.Next, link);
            }
        }

        public Node DeleteFirst()
        {
            Node temp = Head;
            if (!IsEmpty())
                Head = Head.Next;
            return temp;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public int Length()
        {
            int length = 0;
            for (Node current = Head; current != null; current = current.Next)
                length++;

            return length;
        }

        public Node Find(int key)
        {
            if (Head == null)
                return null;

            Node current = Head;
            while (current.Key != key)
            {
                if (current.Next == null)
                    return null;
                else
                    current = current.Next;
            }

            return current;
        }

        public Node Delete(int key)
        {
            Node current = Head;
            Node previous = new Node();

            if (IsEmpty()) return null;

            while (current.Key != key)
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

        public void Sort()
        {
            int size = Length();
            int k = size;
            Node current, Next;

            for (int i = 0; i < size - 1; i++, k--)
            {
                current = Head;
                Next = Head.Next;
                for (int j = 0; j < k - 1; j++)
                {
                    if (current.Data > Next.Data)
                    {
                        int tempData = current.Data;
                        current.Data = Next.Data;
                        Next.Data = tempData;

                        int tempKey = current.Key;
                        current.Key = Next.Key;
                        Next.Key = tempKey;
                    }

                    current = current.Next;
                    Next = Next.Next;
                }
            }
        }

        public void Reverse()
        {
            Node prev = null, Next;
            Node current = Head;

            while (current != null)
            {
                Next = current.Next;
                current.Next = prev;
                prev = current;
                current = Next;
            }

            Head = prev;
        }

        public static void Run()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.InsertFirst(1, 10);
            list.InsertFirst(2, 20);
            list.InsertFirst(3, 30);
            list.InsertLast(4, 40);
            list.InsertFirst(5, 50);
            list.InsertFirst(6, 60);
            list.InsertFirst(7, 70);
            list.InsertFirst(8, 80);
            Console.WriteLine("Singly Linked List's Original Content");
            list.PrintList();

            while (!list.IsEmpty())
            {
                Node temp = list.DeleteFirst();
                Console.WriteLine("Deleted Key: " + temp.Key + ", Data: " + temp.Data);
            }
            Console.WriteLine("After Complete Deletion, List Content");
            list.PrintList();

            list.InsertFirst(3, 30);
            list.InsertFirst(5, 50);
            list.InsertFirst(6, 60);
            list.InsertFirst(7, 70);
            list.InsertFirst(4, 40);
            list.InsertFirst(8, 80);
            Console.WriteLine("Restored List");
            list.PrintList();

            Console.WriteLine("Searching for link with Key 6");
            Node foundNode = list.Find(6);
            if (foundNode == null)
                Console.WriteLine("Element not found");
            else
                Console.WriteLine("Element found: Key- " + foundNode.Key + ", Data- " + foundNode.Data);

            Console.WriteLine("Deleting Link at Key 7");
            Node delLink = list.Delete(7);
            Console.WriteLine("Deleted Link: Key- " + delLink.Key + ", Data- " + delLink.Data);
            Console.WriteLine("List after deleting item");
            list.PrintList();

            Console.WriteLine("Searching for link with Key 7");
            foundNode = list.Find(7);
            if (foundNode == null)
                Console.WriteLine("Element not found");
            else
                Console.WriteLine("Element found: Key- " + foundNode.Key + ", Data- " + foundNode.Data);

            Console.WriteLine("Sorting the List");
            list.Sort();
            Console.WriteLine("List after sorting");
            list.PrintList();

            Console.WriteLine("Reversing the List");
            list.Reverse();
            Console.WriteLine("List after reversal");
            list.PrintList();

            Console.ReadKey();
        }
    }
}
