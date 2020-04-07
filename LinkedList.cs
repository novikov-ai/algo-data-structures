using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
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
            // здесь будет ваш код удаления одного узла по заданному значению
            Node node = head;
            while (node != null)
            {
                if (node == head && node == tail && node.value == _value)
                {
                    head = null;
                    tail = null;
                    return true;
                }
                else if (node == head && head.value == _value)
                {
                    head = head.next;
                    return true;
                }
                else if (node.next == tail && node.next.value == _value)
                {
                    tail = node;
                    node.next = null;
                    return true;
                }
                else if (node.next == null && node.value != _value)
                {
                    Console.WriteLine("Удаление не будет выполнено. Узла с таким значением нет.");
                    break;
                }
                else if (node.next.value == _value)
                {
                    node.next = node.next.next;
                    return true;
                }
                node = node.next;
            }
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
                    head = node.next;
                    continue;
                }

                else if (node.next == tail && node.next.value == _value)
                {
                    node.next = null;
                    tail = node;
                    continue;
                }

                else if (node.next != null && node.next.value == _value)
                {
                    node.next = node.next.next;
                    continue;
                }
                node = node.next;
            }
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
            int counter = 0;
            while (node != null)
            {
                counter++;
                node = node.next;
            }
            return counter; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // здесь будет ваш код вставки узла после заданного
            Node node = head;
            while (node != null)
            {
                if (_nodeAfter == null)
                {
                    _nodeToInsert.next = node;
                    head = _nodeToInsert;
                    return;
                }

                else if (node == head && node == tail && node == _nodeAfter)
                {
                    node.next = _nodeToInsert;
                    tail = _nodeToInsert;
                    return;
                }

                else if (node.next == tail && node.next == _nodeAfter)
                {
                    node.next.next = _nodeToInsert;
                    tail = _nodeToInsert;
                    return;
                }

                else if (node == _nodeAfter)
                {
                    _nodeToInsert.next = node.next;
                    node.next = _nodeToInsert;
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
            return;
            // если _nodeAfter = null , 
            // добавьте новый элемент первым в списке 
        }
    }
}