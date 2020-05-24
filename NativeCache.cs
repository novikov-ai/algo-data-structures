using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class NativeCache<T>
    {
        public int size;
        public String[] slots;
        public T[] values;
        public int[] hits;
        public int capacity;

        public NativeCache(int size)
        {
            this.size = size;
            slots = new String[size];
            values = new T[size];
            hits = new int[size];
            capacity = 0;
        }

        public int HashFun(string key)
        {
            int result = 0;
            for (int i = 0; i < key.Length; i++)
            {
                result += Convert.ToInt32(key[i].GetTypeCode());
            }
            hits[result % size] += 1;
            return result % size;
        }

        public int SeekSlot(string key)
        {
            if (capacity < size)
            {
                if (slots[HashFun(key)] != null)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (slots[i] == null)
                        {
                            return i;
                        }
                    }
                }
                else
                {
                    return HashFun(key);
                }
            }
            return -1;
        }

        public bool IsKey(string key)
        {
            return slots[HashFun(key)] == key;
        }

        public void Put(string key, T value)
        {
            if (capacity < size)
            {
                int slot = SeekSlot(key);
                slots[slot] = key;
                values[slot] = value;
                capacity++;
            }
            else
            {
                int minHit = hits[0];
                for (int i = 0; i < size; i++)
                {
                    if (hits[i] < minHit)
                    {
                        minHit = hits[i];
                    }
                }
                slots[minHit] = key;
                values[minHit] = value;
            }
        }

        public T Get(string key)
        {
            if (IsKey(key))
            {
                return values[HashFun(key)];
            }
            return default;
        }
    }
}