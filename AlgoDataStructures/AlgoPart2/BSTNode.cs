using System;
using System.Collections.Generic;

namespace AlgoDataStructures.AlgoPart2.AlgoPart2
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
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
            }
            else
            {
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
                }
                else
                    return false; // если ключ уже есть
            }
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            // ищем максимальное/минимальное в поддереве
            BSTNode<T> selectedNode = FromNode;

            if (selectedNode != null && Root != null)
            {
                if (FindNodeByKey(selectedNode.NodeKey).NodeHasKey)
                {
                    if (FindMax == false)
                    {
                        while (selectedNode.LeftChild != null)
                        {
                            selectedNode = selectedNode.LeftChild;
                        }
                    }
                    else
                    {
                        while (selectedNode.RightChild != null)
                        {
                            selectedNode = selectedNode.RightChild;
                        }
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


            if (foundNode.NodeHasKey == true)
            {
                if (Node.LeftChild != null && Node.RightChild != null) // CASE (node has R & L children)
                {
                    if (Node == Root)
                    {
                        successorNode = FinMinMax(Node.RightChild, false); // searching for a successor
                        if (GetAllNodes(successorNode).Count == 1) // if successor have 0 children
                        {
                            Node.RightChild.Parent = null;
                            Node.LeftChild.Parent = successorNode;
                            successorNode.LeftChild = Node.LeftChild;
                            Root = Node.RightChild;
                        }
                        else
                        {
                            if (successorNode != Node.RightChild)
                            {
                                successorNode.Parent.LeftChild = null;
                                successorNode.Parent = null;

                                Root.LeftChild.Parent = successorNode;
                                successorNode.LeftChild = Root.LeftChild;

                                Root.RightChild.Parent = successorNode;
                                successorNode.RightChild = Root.RightChild;
                                Root = successorNode;
                            }
                            else
                            {
                                Root.LeftChild.Parent = successorNode;
                                successorNode.LeftChild = Root.LeftChild;

                                Root.RightChild.Parent = null;
                                Root = successorNode;
                            }
                        }
                    }
                    else
                    {
                        successorNode = FinMinMax(Node.RightChild, false); // searching for a successor

                        if (successorNode != Node.RightChild)
                        {
                            successorNode.Parent.LeftChild = null;
                            successorNode.Parent = Node.Parent;

                            if (Node.Parent.LeftChild == Node)
                            {
                                Node.Parent.LeftChild = successorNode;
                            }
                            else
                                Node.Parent.RightChild = successorNode;

                            if (Node.LeftChild != null)
                            {
                                Node.LeftChild.Parent = successorNode;
                                successorNode.LeftChild = Node.LeftChild;
                            }
                            if (Node.RightChild != null)
                            {
                                Node.RightChild.Parent = successorNode;
                                successorNode.RightChild = Node.RightChild;
                            }
                        }
                        else
                        {
                            successorNode.Parent = Node.Parent;

                            if (Node.Parent.LeftChild == Node)
                            {
                                Node.Parent.LeftChild = successorNode;
                            }
                            else
                                Node.Parent.RightChild = successorNode;

                            successorNode.LeftChild = Node.LeftChild;
                            Node.LeftChild.Parent = successorNode;
                        }
                    }
                }
                else // CASE (node has R/L || 0 children)
                {
                    if (Node == Root)
                    {
                        if (GetAllNodes(Root).Count == 1) // CASE (node = root && has 0 children)
                            Root = null;
                        else // CASE (node = root && has 1 child)
                        {
                            if (Node.LeftChild != null)
                            {
                                Node.LeftChild.Parent = null;
                                Root = Node.LeftChild;
                            }
                            else
                            {
                                Node.RightChild.Parent = null;
                                Root = Node.RightChild;
                            }
                        }
                    }
                    else // CASE (node has 1 child)
                    {
                        if (Node.LeftChild == null && Node.RightChild == null)
                        {
                            if (Node.Parent.LeftChild == Node)
                                Node.Parent.LeftChild = null;
                            else
                                Node.Parent.RightChild = null;
                            Node.Parent = null;
                        }

                        else if (Node.LeftChild != null)
                        {
                            Node.LeftChild.Parent = Node.Parent;

                            if (Node.Parent.LeftChild == Node)
                                Node.Parent.LeftChild = Node.LeftChild;
                            else
                                Node.Parent.RightChild = Node.RightChild;
                        }
                        else
                        {
                            Node.RightChild.Parent = Node.Parent;

                            if (Node.Parent.LeftChild == Node)
                                Node.Parent.LeftChild = Node.LeftChild;
                            else
                                Node.Parent.RightChild = Node.RightChild;
                        }
                    }
                }

                return true;
            }
            else
                return false;
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

        public List<BSTNode<T>> WideAllNodes()
        {
            List<BSTNode<T>> WideList = new List<BSTNode<T>>();
            Queue<BSTNode<T>> NodesQueue = new Queue<BSTNode<T>>();
            BSTNode<T> Node = Root;
            NodesQueue.Enqueue(Root);

            if (Root != null)
            {
                while (NodesQueue.Count > 0)
                {
                    Node = NodesQueue.Dequeue();
                    WideList.Add(Node);

                    if (Node.LeftChild != null)
                        NodesQueue.Enqueue(Node.LeftChild);
                    if (Node.RightChild != null)
                        NodesQueue.Enqueue(Node.RightChild);
                }
                return WideList;
            }
            return null;
        }

        public List<BSTNode<T>> DeepAllNodes(int Order)
        {
            return DeepTraversing(Root, Order);
        }

        public List<BSTNode<T>> DeepTraversing(BSTNode<T> fromNode, int Order)
        {
            List<BSTNode<T>> DeepList = new List<BSTNode<T>>();
            BSTNode<T> Node = fromNode;

            if (Node != null)
            {
                switch (Order)
                {
                    case 0: // in-order
                        {
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.Add(Node);
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));

                            break;
                        }

                    case 1: // post-order
                        {
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));
                            DeepList.Add(Node);

                            break;
                        }

                    case 2: // pre-order
                        {
                            DeepList.Add(Node);
                            DeepList.AddRange(DeepTraversing(Node.LeftChild, Order));
                            DeepList.AddRange(DeepTraversing(Node.RightChild, Order));
                            break;
                        }

                    default:
                        return null;
                }
            }
            return DeepList;
        }
    }
}