using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoDataStructures
{
    [TestClass]
    public class LinkedList2Tests
    {
        Node userNode0, userNode1, userNode2, userNode3, userNode4, userNode5, userNode6, userNode7, userNode8, userNode9, userNode10, userNode11, userNode12, userNode13, userNode14, userNode15, userNode16, userNode17;
        LinkedList2 userList, userListOne, userListEmpty;

        [TestInitialize]
        public void TestInitialize()
        {
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
            userNode16 = new Node(8);
            userNode17 = new Node(10);

            userList = new LinkedList2();
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
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode9, userList.tail.prev);

            userListOne = new LinkedList2();
            userListOne.AddInTail(userNode0);
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(null, userListOne.head.next);
            Assert.AreEqual(null, userListOne.head.prev);
            Assert.AreEqual(userNode0, userListOne.tail);
            Assert.AreEqual(null, userListOne.tail.next);
            Assert.AreEqual(null, userListOne.tail.prev);

            userListEmpty = new LinkedList2();
            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);
        }
        
        [TestMethod]
        public void FindNodeByValue()
        {
            Assert.AreEqual(userNode2, userList.Find(7));
            Assert.AreEqual(null, userList.Find(712));

            Assert.AreEqual(userNode0, userListOne.Find(42));
            Assert.AreEqual(null, userListOne.Find(421));

            Assert.AreEqual(null, userListEmpty.Find(12));
        }

        [TestMethod]
        public void FindAllNodesByValue()
        {
            Assert.AreEqual(4, userList.FindAll(7).Count);
            Assert.AreEqual(0, userList.FindAll(71).Count);

            Assert.AreEqual(1, userListOne.FindAll(42).Count);
            Assert.AreEqual(0, userListOne.FindAll(71).Count);

            Assert.AreEqual(0, userListEmpty.FindAll(71).Count);
        }

        [TestMethod]
        public void RemoveNodeByValue()
        {
            userList.Remove(71);
            Assert.AreEqual(10, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode9, userList.tail.prev);

            userList.Remove(7);
            Assert.AreEqual(9, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode3, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode9, userList.tail.prev);

            userListOne.Remove(1);
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(null, userListOne.head.next);
            Assert.AreEqual(null, userListOne.head.prev);
            Assert.AreEqual(userNode0, userListOne.tail);
            Assert.AreEqual(null, userListOne.tail.next);
            Assert.AreEqual(null, userListOne.tail.prev);

            userListOne.Remove(42);
            Assert.AreEqual(0, userListOne.Count());
            Assert.AreEqual(null, userListOne.head);
            Assert.AreEqual(null, userListOne.tail);

            userListEmpty.Remove(424);
            Assert.AreEqual(0, userListEmpty.Count());
            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);
        }

        [TestMethod]
        public void RemoveAllNodesByValue()
        {
            userList.RemoveAll(71);
            Assert.AreEqual(10, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode9, userList.tail.prev);

            userList.RemoveAll(7);
            Assert.AreEqual(6, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode3, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(userNode7, userList.tail);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode6, userList.tail.prev);

            userList.RemoveAll(13);
            userList.RemoveAll(0);
            Assert.AreEqual(3, userList.Count());
            Assert.AreEqual(userNode3, userList.head);
            Assert.AreEqual(userNode6, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(userNode7, userList.tail);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode6, userList.tail.prev);

            userListOne.RemoveAll(1);
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(null, userListOne.head.next);
            Assert.AreEqual(null, userListOne.head.prev);
            Assert.AreEqual(userNode0, userListOne.tail);
            Assert.AreEqual(null, userListOne.tail.next);
            Assert.AreEqual(null, userListOne.tail.prev);

            userListOne.RemoveAll(42);
            Assert.AreEqual(0, userListOne.Count());
            Assert.AreEqual(null, userListOne.head);
            Assert.AreEqual(null, userListOne.tail);

            userListEmpty.RemoveAll(42);
            Assert.AreEqual(0, userListEmpty.Count());
            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);
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
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode9, userList.tail.prev);

            userList.InsertAfter(userNode6, userNode11);
            Assert.AreEqual(11, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(userNode2, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode9, userList.tail.prev);

            userList.InsertAfter(userNode1, userNode12);
            Assert.AreEqual(12, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode10, userList.tail);
            Assert.AreEqual(userNode12, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode9, userList.tail.prev);

            userList.InsertAfter(userNode10, userNode13);
            Assert.AreEqual(13, userList.Count());
            Assert.AreEqual(userNode1, userList.head);
            Assert.AreEqual(userNode13, userList.tail);
            Assert.AreEqual(userNode12, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode10, userList.tail.prev);

            userList.InsertAfter(null, userNode16);
            Assert.AreEqual(14, userList.Count());
            Assert.AreEqual(userNode16, userList.head);
            Assert.AreEqual(userNode13, userList.tail);
            Assert.AreEqual(userNode1, userList.head.next);
            Assert.AreEqual(null, userList.head.prev);
            Assert.AreEqual(null, userList.tail.next);
            Assert.AreEqual(userNode10, userList.tail.prev);

            // 1 node
            userListOne.InsertAfter(userNode3, userNode14);
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(userNode0, userListOne.tail);
            Assert.AreEqual(null, userListOne.head.next);
            Assert.AreEqual(null, userListOne.head.prev);
            Assert.AreEqual(null, userListOne.tail.next);
            Assert.AreEqual(null, userListOne.tail.prev);

            userListOne.InsertAfter(userNode0, userNode14);
            Assert.AreEqual(2, userListOne.Count());
            Assert.AreEqual(userNode0, userListOne.head);
            Assert.AreEqual(userNode14, userListOne.tail);
            Assert.AreEqual(userNode14, userListOne.head.next);
            Assert.AreEqual(null, userListOne.head.prev);
            Assert.AreEqual(null, userListOne.tail.next);
            Assert.AreEqual(userNode0, userListOne.tail.prev);

            userListOne.InsertAfter(null, userNode17);
            Assert.AreEqual(3, userListOne.Count());
            Assert.AreEqual(userNode17, userListOne.head);
            Assert.AreEqual(userNode14, userListOne.tail);
            Assert.AreEqual(userNode0, userListOne.head.next);
            Assert.AreEqual(null, userListOne.head.prev);
            Assert.AreEqual(null, userListOne.tail.next);
            Assert.AreEqual(userNode0, userListOne.tail.prev);

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
            Assert.AreEqual(null, userListEmpty.head.prev);
            Assert.AreEqual(null, userListEmpty.tail.next);
            Assert.AreEqual(null, userListEmpty.tail.prev);
        }

        [TestMethod]
        public void CountNodes()
        {
            Assert.AreEqual(10, userList.Count());
            Assert.AreEqual(1, userListOne.Count());
            Assert.AreEqual(0, userListEmpty.Count());
        }

        [TestMethod]
        public void ClearList()
        {
            Assert.AreEqual(10, userList.Count());
            userList.Clear();
            Assert.AreEqual(0, userList.Count());
            Assert.AreEqual(null, userList.head);
            Assert.AreEqual(null, userList.tail);

            Assert.AreEqual(1, userListOne.Count());
            userListOne.Clear();
            Assert.AreEqual(0, userListOne.Count());
            Assert.AreEqual(null, userListOne.head);
            Assert.AreEqual(null, userListOne.tail);

            Assert.AreEqual(0, userListEmpty.Count());
            userListEmpty.Clear();
            Assert.AreEqual(0, userListEmpty.Count());
            Assert.AreEqual(null, userListEmpty.head);
            Assert.AreEqual(null, userListEmpty.tail);
        }
    }
}
