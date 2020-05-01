using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
                string emptV1 = v1.ToString().Trim();
                string emptV2 = v2.ToString().Trim();
                result = emptV1.CompareTo(emptV2) == 1 ? 1 : emptV1.CompareTo(emptV2) == 0 ? 0 : -1;
            }
            else
            {
                // универсальное сравнение
                result = Convert.ToInt32(v1) > Convert.ToInt32(v2) ? 1 : Convert.ToInt32(v1) == Convert.ToInt32(v2) ? 0 : -1;
            }

            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            // автоматическая вставка value 
            // в нужную позицию

            Node<T> _insert = new Node<T>(value);
            Node<T> node = head;

            if (head == tail && head == null)
            {
                head = _insert;
                tail = _insert;
                return;
            }

            if (node == head && ((Compare(node.value, value) != -1 && _ascending == true) || (Compare(node.value, value) != 1 && _ascending != true)))
            {
                head = _insert;
                _insert.next = node;
                node.prev = _insert;
                return;
            }

            while (node!=null)
            {
                if ((Compare(node.value, value) != -1 && _ascending == true) || (Compare(node.value, value) != 1 && _ascending != true))
                {
                    node.prev.next = _insert;
                    _insert.prev = node.prev;
                    _insert.next = node;
                    node.prev = _insert;                    
                    return;
                }

                else if (node == tail && ((Compare(node.value, value) != 1 && _ascending == true) || (Compare(node.value, value) != -1 && _ascending != true)))
                {
                    tail = _insert;
                    _insert.prev = node;
                    node.next = _insert;
                    return;
                }
                node = node.next;
            }
        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            while (node!=null)
            {
                if (Compare(node.value,val)==0)
                {
                    return node;
                }

                if (Compare(node.value,val)==1 && _ascending==true)
                {
                    break;
                }

                if (Compare(node.value, val) == -1 && _ascending != true)
                {
                    break;
                }
                node = node.next;
            }
            return null; // здесь будет ваш код
        }

        public void Delete(T val)
        {
            // здесь будет ваш код
            Node<T> node = head;
            while (node != null)
            {
                if (node == head && node == tail && Compare(node.value, val) == 0)
                {
                    head = null;
                    tail = null;
                    return;
                }
                else if (node == head && Compare(node.value, val) == 0)
                {
                    node.next.prev = null;
                    head = node.next;
                    return;
                }
                else if (node == tail && Compare(node.value, val) == 0)
                {
                    node.prev.next = null;
                    tail = node.prev;
                    return;
                }
                else if (Compare(node.value, val) == 0)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    return;
                }
                node = node.next;
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
            // здесь будет ваш код
        }

        public int Count()
        {
            int count = 0;
            Node<T> node = head;
            while (node!=null)
            {
                count++;
                node = node.next;
            }
            return count; // здесь будет ваш код подсчёта количества элементов в списке
        }

        List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                               // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }

}