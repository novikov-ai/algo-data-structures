using System;
using System.Collections.Generic;

namespace AlgoDataStructures.AlgoPart1
{

    public class Stack<T>
    {
        List<T> stack;
        int count;
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            stack = new List<T>();
            count = 0;
        }

        public int Size()
        {
            // размер текущего стека
            if (count!=0)
            {
                return count;
            }
            return 0;
        }

        public T Pop()
        {
            // ваш код
            if (count!=0)
            {
                T popElem = stack[count - 1];
                stack.RemoveAt(count-1);
                count--;
                return popElem;
            }
            return default(T); // null, если стек пустой
        }

        public void Push(T val)
        {
            // ваш код
            stack.Add(val);
            count++;
        }

        public T Peek()
        {
            // ваш код
            if (count!=0)
            {
                return stack[count - 1];
            }
            return default(T); // null, если стек пустой
        }
    }

}