using System;
using System.Collections.Generic;

namespace AlgoDataStructures.AlgoPart1
{

    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        public int capacity;
        public List<T> slots;

        public PowerSet()
        {
            // ваша реализация хранилища
            slots = new List<T>();
            capacity = 0;
        }

        public int Size()
        {
            // количество элементов в множестве
            return capacity;
        }

        public void Put(T value)
        {
            // всегда срабатывает
            if (!Get(value))
            {
                slots.Add(value);
                capacity++;
            }
        }

        public bool Get(T value)
        {
            // возвращает true если value имеется в множестве,
            // иначе false
            return slots.Contains(value);
        }

        public bool Remove(T value)
        {
            // возвращает true если value удалено
            // иначе false
            if (Get(value))
            {
                slots.Remove(value);
                capacity--;
                return true;
            }
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            PowerSet<T> Intersected = new PowerSet<T>();
            if (capacity > 0 && set2.capacity > 0)
            {
                foreach (T item in slots)
                {
                    if (set2.Get(item))
                    {
                        Intersected.Put(item);
                    }
                }
            }
            return Intersected;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            PowerSet<T> United = new PowerSet<T>();
            if (capacity > 0)
            {
                foreach (var item in slots)
                {
                    United.Put(item);
                }
            }
            if (set2.capacity > 0)
            {
                foreach (var item in set2.slots)
                {
                    United.Put(item);
                }
            }
            return United;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            PowerSet<T> Differed = new PowerSet<T>();
            if (capacity > 0)
            {
                foreach (T item in slots)
                {
                    Differed.Put(item);
                }
                foreach (T item in set2.slots)
                {
                    Differed.Remove(item);
                }
            }
            return Differed;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            int count = 0;
            if (capacity >= set2.capacity)
            {
                foreach (T item in slots)
                {
                    if (set2.Get(item))
                    {
                        count++;
                    }
                }
                if (count == set2.capacity)
                {
                    return true;
                }
            }
            return false;
        }
    }
}