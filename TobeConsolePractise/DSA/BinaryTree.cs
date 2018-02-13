using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class BinaryTree
    {
        bool checkBst(NodeBin root)
        {
            return check(root, int.MinValue, int.MaxValue);
        }

        bool check(NodeBin root, int min, int max)
        {
            if (root == null)
                return true;
            if (root.data <= min || root.data >= max)
                return false;

            return check(root.left, min, root.data) && check(root.right, root.data, max);
        }

        public static void Run()
        {
            //need to implement a binary search tree first
            throw new NotImplementedException();
        }
    }
}
