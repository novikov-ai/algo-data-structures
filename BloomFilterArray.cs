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
            int len = (int)Math.Ceiling(f_len / 32.0);
            BitArray = new int[len];
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
            int pos1 = (int)Math.Ceiling(Hash1(str1) / 32.0)-1;
            int pos2 = (int)Math.Ceiling(Hash2(str1) / 32.0)-1;

            BitArray[pos1] |= 1 << Hash1(str1);
            BitArray[pos2] |= 1 << Hash2(str1);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            int pos1 = (int)Math.Ceiling(Hash1(str1) / 32.0) - 1;
            int pos2 = (int)Math.Ceiling(Hash2(str1) / 32.0) - 1;
            int[] newArray = new int[filter_len];
            newArray[pos1] |= 1 << Hash1(str1);
            newArray[pos2] |= 1 << Hash2(str1);
            int result = newArray[pos1] | newArray[pos2]; // bit mask

            if (((BitArray[pos1] | BitArray[pos2]) & result) == result)
            { return true; }

            return false;
        }
    }
}