using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null
        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу
            if (Root == null)
                return null;

            BSTNode<T> selectedNode = Root;
            BSTFind<T> newSearch = new BSTFind<T>();

            while (newSearch.NodeHasKey == true || newSearch.NodeHasKey == false)
            {
                if (key == selectedNode.NodeKey)
                {
                    newSearch.Node = selectedNode;
                    newSearch.NodeHasKey = true;
                    return newSearch;
                }

                if (key < selectedNode.NodeKey)
                {
                    if (selectedNode.LeftChild != null)
                        selectedNode = selectedNode.LeftChild;
                    else
                    {
                        newSearch.Node = selectedNode;
                        newSearch.NodeHasKey = false;
                        newSearch.ToLeft = true;
                        return newSearch;
                    }
                }
                else
                {
                    if (selectedNode.RightChild != null)
                        selectedNode = selectedNode.RightChild;
                    else
                    {
                        newSearch.Node = selectedNode;
                        newSearch.NodeHasKey = false;
                        newSearch.ToLeft = false;
                        return newSearch;
                    }
                }
            }
            return newSearch;
        }


        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево
            BSTFind<T> foundNode = FindNodeByKey(key);

            if (foundNode.NodeHasKey == false)
            {
                BSTNode<T> newNode = new BSTNode<T>(key, val, foundNode.Node);
                if (foundNode.ToLeft == true)
                {
                    foundNode.Node.LeftChild = newNode;
                    newNode.Parent = foundNode.Node;
                }
                else
                {
                    foundNode.Node.RightChild = newNode;
                    newNode.Parent = foundNode.Node;
                }
                return true;
            }
            else
                return false; // если ключ уже есть
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальное/минимальное в поддереве
            BSTNode<T> selectedNode = FromNode;

            if (selectedNode != null)
            {
                if (FindMax == false)
                {
                    while (selectedNode.LeftChild != null)
                    {
                        selectedNode = selectedNode.LeftChild;
                    }
                    return selectedNode;
                }
                else
                {
                    while (selectedNode.RightChild != null)
                    {
                        selectedNode = selectedNode.RightChild;
                    }
                    return selectedNode;
                }
            }
            return null;
        }

        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            BSTFind<T> foundNode = FindNodeByKey(key);
            BSTNode<T> Node = foundNode.Node;
            BSTNode<T> successorNode;

            if (Root == Node && GetAllNodes(Root).Count == 1) // CASE 1 (only root)
                Root = null;

            if (foundNode.NodeHasKey == true)
            {
                if (Node.LeftChild != null && Node.RightChild != null) // CASE 2 (2 children!)
                {
                    successorNode = FinMinMax(Node.RightChild, false); // searching for a successor

                    if (successorNode.RightChild != null) // child of successor
                    {
                        successorNode.Parent.LeftChild = successorNode.RightChild;
                        successorNode.RightChild.Parent = successorNode.Parent;
                    }

                    successorNode.Parent = Node.Parent;
                    if (Node.Parent.LeftChild == Node)
                        Node.Parent.LeftChild = successorNode;
                    if (Node.Parent.RightChild == Node)
                        Node.Parent.RightChild = successorNode;

                    Node.LeftChild.Parent = successorNode;
                    successorNode.LeftChild = Node.LeftChild;
                }

                else
                {
                    if (Node.LeftChild != null || Node.RightChild != null) // CASE 3 (1 child)
                    {
                        if (Node.LeftChild != null)
                        {
                            Node.LeftChild.Parent = Node.Parent;
                            if (Node.Parent.LeftChild == Node)
                                Node.Parent.LeftChild = Node.LeftChild;
                            if (Node.Parent.RightChild == Node)
                                Node.Parent.RightChild = Node.LeftChild;
                        }
                        else
                        {
                            Node.RightChild.Parent = Node.Parent;
                            if (Node.Parent.LeftChild == Node)
                                Node.Parent.LeftChild = Node.RightChild;
                            if (Node.Parent.RightChild == Node)
                                Node.Parent.RightChild = Node.RightChild;
                        }
                    }

                    else // CASE 4 (no children)
                    {
                        if (Node.Parent.LeftChild != null && Node.Parent.LeftChild == Node)
                            Node.Parent.LeftChild = null;
                        if (Node.Parent.RightChild != null && Node.Parent.RightChild == Node)
                            Node.Parent.RightChild = null;
                        Node.Parent = null;
                    }
                }
                return true;
            }
            else
                return false; // если узел не найден
        }

        public int Count()
        {
            if (Root != null)
            {
                return GetAllNodes(Root).Count;
            }
            return 0; // количество узлов в дереве
        }

        public List<BSTNode<T>> GetAllNodes(BSTNode<T> Root)
        {
            List<BSTNode<T>> Nodes = new List<BSTNode<T>>(); // all nodes
            Nodes.Add(Root);

            if (Root.LeftChild != null)
                Nodes.AddRange(GetAllNodes(Root.LeftChild));

            if (Root.RightChild != null)
                Nodes.AddRange(GetAllNodes(Root.RightChild));

            return Nodes;
        }
    }
}