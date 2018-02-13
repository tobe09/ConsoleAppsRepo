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
