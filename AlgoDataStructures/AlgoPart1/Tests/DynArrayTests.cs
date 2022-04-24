using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlgoDataStructures
{
    [TestClass]
    public class DynArrayTests
    {
        DynArray<int> userArray = new DynArray<int>();

        [TestMethod]
        public void MakeArray()
        {
            userArray.MakeArray(-13); //capacity=16
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(0, userArray.count);

            userArray.MakeArray(0); //capacity=16
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(0, userArray.count);

            userArray.MakeArray(5); //capacity=16
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(0, userArray.count);

            userArray.MakeArray(16); //capacity=16
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(0, userArray.count);

            userArray.MakeArray(24); //capacity=24
            Assert.AreEqual(24, userArray.capacity);
            Assert.AreEqual(0, userArray.count);
        }

        [TestMethod]
        public void GetItemByIndex()
        {
            userArray.Append(10);
            userArray.Append(22);
            userArray.Append(33);
            userArray.Append(44);

            Assert.AreEqual(10, userArray.GetItem(0));
            Assert.AreEqual(22, userArray.GetItem(1));
            Assert.AreEqual(33, userArray.GetItem(2));
            Assert.AreEqual(44, userArray.GetItem(3));
        }

        [TestMethod]
        public void AppendItemIntValueToEnd()
        {
            userArray.Append(15);
            Assert.AreEqual(1,userArray.count);
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(15, userArray.GetItem(0));

            userArray.Append(-13);
            userArray.Append(0);
            userArray.Append(42);
            Assert.AreEqual(4, userArray.count);
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(42, userArray.GetItem(3));
            Assert.AreEqual(-13, userArray.GetItem(1));

            userArray.Append(23);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(23);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(10);
            Assert.AreEqual(16, userArray.count);
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(10, userArray.GetItem(15));
            
            userArray.Append(101);
            Assert.AreEqual(17, userArray.count);
            Assert.AreEqual(32, userArray.capacity);
            Assert.AreEqual(101, userArray.GetItem(16));
        }

        [TestMethod]
        public void InsertItemAtIndex()
        {
            userArray.Insert(15, 0);
            Assert.AreEqual(1, userArray.count);
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(15, userArray.GetItem(0));

            userArray.Insert(13, 1);
            Assert.AreEqual(2, userArray.count);
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(13, userArray.GetItem(1));

            userArray.Append(23);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(23);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(10);

            userArray.Insert(335, 10);
            userArray.Insert(335, 10);
            userArray.Insert(66, 1);
            Assert.AreEqual(17, userArray.count);
            Assert.AreEqual(32, userArray.capacity);
            Assert.AreEqual(10, userArray.GetItem(16));
        }

        [TestMethod]
        public void RemoveItemByIndex()
        {
            userArray.Append(23);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(23);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(10);
            userArray.Append(23);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(11);
            userArray.Append(77);
            userArray.Append(10);
            Assert.AreEqual(32, userArray.capacity);
            Assert.AreEqual(19, userArray.count);

            userArray.Remove(0);
            Assert.AreEqual(32, userArray.capacity);
            Assert.AreEqual(18, userArray.count);

            userArray.Remove(17);
            Assert.AreEqual(32, userArray.capacity);
            Assert.AreEqual(17, userArray.count);

            userArray.Remove(13);
            Assert.AreEqual(32, userArray.capacity);
            Assert.AreEqual(16, userArray.count);

            userArray.Remove(12);
            Assert.AreEqual(21, userArray.capacity);
            Assert.AreEqual(15, userArray.count);

            userArray.Remove(12);
            userArray.Remove(12);
            userArray.Remove(12);
            userArray.Remove(12);
            Assert.AreEqual(21, userArray.capacity);
            Assert.AreEqual(11, userArray.count);

            userArray.Remove(0);
            Assert.AreEqual(16, userArray.capacity);
            Assert.AreEqual(10, userArray.count);
        }
    }
}
