using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public int size;
        public int capacity;

        public void MakeHeap(int[] a, int depth)
        {
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            // ...

            size = (int)Math.Pow(2, depth + 1) - 1;
            capacity = 0;
            HeapArray = new int[size];

            for (int i = 0; i < a.Length; i++)
                Add(a[i]);
        }

        public int GetMax()
        {
            // вернуть значение корня и перестроить кучу
            if (HeapArray.Length > 0)
            {
                int max = HeapArray[0];
                HeapArray[0] = HeapArray[HeapArray.Length - 1];

                int shift;
                int index = 0;

                if (HeapArray.Length > 1)
                {
                    Array.Clear(HeapArray, HeapArray.Length - 1, 1);

                    for (int i = 0; i < HeapArray.Length; i = index)
                    {
                        if (((2 * i + 1) < HeapArray.Length) && ((2 * i + 2) < HeapArray.Length - 1))
                        {
                            if (HeapArray[2 * i + 2] > HeapArray[2 * i + 1])
                            {
                                if (HeapArray[2 * i + 2] > HeapArray[i])
                                {
                                    // меняем местами с правым
                                    index = 2 * i + 2;
                                    shift = HeapArray[i];
                                    HeapArray[i] = HeapArray[index];
                                    HeapArray[index] = shift;
                                }
                                else
                                {
                                    // оставляем на своем месте
                                    break;
                                }
                            }
                            else
                            {
                                if (HeapArray[2 * i + 1] > HeapArray[i])
                                {
                                    // меняем местами с левым
                                    index = 2 * i + 1;
                                    shift = HeapArray[i];
                                    HeapArray[i] = HeapArray[index];
                                    HeapArray[index] = shift;
                                }
                                else
                                {
                                    // оставляем на своем месте
                                    break;
                                }
                            }
                        }
                        else
                            break;
                    }
                }
                else
                    Array.Clear(HeapArray, 0, 1); // очистка массива из 1 элемента

                capacity--;
                return max;
            }
            else
                return -1; // если куча пуста
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            if (capacity < size)
            {
                int index = capacity;
                HeapArray[index] = key;
                int shift;

                for (int i = 0; i >= 0; i = index)
                {
                    int parent;

                    if (index % 2 == 0) // проверяем четность индекса, чтобы вычислить родителя
                    {
                        parent = (index - 2) / 2;
                    }
                    else
                        parent = (index - 1) / 2;

                    if (parent < 0)
                        break;

                    if (HeapArray[parent] < HeapArray[index])
                    {
                        // меняем местами

                        shift = HeapArray[parent];
                        HeapArray[parent] = HeapArray[index];
                        HeapArray[index] = shift;
                        index = parent;
                    }
                    else
                        break;
                }

                capacity++;
                return true;
            }
            return false; // если куча вся заполнена
        }
    }
}