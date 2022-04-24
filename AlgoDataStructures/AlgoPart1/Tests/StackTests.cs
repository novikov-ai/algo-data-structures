using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoDataStructures
{
    [TestClass]
    public class StackTests
    {
        Stack<int> myStack0, myStack1, myStack3, myStack5;

        [TestInitialize]
        public void TestInitialize()
        {
            myStack0 = new Stack<int>();

            myStack1 = new Stack<int>();
            myStack1.Push(30);

            myStack3 = new Stack<int>();
            myStack3.Push(400);
            myStack3.Push(500);
            myStack3.Push(600);

            myStack5 = new Stack<int>();
            myStack5.Push(7000);
            myStack5.Push(8000);
            myStack5.Push(9000);
            myStack5.Push(10000);
            myStack5.Push(11000);
        }

        [TestMethod]
        public void Size()
        {
            Assert.AreEqual(0, myStack0.Size());
            Assert.AreEqual(1, myStack1.Size());
            Assert.AreEqual(3, myStack3.Size());
            Assert.AreEqual(5, myStack5.Size());
        }

        [TestMethod]
        public void Pop()
        {
            Assert.AreEqual(0, myStack0.Pop());
            Assert.AreEqual(0, myStack0.Size());

            Assert.AreEqual(30, myStack1.Pop());
            Assert.AreEqual(0, myStack1.Size());

            Assert.AreEqual(600, myStack3.Pop());
            Assert.AreEqual(2, myStack3.Size());

            Assert.AreEqual(11000, myStack5.Pop());
            Assert.AreEqual(4, myStack5.Size());
        }

        [TestMethod]
        public void PushValue()
        {
            myStack0.Push(10);
            Assert.AreEqual(1, myStack0.Size());

            myStack1.Push(20);
            myStack1.Push(30);
            Assert.AreEqual(3, myStack1.Size());

            myStack3.Push(400);
            myStack3.Push(500);
            myStack3.Push(600);
            Assert.AreEqual(6, myStack3.Size());

            myStack5.Push(7000);
            myStack5.Push(8000);
            myStack5.Push(9000);
            myStack5.Push(10000);
            myStack5.Push(11000);
            Assert.AreEqual(10, myStack5.Size());
        }

        [TestMethod]
        public void Peek()
        {
            Assert.AreEqual(0, myStack0.Peek());
            Assert.AreEqual(30, myStack1.Peek());
            Assert.AreEqual(600, myStack3.Peek());
            Assert.AreEqual(11000, myStack5.Peek());
        }
    }
}
