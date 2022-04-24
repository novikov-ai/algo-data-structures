using System;
using System.Collections.Generic;

namespace AlgoDataStructures.AlgoPart1
{

    public class Queue<T>
    {
        List<T> queue;
        int count;

        public Queue()
        {
            // инициализация внутреннего хранилища очереди
            queue = new List<T>();
            count = 0;
        }

        public void Enqueue(T item)
        {
            // вставка в хвост
            queue.Add(item);
            count++;
        }

        public T Dequeue()
        {
            // выдача из головы
            if (count!=0)
            {
                T cache = queue[0];
                queue.RemoveAt(0);
                count--;
                return cache;
            }
            return default(T); // если очередь пустая
        }

        public int Size()
        {
            if (count !=0)
            {
                return count;
            }
            return 0; // размер очереди
        }

    }
}