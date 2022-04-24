using System;
using System.Collections.Generic;

namespace AlgoDataStructures.AlgoPart1
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            // ваш код
            capacity = new_capacity < 16 ? 16 : new_capacity;
            T[] newArray = new T[capacity];
            if (array != null)
            {
                Array.Copy(array, 0, newArray, 0, count);
            }
            array = newArray;
        }

        public T GetItem(int index)
        {
            // ваш код
            if (index > count) { throw new IndexOutOfRangeException(); return default(T); }
            return array[index];
        }

        public void Append(T itm)
        {
            // ваш код
            if (count == capacity) { MakeArray(capacity * 2); }
            array[count++] = itm;
        }

        public void Insert(T itm, int index)
        {
            // ваш код
            if (index > count) { throw new IndexOutOfRangeException(); }
            if (count == capacity) { MakeArray(capacity * 2); }
            T[] newArray = new T[capacity];
            if (index == 0)
            {
                Array.Copy(array, 0, newArray, 1, count);
                newArray[0] = itm;
                count++;
            }
            else if (index == count)
            {
                array.CopyTo(newArray, 0);
                newArray[count] = itm;
                count++;
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index, newArray, index + 1, count - index);
                newArray[index] = itm;
                count++;
            }
            array = newArray;
        }

        public void Remove(int index)
        {
            // ваш код
            if (index > count) { throw new IndexOutOfRangeException(); }
            if (100 * (count - 1) / capacity < 50)
            {
                int newCapacity = (int)(capacity / 1.5);
                capacity = newCapacity < 16 ? 16 : newCapacity;
                MakeArray(capacity);
            }
            T[] newArray = new T[capacity];
            if (index == 0)
            {
                Array.Copy(array, 1, newArray, 0, --count);
            }
            else if (index == count)
            {
                Array.Copy(array, 0, newArray, 0, --count);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + 1, newArray, index, --count - index);
            }
            array = newArray;
        }
    }
}