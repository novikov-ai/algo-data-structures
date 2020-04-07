using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    [TestClass]
    public class LinkedListTests
    {
        Node userNode0, userNode1, userNode2, userNode3, userNode4, userNode5, userNode6, userNode7, userNode8, userNode9, userNode10, userNode11, userNode12, userNode13, userNode14, userNode15;

        LinkedList userList;
        LinkedList userListOne;
        LinkedList userListEmpty;

        Node userListHeadBefore, userListTailBefore;
        Node userListOneHeadBefore, userListOneTailBefore;
        Node userListEmptyHeadBefore, userListEmptyTailBefore;

        [TestInitialize]
        public void TestInitialize()
        {
            // nodes initializing
            userNode0 = new Node(42);

            userNode1 = new Node(13);
            userNode2 = new Node(7);
            userNode3 = new Node(24);
            userNode4 = new Node(0);
            userNode5 = new Node(0);
            userNode6 = new Node(12);
            userNode7 = new Node(2);
            userNode8 = new Node(7);
            userNode9 = new Node(7);
            userNode10 = new Node(7);

            userNode11 = new Node(12);
            userNode12 = new Node(21);
            userNode13 = new Node(37);
            userNode14 = new Node(84);
            userNode15 = new Node(11);

            // userList with 10 nodes creating
            userList = new LinkedList();
            userList.AddInTail(userNode1);
            userList.AddInTail(userNode2);
            userList.AddInTail(userNode3);
            userList.AddInTail(userNode4);
            userList.AddInTail(userNode5);
            userList.AddInTail(userNode6);
            userList.AddInTail(userNode7);
            userList.AddInTail(userNode8);
            userList.AddInTail(userNode9);
            userList.AddInTail(userNode10);

            // userListOne with 1 node creating
            userListOne = new LinkedList();
            userListOne.AddInTail(userNode0);

            // userListEmpty with no nodes creating
            userListEmpty = new LinkedList();

            // finding the heads and tails of created LinkedLists
            userListHeadBefore = userList.head;
            userListTailBefore = userList.tail;

            userListOneHeadBefore = userListOne.head;
            userListOneTailBefore = userListOne.tail;

            userListEmptyHeadBefore = userListEmpty.head;
            userListEmptyTailBefore = userListEmpty.tail;

            // checking the heads and tails of created LinkedLists
            Assert.AreEqual(userNode1, userListHeadBefore);
            Assert.AreEqual(userNode10, userListTailBefore);

            Assert.AreEqual(userNode0, userListOneHeadBefore);
            Assert.AreEqual(userNode0, userListOneTailBefore);

            Assert.AreEqual(null, userListEmptyHeadBefore);
            Assert.AreEqual(null, userListEmptyTailBefore);
        }

        [TestMethod]
        public void CountElementsInList()
        {
            // assert
            Assert.AreEqual(10, userList.Count());
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(0, userListEmpty.Count());
        }

        [TestMethod]
        public void ClearElementsInList()
        {
            // act
            userList.Clear();
            userListOne.Clear();
            userListEmpty.Clear();

            // assert after
            Assert.AreEqual(null, userList.head);
            Assert.AreEqual(null, userList.tail);

            Assert.AreEqual(null, userListOne.head);
            Assert.AreEqual(null, userListOne.tail);

            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);

        }

        [TestMethod]
        public void RemoveElementInListByValue()
        {
            // 10 nodes
            userList.Remove(30);
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(10, userList.Count());
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            userList.Remove(7);
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(9, userList.Count());
            Assert.AreEqual(userNode3, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            // 1 node
            userListOne.Remove(2);
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(userNode0, userListOne.tail);
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(null, userListOne.head.next);
            Assert.AreEqual(null, userListOne.tail.next);

            userListOne.Remove(42);
            Assert.AreEqual(null, userListOne.head);
            Assert.AreEqual(null, userListOne.tail);
            Assert.AreEqual(0, userListOne.Count());
            
            // no nodes
            userListEmpty.Remove(1);
            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);
            Assert.AreEqual(0, userListEmpty.Count());
        }

        [TestMethod]
        public void RemoveAllElementsInListByValue()
        {
            // 10 nodes
            userList.RemoveAll(30);
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(10, userList.Count());
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            userList.RemoveAll(7);
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode7, userList.tail);
            Assert.AreEqual(6, userList.Count());
            Assert.AreEqual(userNode3, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            // 1 node
            userListOne.RemoveAll(2);
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(userNode0, userListOne.tail);
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(null, userListOne.head.next);
            Assert.AreEqual(null, userListOne.tail.next);

            userListOne.RemoveAll(42);
            Assert.AreEqual(null, userListOne.head);
            Assert.AreEqual(null, userListOne.tail);
            Assert.AreEqual(0, userListOne.Count());

            // no nodes
            userListEmpty.RemoveAll(1);
            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);
            Assert.AreEqual(0, userListEmpty.Count());
        }

        [TestMethod]
        public void FindAllElementsInListByValue()
        {
            // 10 nodes
            Assert.AreEqual(0, userList.FindAll(30).Count);

            Assert.AreEqual(4, userList.FindAll(7).Count);

            // 1 node
            Assert.AreEqual(0, userListOne.FindAll(2).Count);

            Assert.AreEqual(1, userListOne.FindAll(42).Count);

            // no nodes
            Assert.AreEqual(0, userListEmpty.FindAll(1).Count);
        }

        [TestMethod]
        public void InsertAfterNodeByValue()
        {
            // 10 nodes
            userList.InsertAfter(userNode0, userNode11); 
            Assert.AreEqual(10, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            userList.InsertAfter(userNode6, userNode11); 
            Assert.AreEqual(11, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            userList.InsertAfter(userNode1, userNode12); 
            Assert.AreEqual(12, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(userNode12, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            userList.InsertAfter(userNode10, userNode13); 
            Assert.AreEqual(13, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode13, userList.tail);
            Assert.AreEqual(userNode12, userList.head.next);
            Assert.AreEqual(null, userList.tail.next);

            // 1 node
            userListOne.InsertAfter(userNode3, userNode14); 
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(userNode0, userListOne.tail);
            Assert.AreEqual(null, userListOne.head.next);
            Assert.AreEqual(null, userListOne.tail.next);

            userListOne.InsertAfter(userNode0, userNode14); 
            Assert.AreEqual(2, userListOne.Count());
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(userNode14, userListOne.tail);
            Assert.AreEqual(userNode14, userListOne.head.next);
            Assert.AreEqual(null, userListOne.tail.next);

            // no nodes
            userListEmpty.InsertAfter(userNode10, userNode15);
            Assert.AreEqual(0, userListEmpty.Count());
            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);

            userListEmpty.InsertAfter(null, userNode15); 
            Assert.AreEqual(1, userListEmpty.Count());
            Assert.AreEqual(userNode15, userListEmpty.head);
            Assert.AreEqual(userNode15, userListEmpty.tail);
            Assert.AreEqual(null, userListEmpty.head.next);
            Assert.AreEqual(null, userListEmpty.tail.next);
        }
    }
}