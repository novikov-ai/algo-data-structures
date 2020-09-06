using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей
        public int size;
        public int capacity;

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:
            int tree_size = (int)(Math.Pow(2, depth + 1) - 1);
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
            size = tree_size;
        }

        public int? FindKeyIndex(int key)
        {
            if (Tree[0] == key || capacity == 0)
                return 0;

            int? node;

            // ищем в массиве индекс ключа

            for (int i = 0; i < size; i++)
            {
                node = Tree[i];
                if (node == key)
                    return i;
                else if (node == null)
                    return -i;

                if (key < node)
                {
                    i = 2 * i; // left child + increment
                }
                else
                {
                    i = 2 * i + 1; // right child + increment
                }
            }
            return null; // не найден
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив

            int? res = FindKeyIndex(key);
            if (capacity <= size && res != null)
            {
                if (capacity == 0)
                {
                    Tree[0] = key;
                    capacity++;
                }

                if (res != null && res < 0)
                {
                    Tree[(int)res * (-1)] = key;
                    capacity++;
                    return (int)res * (-1);
                }
                return (int)res;
            }
            else
                return -1;
            // индекс добавленного/существующего ключа или -1 если не удалось
        }
    }
}