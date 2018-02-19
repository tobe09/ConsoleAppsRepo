using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    interface ILinkedList
    {
        void PrintList();
        void InsertFirst(int Key, int Data);
        bool IsEmpty();
        int Length();
    }

    abstract class NodeAbstract
    {
        public  virtual int Data { get; set; }
        public virtual int Key { get; set; }
    }

    class Node : NodeAbstract
    {
        public Node Next { get; set; }

        public static Node MergeLists(Node headA, Node headB)
        {
            if (headA == null) return headB;
            if (headB == null) return headA;

            System.Collections.Generic.List<int> values = new System.Collections.Generic.List<int>();
            Node tempA = headA;
            Node tempB = headB;
            while (tempA != null)
            {
                values.Add(tempA.Data);
                tempA = tempA.Next;
            }
            while (tempB != null)
            {
                values.Add(tempB.Data);
                tempB = tempB.Next;
            }
            values.Sort();

            Node mergedNode = null;

            if (values.Count > 0)
            {
                mergedNode = new Node { Data = values[0] };
                for (int i = 1; i < values.Count; i++)
                {
                    Node newNode = new Node { Data = values[i] };
                    Node temp = mergedNode;
                    while (temp.Next != null) temp = temp.Next;
                    temp.Next = newNode;
                }
            }

            return mergedNode;
        }

        public static int CompareLists(Node a, Node b)
        {
            Node temp1 = a;
            Node temp2 = b;
            while (temp1 != null || temp2 != null)
            {
                if ((temp1 == null && temp2 != null) || (temp1 != null && temp2 == null)) return 0;
                if (temp1.Data != temp2.Data) return 0;
                temp1 = temp1.Next;
                temp2 = temp2.Next;
            }

            return 1;
        }
    }

    class NodeBi : NodeAbstract
    {
        public NodeBi Next { get; set; }
        public NodeBi Prev { get; set; }
    }

    class NodeBin
    {
        public int data { get; set; }
        public NodeBin left { get; set; }
        public NodeBin right { get; set; }
    }
}
