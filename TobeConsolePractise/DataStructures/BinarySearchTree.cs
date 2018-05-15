using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise.DataStructures
{
    class BinarySearchTree
    {
        private Node Root { get; set; }
        public int Count { get; set; }

        public static void Run()
        {
        }

        public void Add(int data)
        {
            Node node = new Node(data);

            if (Root != null)
            {
                Root = node;
            }
            else
            {
                Node current = Root;

                while (current != null)
                {
                    if (node.Data < current.Data)
                    {
                        if (current.Left != null)
                        {
                            current.Left = node;
                            break;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right != null)
                        {
                            current.Right = node;
                            break;
                        }
                        current = current.Right;
                    }
                }
            }
            Count++;
        }

        public bool Remove(int data)
        {
            Node nodeToRemove = FindNode(data, Root);
            if (nodeToRemove == null) return false;     //no node to remove
            
            Node parent = FindParent(data, Root);
            
            if(Count==1)
            {
                Root = null;
            }
            else if(nodeToRemove.Left==null && nodeToRemove.Right == null)
            {
                if (nodeToRemove.Data < parent.Data) parent.Left = null;
                else parent.Right = null;
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right != null)
            {
                if (nodeToRemove.Data < parent.Data) parent.Left = nodeToRemove.Right;
                else parent.Right = nodeToRemove.Right;
            }
            else if (nodeToRemove.Left != null && nodeToRemove.Right == null)
            {
                if (nodeToRemove.Data < parent.Data) parent.Left = nodeToRemove.Left;
                else parent.Right = nodeToRemove.Left;
            }
            else
            {
                Node largestValue = nodeToRemove.Left;
                while (largestValue != null)
                {
                    largestValue = largestValue.Right;
                }
                FindParent(largestValue.Data, Root).Right = null;
                nodeToRemove.Data = largestValue.Data;
            }
            Count--;

            return true;
        }

        public bool Contains(int data)
        {
            return Contains(data, Root);
        }

        private bool Contains(int data,Node root)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Data == data) return true;
            else if (data < root.Data) return Contains(data, root.Left);
            else return Contains(data, root.Right);
        }

        public Node FindParent(int data)
        {
            return FindParent(data, Root);
        }

        private Node FindParent(int data, Node root)
        {
            if (root.Data == data) return null;

            if (data < root.Data)
            {
                if (root.Left == null) return null;
                else if (root.Left.Data == data) return root;
                else return FindParent(data, root.Left);
            }
            else
            {
                if (root.Right == null) return null;
                else if (root.Right.Data == data) return root;
                else return FindParent(data, root.Right);
            }
        }

        public Node FindNode(int data)
        {
            return FindNode(data, Root);
        }

        private Node FindNode(int data, Node root)
        {
            if (root == null) return null;

            if (root.Data == data) return root;
            else if (data < root.Data) return FindNode(data, root.Left);
            else return FindNode(data, root.Right);
        }

        public int FindMin()
        {
            return FindMin(Root);
        }

        private int FindMin(Node root)
        {
            if (root.Left == null) return root.Data;
            return FindMin(root.Left);
        }

        public int FindMax()
        {
            return FindMax(Root);
        }

        private int FindMax(Node root)
        {
            if (root.Right == null) return root.Data;
            return FindMin(root.Right);
        }

        public void Preorder(Action<Node> action)
        {
            //node => Console.Write(node.Data + " ")
            Preorder(Root, action);
        }

        private void Preorder(Node root, Action<Node> action)
        {
            if (root != null)
            {
                action(root);
                Preorder(root.Left, action);
                Preorder(root.Right, action);
            }
        }

        public void Inorder(Action<Node> action)
        {
            Inorder(Root, action);
        }

        private void Inorder(Node root, Action<Node> action)
        {
            if (root != null)
            {
                Inorder(root.Left, action);
                action(root);
                Inorder(root.Right, action);
            }
        }

        public void Postorder(Action<Node> action)
        {
            Postorder(Root, action);
        }

        private void Postorder(Node root, Action<Node> action)
        {
            if (root != null)
            {
                Postorder(root.Left, action);
                Postorder(root.Right, action);
                action(root);
            }
        }


        public class Node
        {
            public Node(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }

            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }
}
