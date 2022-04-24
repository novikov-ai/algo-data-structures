using System;
using System.Collections.Generic;

namespace AlgoDataStructures.AlgoPart1
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;
        int capacity;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
            capacity = 0;
        }

        public int HashFun(string value)
        {
            // всегда возвращает корректный индекс слота
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result += Convert.ToInt32(value[i].GetTypeCode());
            }
            return result % size;
        }

        public int SeekSlot(string value)
        {
            // находит индекс пустого слота для значения, или -1
            if (capacity < size)
            {
                if (slots[HashFun(value)] != null)
                {
                    int i = HashFun(value);
                    int j = HashFun(value);

                    while (slots[i] != null)
                    {
                        j += step;
                        i = j % size;
                    }
                    return i;
                }

                else
                {
                    return HashFun(value);
                }

            }
            return -1;

        }

        public int Put(string value)
        {
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить
            if (capacity < size)
            {
                int slotNum = SeekSlot(value);
                capacity++;
                slots[slotNum] = value;
                return slotNum;
            }
            return -1;
        }

        public int Find(string value)
        {
            // находит индекс слота со значением, или -1
            if (slots[HashFun(value)] == value)
            {
                return HashFun(value);
            }

            if (slots[HashFun(value)] != null && capacity > 0)
            {
                int k = 0;
                int i = HashFun(value);
                int j = HashFun(value);

                while (k < capacity)
                {
                    if (slots[i] != value)
                    {
                        j += step;
                        i = j % size;
                        k++;
                    }
                    else
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }

}