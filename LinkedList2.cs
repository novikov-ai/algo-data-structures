using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            // здесь будет ваш код поиска
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            // здесь будет ваш код поиска всех узлов по заданному значению
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                    node = node.next;
                }
                else
                {
                    node = node.next;
                }
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node == head && node == tail && node.value == _value)
                {
                    head = null;
                    tail = null;
                    return true;
                }
                else if (node == head && node.value == _value)
                {
                    node.next.prev = null;
                    head = node.next;
                    return true;
                }
                else if (node == tail && node.value == _value)
                {
                    node.prev.next = null;
                    tail = node.prev;
                    return true;
                }
                else if (node.value == _value)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    return true;
                }
                node = node.next;
            }
            // здесь будет ваш код удаления одного узла по заданному значению
            return true; // если узел был удалён
        }

        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            Node node = head;
            while (node != null)
            {
                if (node == head && node == tail && node.value == _value)
                {
                    head = null;
                    tail = null;
                    return;
                }
                else if (node == head && node.value == _value)
                {
                    node.next.prev = null;
                    head = node.next;
                }
                else if (node == tail && node.value == _value)
                {
                    node.prev.next = null;
                    tail = node.prev;
                }
                else if (node.value == _value)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                }
                node = node.next;
            }
            return;
        }

        public void Clear()
        {
            // здесь будет ваш код очистки всего списка
            Node node = head;
            while (node != null)
            {
                head = null;
                tail = null;
                node = node.next;
            }
        }

        public int Count()
        {
            Node node = head;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // здесь будет ваш код вставки узла после заданного узла
            Node node = head;
            while (node != null)
            {
                if (_nodeAfter == null)
                {
                    node.prev = _nodeToInsert;
                    _nodeToInsert.next = node;
                    head = _nodeToInsert;
                    return;
                }
                else if (node == tail && node == _nodeAfter)
                {
                    node.next = _nodeToInsert;
                    _nodeToInsert.prev = node;
                    tail = _nodeToInsert;
                    return;
                }
                else if (node == _nodeAfter)
                {
                    _nodeToInsert.next = node.next;
                    node.next.prev = _nodeToInsert;
                    node.next = _nodeToInsert;
                    _nodeToInsert.prev = node;
                    return;
                }
                node = node.next;
            }
            if (_nodeAfter == null)
            {
                head = _nodeToInsert;
                tail = _nodeToInsert;
                return;
            }
            // если _nodeAfter = null
            // добавьте новый элемент первым в списке 

        }

    }
}