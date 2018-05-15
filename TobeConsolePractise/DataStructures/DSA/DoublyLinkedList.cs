using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    public class DoublyLinkedList : ILinkedList
    {
        public class Node
        {
            public int Data { get; set; }
            public int Key { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
        }

        public Node Head { get; set; }
        public Node Last { get; set; }

        //head is sorted in ascending order
        public static Node SortedInsert(Node head, int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            if (head == null)
            {
                return newNode;
            }
            else if (data <= head.Data)
            {
                newNode.Next = head;
                head.Prev = newNode;
                return newNode;
            }
            else
            {
                Node temp = SortedInsert(head.Next, data);
                head.Next = temp;
                temp.Prev = head;
                return head;
            }
        }

        public static Node Reverse(Node head)
        {
            if (head == null) return null;
            head.Prev = head.Next;
            head.Next = null;
            while (head.Prev != null)
            {
                head = head.Prev;
                Node temp = head.Next;
                head.Next = head.Prev;
                head.Prev = temp;
            }

            return head;
        }

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

        public void PrintBackwards()
        {
            Node temp = Last;

            Console.WriteLine("\n[ ");

            while (temp != null)
            {
                Console.WriteLine(" Data: " + temp.Data);
                temp = temp.Prev;
            }

            Console.WriteLine(" ]");
        }

        public void InsertFirst(int key, int data)
        {
            Node link = new Node();
            link.Key = key;
            link.Data = data;

            if (IsEmpty())
                Last = link;        //make it last link
            else
                Head.Prev = link;   //update previous first link

            link.Next = Head;       //point to old first link
            Head = link;            //point head to new first link
        }

        public void InsertLast(int key, int data)
        {
            Node link = new Node();
            link.Key = key;
            link.Data = data;

            if (IsEmpty())
                Last = link;        //make it the last link
            else
            {
                Last.Next = link;   //make llink new last link
                link.Prev = Last;   //mark old link as its previous link
            }

            Last = link;            //point last to new last link
        }

        public Node DeleteFirst()
        {
            Node temp = Head;     //save refrence to first link

            if (Head.Next == null)
                Last = null;
            else
                Head.Next.Prev = null;

            return temp;            //return deleted link
        }

        public Node DeleteLast()
        {
            Node temp = Last;

            if (Head.Next == null)
                Head = null;
            else
                Last.Prev.Next = null;

            Last = Last.Prev;

            return temp;                //return deleted link
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
            Node previous = null;

            if (Head == null)
                return null;

            while (current.Key != key)
            {
                if (current.Next == null)   //if it is the last node
                    return null;
                else
                {
                    previous = current;     //store reference to current link
                    current = current.Next; //move to the next link
                }
            }

            if (current == Head)
                Head = Head.Next;           //change first to point to the next link
            else
                current.Prev.Next = current.Next;   //bypass the current link

            if (current == Last)
                Last = current.Prev;        //change last to point to the previous link
            else
                current.Next.Prev = current.Prev;

            return current;
        }

        public bool InsertAfter(int key, int newKey, int data)
        {
            Node current = Head;

            if (IsEmpty())
                return false;

            while (current.Key != key)
            {
                if (current.Next == null)
                    return false;
                else
                    current = current.Next;     //move TobeConsolePractise the next link
            }

            Node newLink = new Node();
            newLink.Key = key;
            newLink.Data = data;

            if (current == Last)
            {
                newLink.Next = null;
                Last = newLink;
            }
            else
            {
                newLink.Next = current.Next;
                current.Next.Prev = newLink;
            }

            newLink.Prev = current;
            current.Next = newLink;

            return true;
        }

        public static void Run()
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.InsertFirst(1, 10);
            list.InsertFirst(2, 20);
            list.InsertFirst(3, 30);
            list.InsertLast(4, 40);
            list.InsertLast(5, 50);
            list.InsertFirst(6, 60);
            list.InsertFirst(7, 70);
            list.InsertFirst(8, 80);
            Console.WriteLine("First to Last");
            list.PrintList();
            Node a = list.Head;         //to scan its runtime content
            list.PrintBackwards();

            Console.WriteLine("After deleting the last record");
            list.DeleteLast();
            list.PrintList();

            Console.WriteLine("Insert after key 4: 9, 90");
            list.InsertAfter(4, 9, 90);
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

        public static void Run2()
        {

        }
    }
}
