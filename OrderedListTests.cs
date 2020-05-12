using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    [TestClass]
    public class OrderedListTests
    {
        OrderedList<int> testListAsc;
        OrderedList<int> testListDesc;
        OrderedList<string> strList;

        [TestInitialize]
        public void TestInitialize()
        {
            testListAsc = new OrderedList<int>(true);
            testListDesc = new OrderedList<int>(false);

            strList = new OrderedList<string>(true);

            Assert.AreEqual(0, testListAsc.Count());
            Assert.AreEqual(0, testListDesc.Count());
            Assert.AreEqual(0, strList.Count());
        }

        [TestMethod]
        public void CompareV1andV2()
        {
            Assert.AreEqual(1, testListAsc.Compare(15, 12));
            Assert.AreEqual(0, testListAsc.Compare(15, 15));
            Assert.AreEqual(-1, testListAsc.Compare(15, 27));

            Assert.AreEqual(1, strList.Compare("ds ","  abc "));
            Assert.AreEqual(0, strList.Compare("abcd   ", "    abcd "));
            Assert.AreEqual(-1, strList.Compare("qwert", " qwerty"));
        }

        [TestMethod]
        public void AddItemByValue()
        {
            testListAsc.Add(12);
            Assert.AreEqual(1, testListAsc.Count());
            testListAsc.Add(2);
            Assert.AreEqual(2, testListAsc.Count());
            testListAsc.Add(0);
            Assert.AreEqual(3, testListAsc.Count());
            testListAsc.Add(-6);
            Assert.AreEqual(4, testListAsc.Count());
            testListAsc.Add(50);
            Assert.AreEqual(5, testListAsc.Count());
            testListAsc.Add(-64);
            Assert.AreEqual(6, testListAsc.Count());
            testListAsc.Add(-2);
            Assert.AreEqual(7, testListAsc.Count());
            testListAsc.Add(0);
            Assert.AreEqual(8, testListAsc.Count());
            testListAsc.Add(500);
            Assert.AreEqual(9, testListAsc.Count());
            testListAsc.Add(500);
            Assert.AreEqual(10, testListAsc.Count());
            testListAsc.Add(51);
            Assert.AreEqual(11, testListAsc.Count());
            testListAsc.Add(-2);
            Assert.AreEqual(12, testListAsc.Count());
            testListAsc.Add(5000);
            Assert.AreEqual(13, testListAsc.Count());
            testListAsc.Add(5000);
            Assert.AreEqual(14, testListAsc.Count());
            testListAsc.Add(-6422);
            Assert.AreEqual(15, testListAsc.Count());

            testListDesc.Add(0);
            Assert.AreEqual(1, testListDesc.Count());
            testListDesc.Add(12);
            Assert.AreEqual(2, testListDesc.Count());
            testListDesc.Add(55);
            Assert.AreEqual(3, testListDesc.Count());
            testListDesc.Add(-2113);
            Assert.AreEqual(4, testListDesc.Count());
            testListDesc.Add(30);
            Assert.AreEqual(5, testListDesc.Count());
            testListDesc.Add(0);
            Assert.AreEqual(6, testListDesc.Count());
            testListDesc.Add(-1050);
            Assert.AreEqual(7, testListDesc.Count());
            testListDesc.Add(50);
            Assert.AreEqual(8, testListDesc.Count());
            testListDesc.Add(50);
            Assert.AreEqual(9, testListDesc.Count());
            testListDesc.Add(50);
            Assert.AreEqual(10, testListDesc.Count());
            testListDesc.Add(100);
            Assert.AreEqual(11, testListDesc.Count());
            testListDesc.Add(230);
            Assert.AreEqual(12, testListDesc.Count());
            testListDesc.Add(41);
            Assert.AreEqual(13, testListDesc.Count());
            testListDesc.Add(-1234);
            Assert.AreEqual(14, testListDesc.Count());
            testListDesc.Add(1200);
            Assert.AreEqual(15, testListDesc.Count());

        }

        [TestMethod]
        public void FindItemByValue()
        {
            testListAsc.Add(12);
            testListAsc.Add(2);
            testListAsc.Add(0);
            testListAsc.Add(-6);
            testListAsc.Add(50);
            testListAsc.Add(-64);
            testListAsc.Add(-2);
            testListAsc.Add(0);
            testListAsc.Add(500);
            testListAsc.Add(500);
            testListAsc.Add(51);
            testListAsc.Add(-2);
            testListAsc.Add(5000);
            testListAsc.Add(5000);
            testListAsc.Add(-6422);

            testListDesc.Add(0);
            testListDesc.Add(12);
            testListDesc.Add(55);
            testListDesc.Add(-2113);
            testListDesc.Add(30);
            testListDesc.Add(0);
            testListDesc.Add(-1050);
            testListDesc.Add(50);
            testListDesc.Add(50);
            testListDesc.Add(50);
            testListDesc.Add(100);
            testListDesc.Add(230);
            testListDesc.Add(41);
            testListDesc.Add(-1234);
            testListDesc.Add(1200);

            Assert.AreEqual(5000, testListAsc.Find(5000).value);
            Assert.AreEqual(null, testListAsc.Find(13));

            Assert.AreEqual(1200, testListDesc.Find(1200).value);
            Assert.AreEqual(null, testListDesc.Find(13));
        }

        [TestMethod]
        public void DeleteItemByValue()
        {
            testListAsc.Add(12); 
            testListAsc.Add(2); 
            testListAsc.Add(0); 
            testListAsc.Add(-6); 
            testListAsc.Add(50); 
            testListAsc.Add(-64);
            testListAsc.Add(-2); 
            testListAsc.Add(0); 
            testListAsc.Add(500);
            testListAsc.Add(500); 
            testListAsc.Add(51); 
            testListAsc.Add(-2); 
            testListAsc.Add(5000);
            testListAsc.Add(5000);
            testListAsc.Add(-6422);

            testListDesc.Add(0);
            testListDesc.Add(12);
            testListDesc.Add(55);
            testListDesc.Add(-2113);
            testListDesc.Add(30);
            testListDesc.Add(0);
            testListDesc.Add(-1050);
            testListDesc.Add(50);
            testListDesc.Add(50);
            testListDesc.Add(50);
            testListDesc.Add(100);
            testListDesc.Add(230);
            testListDesc.Add(41);
            testListDesc.Add(-1234);
            testListDesc.Add(1200);

            Assert.AreEqual(15, testListAsc.Count());
            Assert.AreEqual(15, testListDesc.Count());

            testListAsc.Delete(13);
            testListDesc.Delete(13);

            Assert.AreEqual(15, testListAsc.Count());
            Assert.AreEqual(15, testListDesc.Count());

            testListAsc.Delete(5000);
            testListDesc.Delete(50);

            Assert.AreEqual(14, testListAsc.Count());
            Assert.AreEqual(14, testListDesc.Count());

            testListAsc.Delete(12);
            testListAsc.Delete(0);
            testListAsc.Delete(50);
            testListAsc.Delete(-2);
            testListAsc.Delete(500);
            testListAsc.Delete(51);
            testListAsc.Delete(5000);
            testListAsc.Delete(-6422);
            testListAsc.Delete(2);
            testListAsc.Delete(-6);
            testListAsc.Delete(-64);

            testListDesc.Delete(0);
            testListDesc.Delete(55);
            testListDesc.Delete(30);
            testListDesc.Delete(-1050);
            testListDesc.Delete(50);
            testListDesc.Delete(100);
            testListDesc.Delete(41);
            testListDesc.Delete(1200);
            testListDesc.Delete(12);
            testListDesc.Delete(-2113);
            testListDesc.Delete(0);

            Assert.AreEqual(3, testListAsc.Count());
            Assert.AreEqual(3, testListDesc.Count());

            testListAsc.Delete(-2);
            testListAsc.Delete(500);
            testListAsc.Delete(0);

            testListDesc.Delete(230);
            testListDesc.Delete(-1234);
            testListDesc.Delete(50);

            Assert.AreEqual(0, testListAsc.Count());
            Assert.AreEqual(0, testListDesc.Count());

            testListAsc.Delete(0);
            testListDesc.Delete(230);

            Assert.AreEqual(0, testListAsc.Count());
            Assert.AreEqual(0, testListDesc.Count());
        }

        [TestMethod]
        public void Clear()
        {
            testListAsc.Add(12);
            testListAsc.Add(2);
            testListAsc.Add(0);
            testListAsc.Add(-6);
            testListAsc.Add(50);
            testListAsc.Add(-64);
            testListAsc.Add(-2);
            testListAsc.Add(0);
            testListAsc.Add(500);
            testListAsc.Add(500);
            testListAsc.Add(51);
            testListAsc.Add(-2);
            testListAsc.Add(5000);
            testListAsc.Add(5000);
            testListAsc.Add(-6422);

            testListDesc.Add(0);
            testListDesc.Add(12);
            testListDesc.Add(55);
            testListDesc.Add(-2113);
            testListDesc.Add(30);
            testListDesc.Add(0);
            testListDesc.Add(-1050);
            testListDesc.Add(50);
            testListDesc.Add(50);
            testListDesc.Add(50);
            testListDesc.Add(100);
            testListDesc.Add(230);
            testListDesc.Add(41);
            testListDesc.Add(-1234);
            testListDesc.Add(1200);

            Assert.AreEqual(15, testListAsc.Count());
            Assert.AreEqual(15, testListDesc.Count());

            testListAsc.Clear(true);
            testListDesc.Clear(false);

            Assert.AreEqual(0, testListAsc.Count());
            Assert.AreEqual(0, testListDesc.Count());
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(0, testListAsc.Count());

            testListAsc.Add(12);
            testListAsc.Add(2);
            testListAsc.Add(0);
            testListAsc.Add(-6);
            testListAsc.Add(50);
            Assert.AreEqual(5, testListAsc.Count());

            testListAsc.Add(-64);
            testListAsc.Add(-2);
            testListAsc.Add(0);
            testListAsc.Add(500);
            testListAsc.Add(500);
            Assert.AreEqual(10, testListAsc.Count());

            testListAsc.Add(51);
            testListAsc.Add(-2);
            testListAsc.Add(5000);
            testListAsc.Add(5000);
            testListAsc.Add(-6422);
            Assert.AreEqual(15, testListAsc.Count());

            Assert.AreEqual(0, testListDesc.Count());

            testListDesc.Add(0);
            testListDesc.Add(12);
            testListDesc.Add(55);
            testListDesc.Add(-2113);
            testListDesc.Add(30);
            Assert.AreEqual(5, testListDesc.Count());

            testListDesc.Add(0);
            testListDesc.Add(-1050);
            testListDesc.Add(50);
            testListDesc.Add(50);
            testListDesc.Add(50);
            Assert.AreEqual(10, testListDesc.Count());

            testListDesc.Add(100);
            testListDesc.Add(230);
            testListDesc.Add(41);
            testListDesc.Add(-1234);
            testListDesc.Add(1200);
            Assert.AreEqual(15, testListDesc.Count());

        }

    }
}
