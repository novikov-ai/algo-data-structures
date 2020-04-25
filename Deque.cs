using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    class Deque<T>
    {
        List<T> deque;
        int count;

        public Deque()
        {
            // инициализация внутреннего хранилища
            deque = new List<T>();
            count = 0;
        }

        public void AddFront(T item)
        {
            // добавление в голову
            deque.Insert(0, item);
            count++;
        }

        public void AddTail(T item)
        {
            // добавление в хвост
            deque.Add(item);
            count++;
        }

        public T RemoveFront()
        {
            // удаление из головы
            T cache;
            if (count!=0)
            {
                cache = deque[0];
                deque.RemoveAt(0);
                count--;
                return cache;
            }
            return default(T);
        }

        public T RemoveTail()
        {
            // удаление из хвоста
            T cache;
            if (count!=0)
            {
                cache = deque[count - 1];
                deque.RemoveAt(count - 1);
                count--;
                return cache;
            }
            return default(T);
        }

        public int Size()
        {
            if (count!=0)
            {
                return count;
            }
            return 0; // размер очереди
        }
    }

}