using System;
using System.Collections.Generic;

namespace AlgoDataStructures.AlgoPart2
{
    public static class BalancedBST
    {
        public static int[] BBST;
        public static int[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);

            BBST = new int[a.Length];
            Balancing(a, 0);

            return BBST;
        }

        public static void Balancing(int[] array, int index)
        {
            if (array.Length == 0)
                return;

            int center = array.Length / 2; // находим центральный индекс массива

            if (index < BBST.Length)
                BBST[index] = array[center];

            int[] left = new int[center]; // создаем массив из левой части за исключением центрального элемента
            int[] right = new int[array.Length - left.Length - 1]; // создаем массив из правой части за исключением центрального элемента

            Array.ConstrainedCopy(array, 0, left, 0, left.Length);
            Array.ConstrainedCopy(array, center + 1, right, 0, right.Length);

            Balancing(left, 2 * index + 1); // индекс левого наследника
            Balancing(right, 2 * index + 2); // индекс правого наследника
        }
    }
}