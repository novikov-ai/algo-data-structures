using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        int[] BitArray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            BitArray = new int[filter_len];
            for (int i = 0; i < filter_len; i++)
            {
                BitArray[i] = 0;
            }
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            // реализация ...
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = Math.Abs(result * 17 + code) % filter_len;
            }
            return result;
        }
        public int Hash2(string str1)
        {
            // 223
            // реализация ...
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = Math.Abs(result * 223 + code) % filter_len;
            }
            return result;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            BitArray[Hash1(str1)] = 1;
            BitArray[Hash2(str1)] = 1;
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            if (BitArray[Hash1(str1)] == 1 && BitArray[Hash2(str1)] == 1)
            { return true; }
            return false;
        }
    }
}