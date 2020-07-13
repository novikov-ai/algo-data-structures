using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures2
{
    [TestClass]
    public class SimpleTreeNodeTests
    {
        SimpleTree<int> Tree;

        SimpleTreeNode<int> Node0;
        SimpleTreeNode<int> Node1;
        SimpleTreeNode<int> Node2;
        SimpleTreeNode<int> Node3;
        SimpleTreeNode<int> Node4;
        SimpleTreeNode<int> Node5;
        SimpleTreeNode<int> Node6;
        SimpleTreeNode<int> Node7;
        SimpleTreeNode<int> Node8;
        SimpleTreeNode<int> Node9;
        SimpleTreeNode<int> Node10;
        SimpleTreeNode<int> Node11;
        SimpleTreeNode<int> Node12;

        [TestInitialize]
        public void TestInitialize()
        {
            Node0 = new SimpleTreeNode<int>(777, null);
            Tree = new SimpleTree<int>(Node0);

            Node1 = new SimpleTreeNode<int>(10, null);
            Node2 = new SimpleTreeNode<int>(20, null);
            Node3 = new SimpleTreeNode<int>(30, null);
            Node4 = new SimpleTreeNode<int>(40, null);
            Node5 = new SimpleTreeNode<int>(50, null);
            Node6 = new SimpleTreeNode<int>(60, null);
            Node7 = new SimpleTreeNode<int>(70, null);
            Node8 = new SimpleTreeNode<int>(80, null);
            Node9 = new SimpleTreeNode<int>(90, null);
            Node10 = new SimpleTreeNode<int>(60, null);

            Tree.AddChild(Node0, Node1);
            Tree.AddChild(Node1, Node2);
            Tree.AddChild(Node1, Node7);
            Tree.AddChild(Node2, Node3);
            Tree.AddChild(Node2, Node5);
            Tree.AddChild(Node1, Node4);
            Tree.AddChild(Node3, Node8);
            Tree.AddChild(Node3, Node9);
            Tree.AddChild(Node9, Node10);
            Tree.AddChild(Node9, Node6);
        }

        [TestMethod]
        public void AddChild()
        {
            Node11 = new SimpleTreeNode<int>(110, null);
            Node12 = new SimpleTreeNode<int>(120, null);

            // 1 child was added
            Tree.AddChild(Node0, Node11);
            Assert.AreEqual(777, Tree.Root.NodeValue);
            Assert.AreEqual(2, Tree.Root.Children.Count);
            Assert.AreEqual(Node0, Tree.Root.Children[0].Parent);
            Assert.AreEqual(12, Tree.Count());

            // 2 children were added
            Tree.AddChild(Node1, Node12);
            Assert.AreEqual(10, Tree.Root.Children[0].NodeValue);
            Assert.AreEqual(4, Tree.Root.Children[0].Children.Count);
            Assert.AreEqual(Node1, Tree.Root.Children[0].Children[0].Parent);
            Assert.AreEqual(120, Tree.Root.Children[0].Children[3].NodeValue);
            Assert.AreEqual(13, Tree.Count());

        }

        [TestMethod]
        public void DeleteNode()
        {
            // 1 removed
            Tree.DeleteNode(Node4);
            Assert.AreEqual(10, Tree.Count());

            // 7 removed
            Assert.AreEqual(2, Tree.FindNodesByValue(20)[0].Children.Count);
            Tree.DeleteNode(Node2);
            Assert.AreEqual(3, Tree.Count());
            Assert.AreEqual(null, Tree.FindNodesByValue(20));
            Assert.AreEqual(null, Tree.FindNodesByValue(80));

        }

        [TestMethod]
        public void GetAllNodes()
        {
            Assert.AreEqual(11, Tree.GetAllNodes().Count);
        }

        [TestMethod]
        public void FindNodesByValue()
        {
            Assert.AreEqual(Node1, Tree.FindNodesByValue(10)[0]);
            Assert.AreEqual(Node2, Tree.FindNodesByValue(20)[0]);
            Assert.AreEqual(Node3, Tree.FindNodesByValue(30)[0]);
            Assert.AreEqual(Node4, Tree.FindNodesByValue(40)[0]);
            Assert.AreEqual(2, Tree.FindNodesByValue(60).Count);

            Assert.AreEqual(null, Tree.FindNodesByValue(1215));
        }

        [TestMethod]
        public void MoveNode()
        {
            Assert.AreEqual(11, Tree.Count());
            Assert.AreEqual(Node2, Tree.FindNodesByValue(30)[0].Parent);
            Assert.AreEqual(2, Tree.FindNodesByValue(30)[0].Children.Count);
            Assert.AreEqual(6, Tree.LeafCount());
            Assert.AreEqual(null, Tree.FindNodesByValue(40)[0].Children);

            Tree.MoveNode(Node3, Node4);

            Assert.AreEqual(11, Tree.Count());
            Assert.AreEqual(Node4, Tree.FindNodesByValue(30)[0].Parent);
            Assert.AreEqual(2, Tree.FindNodesByValue(30)[0].Children.Count);
            Assert.AreEqual(5, Tree.LeafCount());
            Assert.AreEqual(1, Tree.FindNodesByValue(40)[0].Children.Count);
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(11, Tree.Count());

            Tree.DeleteNode(Node10);
            Tree.DeleteNode(Node6);
            Tree.DeleteNode(Node9);

            Assert.AreEqual(8, Tree.Count());

            Tree.DeleteNode(Node2);

            Assert.AreEqual(4, Tree.Count());
        }

        [TestMethod]
        public void LeafCount()
        {
            Assert.AreEqual(6, Tree.LeafCount());

            Tree.DeleteNode(Node3);

            Assert.AreEqual(3, Tree.LeafCount());
        }
    }
}
