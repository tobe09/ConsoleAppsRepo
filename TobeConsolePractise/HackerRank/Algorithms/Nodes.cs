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

        public static NodeTest RemoveDuplicates(NodeTest head)
        {
            NodeTest start = head;
            while (start != null)
            {
                NodeTest innerNode = start.next;
                NodeTest previous;
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
   

        public static void display(NodeTest head)
        {
            NodeTest start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }

        public static void Run()
        {
            NodeTest root = null;
            int T = Int32.Parse(Console.ReadLine());
            while (T-- > 0)
            {
                int data = Int32.Parse(Console.ReadLine());
                root = insert(root, data);
            }
            root = RemoveDuplicates(root);
            display(root);
            Console.ReadKey();
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

        static void levelOrder(Node root)
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

        static void depthOrder(Node root)
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
            levelOrder(root);
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
