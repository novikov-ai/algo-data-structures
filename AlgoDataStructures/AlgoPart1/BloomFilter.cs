using System.Collections.Generic;
using System;
using System.IO;

namespace AlgoDataStructures.AlgoPart1
{
    public class BloomFilter
    {
        public int filter_len;
        int filter;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            // создаём битовый массив длиной f_len ...
            filter = 0;
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
            return 1 << result;

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
            return 1 << result;
        }

        public void Add(string str1)
        {
            // добавляем строку str1 в фильтр
            filter |= Hash1(str1);
            filter |= Hash2(str1);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            int result = Hash1(str1) + Hash2(str1);
            if ((filter & result) == result)
            {
                return true;
            }
            return false;
        }
    }
}