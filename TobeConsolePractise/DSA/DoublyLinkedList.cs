using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class DoublyLinkedList : ILinkedList
    {
        public NodeBi Head { get; set; }
        public NodeBi Last { get; set; }

        public void PrintList()
        {
            NodeBi temp = Head;

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
            NodeBi temp = Last;

            Console.WriteLine("\n[ ");

            while (temp != null)
            {
                Console.WriteLine("Key: " + temp.Key + " Data: " + temp.Data);
                temp = temp.Prev;
            }

            Console.WriteLine(" ]");
        }

        public void InsertFirst(int key, int data)
        {
            NodeBi link = new NodeBi();
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
            NodeBi link = new NodeBi();
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

        public NodeBi DeleteFirst()
        {
            NodeBi temp = Head;     //save refrence to first link

            if (Head.Next == null)
                Last = null;
            else
                Head.Next.Prev = null;

            return temp;            //return deleted link
        }

        public NodeBi DeleteLast()
        {
            NodeBi temp = Last;

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

            for (NodeBi current = Head; current != null; current = current.Next)
                length++;

            return length;
        }

        public NodeBi Find(int key)
        {
            if (Head == null)
                return null;

            NodeBi current = Head;
            while (current.Key != key)
            {
                if (current.Next == null)
                    return null;
                else
                    current = current.Next;
            }

            return current;
        }

        public NodeBi Delete(int key)
        {
            NodeBi current = Head;
            NodeBi previous = null;

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
            NodeBi current = Head;

            if (IsEmpty())
                return false;

            while (current.Key != key)
            {
                if (current.Next == null)
                    return false;
                else
                    current = current.Next;     //move TobeConsolePractise the next link
            }

            NodeBi newLink = new NodeBi();
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
            NodeAbstract a = list.Head;         //to scan its runtime content
            list.PrintBackwards();

            Console.WriteLine("After deleting the last record");
            list.DeleteLast();
            list.PrintList();

            Console.WriteLine("Insert after key 4: 9, 90");
            list.InsertAfter(4, 9, 90);
            list.PrintList();

            Console.WriteLine("Find item with key 3");
            NodeBi foundNode = list.Find(3);
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
