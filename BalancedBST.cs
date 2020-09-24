using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            if (a.Length > 0)
            {
                Array.Sort(a);
                int[] BBSTArray = new int[a.Length];

                List<int> TreeList = new List<int>();
                Node node = new Node();

                TreeList = node.GetList(a);

                for (int i = 0; i < a.Length; i++)
                {
                    BBSTArray[i] = TreeList[i];
                }

                return BBSTArray;
            }
            return null;
        }
    }

    public class Node
    {
        public int[] left;
        public int[] right;
        public int count = 0;

        public List<int> GetList(int[] a)
        {
            if (a.Length > 0)
            {
                List<int> TreeList = new List<int>();
                Node node = new Node();

                TreeList.Add(a[a.Length / 2]);

                if (a.Length > 1)
                {
                    node.left = new int[a.Length / 2];
                    Array.ConstrainedCopy(a, 0, node.left, 0, node.left.Length);
                    TreeList.AddRange(GetList(node.left));

                    if (a.Length > 2)
                    {
                        node.right = new int[a.Length - node.left.Length - 1];
                        Array.ConstrainedCopy(a, a.Length / 2 + 1, node.right, 0, node.right.Length);
                        TreeList.AddRange(GetList(node.right));
                    }
                }
                
                return TreeList;
            }
            return null;
        }
    }
}
