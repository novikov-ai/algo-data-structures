using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    [TestClass]
    public class LinkedListTests
    {
        // создание узлов
        Node userNode0, userNode1, userNode2, userNode3, userNode4, userNode5, userNode6, userNode7, userNode8, userNode9, userNode10, userNode11, userNode12, userNode13, userNode14, userNode15;

        // создание связанного списка с 10 элементами
        LinkedList userList;

        // создание связанного списка с 1 элементом
        LinkedList userListOne;

        // создание пустого связанного списка
        LinkedList userListEmpty;

        [TestInitialize]
        public void TestInitialize()
        {
            // инициализация узлов значениями
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

            // добавление узлов в список с 10 элементами
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

            // добавление узла в список из 1 элемента
            userListOne = new LinkedList();
            userListOne.AddInTail(userNode0);

            // создание пустого списка
            userListEmpty = new LinkedList();
        }
        [TestMethod]
        public void CountElementsInList()
        {
            // arrange
            int userListExpected = 10;
            int userListExpectedOne = 1;
            int userListExpectedEmpty = 0;

            // act
            int actual = userList.Count();
            int actualOne = userListOne.Count();
            int actualEmpty = userListEmpty.Count();

            // assert
            Assert.AreEqual(userListExpected, actual);
            Assert.AreEqual(userListExpectedOne, actualOne);
            Assert.AreEqual(userListExpectedEmpty, actualEmpty);
        }

        [TestMethod]
        public void ClearElementsInList()
        {
            // arrange
            int userListExpected = 0;
            int userListExpectedOne = 0;
            int userListExpectedEmpty = 0;

            // act
            userList.Clear();
            userListOne.Clear();
            userListEmpty.Clear();

            int actual = userList.Count();
            int actualOne = userListOne.Count();
            int actualEmpty = userListEmpty.Count();

            // assert
            Assert.AreEqual(userListExpected, actual);
            Assert.AreEqual(userListExpectedOne, actualOne);
            Assert.AreEqual(userListExpectedEmpty, actualEmpty);
        }

        [TestMethod]
        public void RemoveElementInListByValue()
        {
            // arrange

            // список с 10 элементами
            int userListExpected = 10;
            int userListExpectedV = 9;

            // список с 1 элементом
            int userListExpectedOne = 1;
            int userListExpectedOneV = 0;

            // пустой список
            int userListExpectedEmpty = 0;

            // act + assert

            // список с 10 элементами
            userList.Remove(30); //значения нет в списке
            int actual = userList.Count();
            Assert.AreEqual(userListExpected, actual);

            userList.Remove(7); //значение есть в списке
            actual = userList.Count();
            Assert.AreEqual(userListExpectedV, actual);

            // список с 1 элементом
            userListOne.Remove(2); //значения нет в списке
            int actualOne = userListOne.Count();
            Assert.AreEqual(userListExpectedOne, actualOne);

            userListOne.Remove(42); //значение есть в списке
            actualOne = userListOne.Count();
            Assert.AreEqual(userListExpectedOneV, actualOne);

            // пустой список
            userListEmpty.Remove(1);
            int actualEmpty = userListEmpty.Count();
            Assert.AreEqual(userListExpectedEmpty, actualEmpty);
        }

        [TestMethod]
        public void RemoveAllElementsInListByValue()
        {
            // arrange

            // список с 10 элементами
            int userListExpected = 10;
            int userListExpectedV = 6;

            // список с 1 элементом
            int userListExpectedOne = 1;
            int userListExpectedOneV = 0;

            // пустой список
            int userListExpectedEmpty = 0;

            // act + assert

            // список с 10 элементами
            userList.RemoveAll(30); //значения нет в списке
            int actual = userList.Count();
            Assert.AreEqual(userListExpected, actual);

            userList.RemoveAll(7); //значение есть в списке
            actual = userList.Count();
            Assert.AreEqual(userListExpectedV, actual);

            // список с 1 элементом
            userListOne.RemoveAll(2); //значения нет в списке
            int actualOne = userListOne.Count();
            Assert.AreEqual(userListExpectedOne, actualOne);

            userListOne.RemoveAll(42); //значение есть в списке
            actualOne = userListOne.Count();
            Assert.AreEqual(userListExpectedOneV, actualOne);

            // пустой список
            userListEmpty.RemoveAll(1);
            int actualEmpty = userListEmpty.Count();
            Assert.AreEqual(userListExpectedEmpty, actualEmpty);
        }

        [TestMethod]
        public void FindAllElementsInListByValue()
        {
            // arrange

            // список с 10 элементами
            int userListExpected = 0;
            int userListExpectedV = 4;

            // список с 1 элементом
            int userListExpectedOne = 0;
            int userListExpectedOneV = 1;

            // пустой список
            int userListExpectedEmpty = 0;

            // act + assert

            // список с 10 элементами
            int actual = userList.FindAll(30).Count; //значения нет в списке
            Assert.AreEqual(userListExpected, actual);

            actual = userList.FindAll(7).Count; //значение есть в списке
            Assert.AreEqual(userListExpectedV, actual);

            // список с 1 элементом
            int actualOne = userListOne.FindAll(2).Count; //значения нет в списке
            Assert.AreEqual(userListExpectedOne, actualOne);

            actualOne = userListOne.FindAll(42).Count; //значение есть в списке
            Assert.AreEqual(userListExpectedOneV, actualOne);

            // пустой список
            int actualEmpty = userListEmpty.FindAll(1).Count;
            Assert.AreEqual(userListExpectedEmpty, actualEmpty);
        }

        [TestMethod]
        public void InsertAfterNodeByValue()
        {
            // arrange

            // список с 10 элементами
            int userListExpected = 10;
            int userListExpectedV = 11;
            int userListExpectedVH = 12;
            int userListExpectedVT = 13;

            // список с 1 элементом
            int userListExpectedOne = 1;
            int userListExpectedOneV = 2;

            // пустой список
            int userListExpectedEmpty = 0;
            int userListExpectedEmptyV = 1;

            // act + assert

            // список с 10 элементами
            userList.InsertAfter(userNode0, userNode11);  //значения нет в списке
            int actual = userList.Count();
            Assert.AreEqual(userListExpected, actual);

            userList.InsertAfter(userNode6, userNode11); //значение есть в списке (вставка в середину)
            actual = userList.Count();
            Assert.AreEqual(userListExpectedV, actual);

            userList.InsertAfter(userNode1, userNode12); //значение есть в списке (вставка в начало)
            actual = userList.Count();
            Assert.AreEqual(userListExpectedVH, actual);

            userList.InsertAfter(userNode10, userNode13); //значение есть в списке (вставка в конец)
            actual = userList.Count();
            Assert.AreEqual(userListExpectedVT, actual);

            // список с 1 элементом
            userListOne.InsertAfter(userNode3, userNode14); //значения нет в списке
            int actualOne = userListOne.Count();
            Assert.AreEqual(userListExpectedOne, actualOne);

            userListOne.InsertAfter(userNode0, userNode14); //значение есть в списке
            actualOne = userListOne.Count();
            Assert.AreEqual(userListExpectedOneV, actualOne);

            // пустой список
            userListEmpty.InsertAfter(userNode10, userNode15);
            int actualEmpty = userListEmpty.Count();
            Assert.AreEqual(userListExpectedEmpty, actualEmpty);

            userListEmpty.InsertAfter(null, userNode15); // при подаче null вставка в начало
            actualEmpty = userListEmpty.Count();
            Assert.AreEqual(userListExpectedEmptyV, actualEmpty);
        }
    }
}

