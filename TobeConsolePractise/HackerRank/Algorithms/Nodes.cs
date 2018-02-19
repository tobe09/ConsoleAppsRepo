using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class NodeTest
    {
        public NodeTest next;
        public int data;
        public NodeTest(int data)
        {
            this.data = data;
        }

        public static NodeTest Reverse2(NodeTest head)
        {
            List<int> values = new List<int>();

            NodeTest temp = head;
            while (temp != null)
            {
                values.Add(temp.data);
                temp = temp.next;
            }

            NodeTest revHead = null;
            if (values.Count > 0)
            {
                revHead = new NodeTest(values[values.Count - 1]);

                for (int i = values.Count - 2; i >= 0; i--)
                {
                    NodeTest newNode = new NodeTest(values[i]);

                    NodeTest start = revHead;
                    while (start.next != null)
                        start = start.next;
                    start.next = newNode;
                }
            }

            return revHead;
        }

        public static NodeTest Reverse(NodeTest head)
        {
            NodeTest rev = null, temp;

            while (head != null)
            {
                temp = head.next;
                head.next = rev;
                rev = head;
                head = temp;
            }

            return rev;
        }

        public static NodeTest insert(NodeTest head, int data)
        {
            ////recursive version
            //if (head == null)
            //    return new NodeTest(data);
            //else
            //    head.next = insert(head.next, data);

            //return head;

            //iterative version
            NodeTest p = new NodeTest(data);
            if (head == null)
                head = p;
            else
            {
                NodeTest start = head;
                while (start.next != null)
                    start = start.next;
                start.next = p;

            }
            return head;
        }

        public static NodeTest InsertNth(NodeTest head, int data, int position)
        {
            NodeTest newNode = new NodeTest(data);
            if (head == null)
            {
                head = newNode;
            }
            else if (position == 0)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                NodeTest temp = head;
                for (int i = 0; i < position - 1 && temp.next != null; i++)
                {
                    temp = temp.next;
                }
                //can use if(temp.next==null) to check for large positions
                NodeTest tempNext = temp.next;
                temp.next = newNode;
                newNode.next = tempNext;
            }

            return head;
        }

        public static NodeTest Delete(NodeTest head, int position)
        {
            if (position == 0)
            {
                head = head.next;
                return head;
            }

            NodeTest temp = head;
            for (int i = 0; i < position - 1 && temp.next != null; i++)
            {
                temp = temp.next;
            }

            if (temp.next != null)
            {
                temp.next = temp.next.next;
            }

            return head;
        }

        public static NodeTest RemoveDuplicates(NodeTest head)
        {
            NodeTest start = head;
            while (start != null)
            {
                NodeTest innerNode = start.next;
                while (innerNode != null && innerNode.next != null)
                {
                    if (start.data == innerNode.next.data)
                    {
                        innerNode.next = innerNode.next.next;
                    }
                    else innerNode = innerNode.next;
                }
                start = start.next;
            }

            return head;
        }

        public static void RemoveDuplicateS2(NodeTest head)
        {
            // Hash to store seen values
            HashSet<int> hs = new HashSet<int>();

            /* Pick elements one by one */
            NodeTest current = head;
            NodeTest prev = null;

            while (current != null)
            {
                int curval = current.data;

                // If current value is seen before
                if (hs.Contains(curval))
                {
                    prev.next = current.next;
                }
                else
                {
                    hs.Add(curval);
                    prev = current;
                }
                current = current.next;
            }

        }

        public static int FindMergeNode(NodeTest headA, NodeTest headB)
        {
            // Complete this function
            // Do not write the main method.
            HashSet<NodeTest> hs = new HashSet<NodeTest>();

            NodeTest tempA = headA;
            NodeTest tempB = headB;
            while (tempA != null || tempB != null)
            {
                if (!hs.Contains(tempA) || tempA == null) hs.Add(tempA);
                else return tempA.data;
                if (!hs.Contains(tempB) || tempB == null) hs.Add(tempB);
                else return tempB.data;
                if (tempA != null) tempA = tempA.next;
                if (tempB != null) tempB = tempB.next;
            }

            return -1;      //not possible if merge exists
        }

        public static int FindMergeNode2(Node headA, Node headB)
        {
            Node currentA = headA;
            Node currentB = headB;

            //Do till the two nodes are the same, can go into an infinite loop
            while (currentA != currentB)
            {
                //if you reached the end of one list start at the beginning of the other one
                //currentA
                if (currentA.Next == null)
                {
                    currentA = headB;
                }
                else
                {
                    currentA = currentA.Next;
                }
                //currentB
                if (currentB.Next == null)
                {
                    currentB = headA;
                }
                else
                {
                    currentB = currentB.Next;
                }
            }
            return currentB.Data;
        }

        public static void display(NodeTest head)
        {
            NodeTest start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }

        public static void ReversePrint(NodeTest head)
        {
            //if (head != null)
            //{
            //    ReversePrint(head.next);
            //    Console.WriteLine(head.data);
            //}

            List<int> values = new List<int>();

            NodeTest temp = head;
            while (temp != null)
            {
                values.Add(temp.data);
                temp = temp.next;
            }

            for (int i = values.Count - 1; i >= 0; i--)
                Console.WriteLine(values[i]);
        }

        public static void Run()
        {
            NodeTest root = null;
            int t = 5;
            while (t-- > 0)
            {
                int data = t;
                root = insert(root, data);
            }
            root = RemoveDuplicates(root);
            display(root);
            Console.WriteLine();
            root = Reverse2(root);
            display(root);
        }

        public static void Run2()
        {
            NodeTest head = null;
            for (int i = 1; i <= 5; i++)
            {
                head = NodeTest.insert(head, i);
            }
            head = NodeTest.InsertNth(head, 6, 0);
            head = NodeTest.InsertNth(head, 7, 1);
            head = NodeTest.InsertNth(head, 8, 2);
            head = NodeTest.InsertNth(head, 9, 5);
            head = NodeTest.InsertNth(head, 10, 13);

            head = NodeTest.Delete(head, 0);
            head = NodeTest.Delete(head, 1);
            head = NodeTest.Delete(head, 4);
            head = NodeTest.Delete(head, 14);
        }
    }

    class BST
    {
        static int getHeight(Node root)
        {
            int maxHeight;

            if (root == null)
                return -1;

            int leftDepth = getHeight(root.left);
            int rightDepth = getHeight(root.right);

            maxHeight = leftDepth > rightDepth ? leftDepth : rightDepth;

            return maxHeight + 1;
        }

        static void InOrder(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.Write(current.data + " ");
                if (current.left != null) queue.Enqueue(current.left);
                if (current.right != null) queue.Enqueue(current.right);
            }
        }

        static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        public static void Run()
        {
            Node root = null, root2 = null; bool start = true;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
                if (start) { root2 = new Node(data); start = false; }
                else root2.Insert(data);
                
            }
            int height = getHeight(root);
            Console.WriteLine(height);
            InOrder(root);
            Console.ReadKey();
        }

        class Node
        {
            public Node left, right;
            public int data;
            public Node(int data)
            {
                this.data = data;
                left = right = null;
            }

            public Node() { }
            public void Insert(int data) { BST.insert(this, data); }
        }
    }
}
