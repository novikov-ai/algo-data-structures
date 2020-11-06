using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }

        public Vertex<T> prev;
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public int capacity;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];

            capacity = 0;
        }

        public void AddVertex(T value)
        {
            // ваш код добавления новой вершины 
            // с значением value 
            // в свободную позицию массива vertex

            if (capacity < max_vertex)
            {
                Vertex<T> newVertex = new Vertex<T>(value);
                vertex[capacity] = newVertex;
                capacity++;
            }
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            // ваш код удаления вершины со всеми её рёбрами

            if (capacity > 0 && (vertex[v] != null))
            {
                vertex[v] = null;

                for (int i = 0; i < capacity; i++)
                {
                    m_adjacency[v, i] = 0;
                    m_adjacency[i, v] = 0;
                }

                capacity--;
            }
        }

        public bool IsEdge(int v1, int v2)
        {
            // true если есть ребро между вершинами v1 и v2
            if (capacity > 1)
            {
                if ((m_adjacency[v1, v2] == 1) && (m_adjacency[v2, v1] == 1))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddEdge(int v1, int v2)
        {
            // добавление ребра между вершинами v1 и v2

            if (capacity > 1)
            {
                m_adjacency[v1, v2] = 1;
                m_adjacency[v2, v1] = 1;
            }
        }

        public void RemoveEdge(int v1, int v2)
        {
            // удаление ребра между вершинами v1 и v2

            if (capacity > 1)
            {
                m_adjacency[v1, v2] = 0;
                m_adjacency[v2, v1] = 0;
            }
        }

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            // Узлы задаются позициями в списке vertex.
            // Возвращается список узлов -- путь из VFrom в VTo.
            // Список пустой, если пути нету.

            Stack<Vertex<T>> Result = new Stack<Vertex<T>>();
            List<Vertex<T>> Path = new List<Vertex<T>>();

            if (VFrom >= capacity || VTo >= capacity || VFrom < 0 || VTo < 0) // Обработка некорректного ввода
                return Path;
            if (VFrom == VTo) { Path.Add(vertex[VFrom]); return Path; }

            foreach (Vertex<T> item in vertex)
            {
                if (item != null)
                    item.Hit = false;
            }

            Vertex<T> Select = vertex[VFrom];

            bool newSelect = true;
            int newSelectIndex = -1;

            while (Select != null)
            {
                if (newSelect == true)
                {
                    Result.Push(Select);
                    Select.Hit = true;
                    newSelect = false;
                }

                for (int i = 0; i < capacity; i++)
                {
                    if (IsEdge(Array.IndexOf(vertex, Select), i) == true)
                    {
                        if (vertex[i] == vertex[VTo])
                        {
                            Result.Push(vertex[i]);
                            Path.AddRange(Result);
                            Path.Reverse();

                            return Path;
                        }

                        if (newSelect == false && vertex[i].Hit == false) // Код для запоминания смежного узла, у которого не было посещения
                        {
                            newSelectIndex = i;
                            newSelect = true;
                        }
                    }
                }

                if (newSelectIndex != -1) { Select = vertex[newSelectIndex]; }

                if (newSelect == false) // Если нет непосещенных узлов
                {
                    Result.Pop();
                    if (Result.Count > 0)
                    {
                        Select = Result.Peek();
                        newSelect = false;
                    }
                    else
                        Select = null;
                }
            }
            return Path;
        }

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            // узлы задаются позициями в списке vertex.
            // возвращает список узлов -- путь из VFrom в VTo
            // или пустой список, если пути нету

            List<Vertex<T>> Path = new List<Vertex<T>>();
            Queue<Vertex<T>> Result = new Queue<Vertex<T>>();

            if (VFrom >= capacity || VTo >= capacity || VFrom < 0 || VTo < 0) // Обработка некорректного ввода
                return Path;
            if (VFrom == VTo) { Path.Add(vertex[VFrom]); return Path; }

            foreach (Vertex<T> item in vertex)
            {
                if (item != null)
                    item.Hit = false;
            }

            Vertex<T> Select = vertex[VFrom];

            while (Select != null)
            {
                Select.Hit = true;
                if (Select == vertex[VTo])
                {
                    do
                    {
                        Path.Add(Select);
                        Select = Select.prev;
                    } while (Select != vertex[VFrom]);

                    Path.Add(vertex[VFrom]);
                    Path.Reverse();

                    return Path;
                }

                for (int i = 0; i < capacity; i++)
                {
                    if (vertex[i].Hit == false && IsEdge(Array.IndexOf(vertex, Select), i) == true)
                    {
                        Result.Enqueue(vertex[i]); // Добавляем все смежные в очередь
                        vertex[i].prev = Select; // Добавляем ссылку на предыдущий узел
                    }
                }

                if (Result.Count > 0)
                    Select = Result.Dequeue(); // Берем из очереди смежную вершину
                else
                    Select = null;
            }

            return Path;
        }
    }
}