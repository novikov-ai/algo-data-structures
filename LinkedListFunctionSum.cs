using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructures
{
    public class LinkedListFunctionSum
    {
        public List<int> LinkedListSum(LinkedList list1, LinkedList list2)
        {
            int length1 = list1.Count();
            int length2 = list2.Count();

            Node node1 = list1.head;
            Node node2 = list2.head;

            List<int> list3 = new List<int>();

            if (length1 == length2)
            {
                for (int i=0;i<length1;i++)
                {
                    list3.Add(node1.value + node2.value);
                    node1 = node1.next;
                    node2 = node2.next;
                }
            }
            return list3;
        }
    }
}

