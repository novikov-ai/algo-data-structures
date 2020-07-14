using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            // ваш код добавления нового дочернего узла существующему ParentNode
            if (ParentNode.Children == null)
            {
                ParentNode.Children = new List<SimpleTreeNode<T>>();
            }
            ParentNode.Children.Add(NewChild);
            NewChild.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            // ваш код удаления существующего узла NodeToDelete
            SimpleTreeNode<T> ParentRemChild;
            List<SimpleTreeNode<T>> RootChildren = GetChildren(Root);
            foreach (SimpleTreeNode<T> node in RootChildren)
            {
                if (node == NodeToDelete)
                {
                    ParentRemChild = node.Parent;
                    ParentRemChild.Children.Remove(node);
                    if (ParentRemChild.Children.Count == 0)
                    {
                        ParentRemChild.Children = null;
                    }
                    return;
                }
            }
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            // ваш код выдачи всех узлов дерева в определённом порядке
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = new List<SimpleTreeNode<T>>();
                AllNodes.Add(Root);
                AllNodes.AddRange(GetChildren(Root));
                return AllNodes;
            }
            return null;
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            // ваш код поиска узлов по значению
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                List<SimpleTreeNode<T>> NodesByValue = new List<SimpleTreeNode<T>>();

                foreach (SimpleTreeNode<T> node in AllNodes)
                {
                    if (node.NodeValue.Equals(val))
                    {
                        NodesByValue.Add(node);
                    }
                }
                if (NodesByValue.Count > 0)
                {
                    return NodesByValue;
                }
            }
            return null;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            // ваш код перемещения узла вместе с его поддеревом -- 
            // в качестве дочернего для узла NewParent

            if (Root != null)
            {
                SimpleTreeNode<T> OldParent;
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                foreach (SimpleTreeNode<T> node in AllNodes)
                {
                    if (node == OriginalNode)
                    {
                        OldParent = node.Parent;
                        node.Parent = NewParent;
                        AddChild(NewParent, node);
                        OldParent.Children.Remove(node);
                        if (OldParent.Children.Count == 0)
                        {
                            OldParent.Children = null;
                        }
                        return;
                    }
                }
            }
        }

        public int Count()
        {
            // количество всех узлов в дереве
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                return AllNodes.Count;
            }
            return 0;
        }

        public int LeafCount()
        {
            // количество листьев в дереве
            if (Root != null)
            {
                List<SimpleTreeNode<T>> AllNodes = GetAllNodes();
                int count = 0;
                foreach (SimpleTreeNode<T> node in AllNodes)
                {
                    if (node.Children == null)
                    {
                        count++;
                    }
                }
                return count;
            }
            return 0;
        }

        public List<SimpleTreeNode<T>> GetChildren(SimpleTreeNode<T> Node)
        {
            List<SimpleTreeNode<T>> Children = new List<SimpleTreeNode<T>>();
            if (Node.Children != null)
            {
                foreach (SimpleTreeNode<T> node in Node.Children)
                {
                    Children.Add(node);
                    Children.AddRange(GetChildren(node));
                }
            }
            return Children;
        }
    }
}