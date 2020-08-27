using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    [TestClass]
    public class BSTNodeTests
    {
        BST<int> Tree;
        BST<int> ZeroTree;

        [TestInitialize]
        public void TestInitialize()
        {

            ZeroTree = new BST<int>(null);
            Tree = new BST<int>(null);

            Tree.AddKeyValue(50, 50);
            Tree.AddKeyValue(100, 100);
            Tree.AddKeyValue(25, 25);
            Tree.AddKeyValue(150, 150);
            Tree.AddKeyValue(10, 10);
            Tree.AddKeyValue(30, 30);
            Tree.AddKeyValue(80, 80);
            Tree.AddKeyValue(75, 75);
            Tree.AddKeyValue(79, 79);
        }

        [TestMethod]
        public void FindNodeByKey()
        {
            // find in ZeroTree
            Assert.AreEqual(null, ZeroTree.FindNodeByKey(20));

            // find missing left key
            Assert.AreEqual(true, Tree.FindNodeByKey(8).ToLeft);
            Assert.AreEqual(false, Tree.FindNodeByKey(8).NodeHasKey);
            Assert.AreEqual(10, Tree.FindNodeByKey(8).Node.NodeKey);

            // find missing right key
            Assert.AreEqual(false, Tree.FindNodeByKey(200).ToLeft);
            Assert.AreEqual(false, Tree.FindNodeByKey(200).NodeHasKey);
            Assert.AreEqual(150, Tree.FindNodeByKey(200).Node.NodeKey);

            // find existing key
            Assert.AreEqual(false, Tree.FindNodeByKey(80).ToLeft);
            Assert.AreEqual(true, Tree.FindNodeByKey(80).NodeHasKey);
            Assert.AreEqual(80, Tree.FindNodeByKey(80).Node.NodeKey);
            Assert.AreEqual(100, Tree.FindNodeByKey(80).Node.Parent.NodeKey);
            Assert.AreEqual(75, Tree.FindNodeByKey(80).Node.LeftChild.NodeKey);
            Assert.AreEqual(null, Tree.FindNodeByKey(80).Node.RightChild);
        }

        [TestMethod]
        public void AddKeyValue()
        {
            // adding to ZeroTree
            Assert.AreEqual(0, ZeroTree.Count());
            ZeroTree.AddKeyValue(150, 150);
            ZeroTree.AddKeyValue(10, 10);
            ZeroTree.AddKeyValue(30, 30);
            Assert.AreEqual(3, ZeroTree.Count());

            // adding the same values
            Assert.AreEqual(9, Tree.Count());
            Tree.AddKeyValue(150, 150);
            Tree.AddKeyValue(10, 10);
            Tree.AddKeyValue(30, 30);
            Assert.AreEqual(9, Tree.Count());

            Assert.AreEqual(false, Tree.FindNodeByKey(-50).NodeHasKey);
            Assert.AreEqual(false, Tree.FindNodeByKey(35).NodeHasKey);
            Assert.AreEqual(false, Tree.FindNodeByKey(160).NodeHasKey);

            // adding the new values
            Tree.AddKeyValue(-50, -50);
            Tree.AddKeyValue(35, 35);
            Tree.AddKeyValue(160, 160);
            Assert.AreEqual(12, Tree.Count());

            Assert.AreEqual(true, Tree.FindNodeByKey(-50).NodeHasKey);
            Assert.AreEqual(true, Tree.FindNodeByKey(35).NodeHasKey);
            Assert.AreEqual(true, Tree.FindNodeByKey(160).NodeHasKey);
        }

        [TestMethod]
        public void FinMinMax()
        {
            BSTNode<int> Node = new BSTNode<int>(42, 42, null);
            // searching in ZeroTree
            Assert.AreEqual(null, ZeroTree.FinMinMax(Node, true));

            // searching from Root (MAX)
            Assert.AreEqual(150, Tree.FinMinMax(Tree.FindNodeByKey(50).Node, true).NodeKey);
            // searching from Root (MIN)
            Assert.AreEqual(10, Tree.FinMinMax(Tree.FindNodeByKey(50).Node, false).NodeKey);

            // searching from sub-left (MAX)
            Assert.AreEqual(30, Tree.FinMinMax(Tree.FindNodeByKey(25).Node, true).NodeKey);
            Assert.AreEqual(10, Tree.FinMinMax(Tree.FindNodeByKey(10).Node, true).NodeKey);
            // searching from sub-left (MIN)
            Assert.AreEqual(10, Tree.FinMinMax(Tree.FindNodeByKey(25).Node, false).NodeKey);
            Assert.AreEqual(10, Tree.FinMinMax(Tree.FindNodeByKey(10).Node, false).NodeKey);

            // searching from sub-right (MAX)
            Assert.AreEqual(80, Tree.FinMinMax(Tree.FindNodeByKey(80).Node, true).NodeKey);
            Assert.AreEqual(79, Tree.FinMinMax(Tree.FindNodeByKey(79).Node, true).NodeKey);
            // searching from sub-right (MIN)
            Assert.AreEqual(75, Tree.FinMinMax(Tree.FindNodeByKey(80).Node, false).NodeKey);
            Assert.AreEqual(79, Tree.FinMinMax(Tree.FindNodeByKey(79).Node, false).NodeKey);

            // searching from missing node (MAX)
            Assert.AreEqual(null, Tree.FinMinMax(Node, true));
            // searching from missing node (MIN)
            Assert.AreEqual(null, Tree.FinMinMax(Node, false));
        }

        [TestMethod]
        public void DeleteNodeByKey()
        {
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(0, ZeroTree.Count());
            Assert.AreEqual(9, Tree.Count());
        } 

        [TestMethod]
        public void WideAllNodes()
        {
            BST<int> BSTTree = new BST<int>(null);
            Assert.AreEqual(0, BSTTree.Count());

            BSTTree.AddKeyValue(50, 50);
            BSTTree.AddKeyValue(25, 25);
            BSTTree.AddKeyValue(10, 10);
            BSTTree.AddKeyValue(-50, -50);
            BSTTree.AddKeyValue(30, 30);
            BSTTree.AddKeyValue(35, 35);
            BSTTree.AddKeyValue(100, 100);
            BSTTree.AddKeyValue(80, 80);
            BSTTree.AddKeyValue(75, 75);
            BSTTree.AddKeyValue(79, 79);
            BSTTree.AddKeyValue(150, 150);
            BSTTree.AddKeyValue(160, 160);

            Assert.AreEqual(12, BSTTree.Count());

            /*                [50]
             *        (25)               (100)
             *     (10)  (30)        (80)     (150)
             *   (-50)     (35)  (75)            (160)
             *                      (79)
             */

            List<BSTNode<int>> WideNodes = BSTTree.WideAllNodes();
            string wideResult = "";
            for (int i = 0; i < WideNodes.Count; i++)
            {
                wideResult = wideResult + WideNodes[i].NodeKey.ToString()+" ";
            }

            Assert.AreEqual("50 25 100 10 30 80 150 -50 35 75 160 79 ", wideResult);
        }

        [TestMethod]
        public void DeepAllNodes()
        {
            BST<int> BSTTree = new BST<int>(null);
            Assert.AreEqual(0, BSTTree.Count());

            BSTTree.AddKeyValue(50, 50);
            BSTTree.AddKeyValue(25, 25);
            BSTTree.AddKeyValue(10, 10);
            BSTTree.AddKeyValue(-50, -50);
            BSTTree.AddKeyValue(30, 30);
            BSTTree.AddKeyValue(35, 35);
            BSTTree.AddKeyValue(100, 100);
            BSTTree.AddKeyValue(80, 80);
            BSTTree.AddKeyValue(75, 75);
            BSTTree.AddKeyValue(79, 79);
            BSTTree.AddKeyValue(150, 150);
            BSTTree.AddKeyValue(160, 160);

            Assert.AreEqual(12, BSTTree.Count());

            /*                [50]
             *        (25)               (100)
             *     (10)  (30)        (80)     (150)
             *   (-50)     (35)  (75)            (160)
             *                      (79)
             */

            // in-order (0)
            List < BSTNode<int>> DeepNodes0 = BSTTree.DeepAllNodes(0);
            string order0 = "";
            for (int i = 0; i < DeepNodes0.Count; i++)
            {
                order0 = order0 + DeepNodes0[i].NodeKey.ToString() + " ";
            }

            Assert.AreEqual("-50 10 25 30 35 50 75 79 80 100 150 160 ", order0);

            // post-order (1)
            List<BSTNode<int>> DeepNodes1 = BSTTree.DeepAllNodes(1);
            string order1 = "";
            for (int i = 0; i < DeepNodes1.Count; i++)
            {
                order1 = order1 + DeepNodes1[i].NodeKey.ToString() + " ";
            }

            Assert.AreEqual("-50 10 35 30 25 79 75 80 160 150 100 50 ", order1);

            // pre-order (2)
            List<BSTNode<int>> DeepNodes2 = BSTTree.DeepAllNodes(2);
            string order2 = "";
            for (int i = 0; i < DeepNodes2.Count; i++)
            {
                order2 = order2 + DeepNodes2[i].NodeKey.ToString() + " ";
            }

            Assert.AreEqual("50 25 10 -50 30 35 100 80 75 79 150 160 ", order2);
        }
    }
}