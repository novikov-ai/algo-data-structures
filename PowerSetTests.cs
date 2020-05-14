using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    [TestClass]
    public class PowerSetTests
    {
        PowerSet<int> testPowerSet;

        PowerSet<int> testPowerSet0;
        PowerSet<int> testPowerSet1;
        PowerSet<int> testPowerSet2;

        [TestInitialize]
        public void TestInitialize()
        {
            // dynamic PowerSet
            testPowerSet = new PowerSet<int>();

            // zero PowerSet
            testPowerSet0 = new PowerSet<int>();

            // 5 items PowerSet {8 10 12 14 16}
            testPowerSet1 = new PowerSet<int>();
            testPowerSet1.Put(8);
            testPowerSet1.Put(10);
            testPowerSet1.Put(12);
            testPowerSet1.Put(14);
            testPowerSet1.Put(16);
            Assert.AreEqual(5, testPowerSet1.capacity);

            // 5 items PowerSet {14 16 162 0 5}
            testPowerSet2 = new PowerSet<int>();
            testPowerSet2.Put(14);
            testPowerSet2.Put(16);
            testPowerSet2.Put(162);
            testPowerSet2.Put(0);
            testPowerSet2.Put(5);
            Assert.AreEqual(5, testPowerSet2.capacity);
        }

        [TestMethod]
        public void PutItem()
        {
            // add new item
            testPowerSet.Put(15);
            Assert.AreEqual(1, testPowerSet.capacity);

            testPowerSet.Put(2);
            Assert.AreEqual(2, testPowerSet.capacity);

            testPowerSet.Put(52);
            Assert.AreEqual(3, testPowerSet.capacity);

            // add existing item (zero effect)
            testPowerSet.Put(52);
            Assert.AreEqual(3, testPowerSet.capacity);

            testPowerSet.Put(500);
            Assert.AreEqual(4, testPowerSet.capacity);

            // add existing item (zero effect)
            testPowerSet.Put(15);
            Assert.AreEqual(4, testPowerSet.capacity);

            testPowerSet.Put(0);
            Assert.AreEqual(5, testPowerSet.capacity);

        }

        [TestMethod]
        public void RemoveItem()
        {
            // PowerSet {21 5 0 53 102}
            testPowerSet.Put(21);
            testPowerSet.Put(5);
            testPowerSet.Put(0);
            testPowerSet.Put(53);
            testPowerSet.Put(102);
            Assert.AreEqual(5, testPowerSet.capacity);

            // Remove wrong value (zero effect)
            Assert.AreEqual(false, testPowerSet.Remove(13));
            Assert.AreEqual(5, testPowerSet.capacity);

            // Remove existing value
            Assert.AreEqual(true, testPowerSet.Remove(21));
            Assert.AreEqual(4, testPowerSet.capacity);

            Assert.AreEqual(true, testPowerSet.Remove(5));
            Assert.AreEqual(3, testPowerSet.capacity);

            Assert.AreEqual(true, testPowerSet.Remove(0));
            Assert.AreEqual(2, testPowerSet.capacity);

            Assert.AreEqual(true, testPowerSet.Remove(53));
            Assert.AreEqual(1, testPowerSet.capacity);

            Assert.AreEqual(true, testPowerSet.Remove(102));
            Assert.AreEqual(0, testPowerSet.capacity);

            // Remove value from empty list (zero effect)
            Assert.AreEqual(false, testPowerSet.Remove(0));
            Assert.AreEqual(0, testPowerSet.capacity);
        }

        [TestMethod]
        public void Intersection()
        {
            // Intersection with empty set
            Assert.AreEqual(0, testPowerSet1.Intersection(testPowerSet0).capacity);

            // Intersection with PowerSet2 contains 5 items (expected 2 items)
            testPowerSet = testPowerSet1.Intersection(testPowerSet2);
            Assert.AreEqual(2, testPowerSet.capacity);
            Assert.AreEqual(true, testPowerSet.Get(14));
            Assert.AreEqual(true, testPowerSet.Get(16));
            Assert.AreEqual(false, testPowerSet.Get(100));

            // Putting 5 items to empty set
            testPowerSet0.Put(101);
            testPowerSet0.Put(102);
            testPowerSet0.Put(103);
            testPowerSet0.Put(104);
            testPowerSet0.Put(105);
            Assert.AreEqual(5, testPowerSet0.capacity);

            // Intersection with PowerSet0 contains 5 different items (expected empty set)
            testPowerSet = testPowerSet1.Intersection(testPowerSet0);
            Assert.AreEqual(0, testPowerSet.capacity);
            Assert.AreEqual(false, testPowerSet.Get(101));
        }

        [TestMethod]
        public void Union()
        {
            // Union with PowerSet2 contains 5 items (expected 8 unique items)
            testPowerSet = testPowerSet1.Union(testPowerSet2);
            Assert.AreEqual(8, testPowerSet.capacity);
            Assert.AreEqual(true, testPowerSet.Get(8));
            Assert.AreEqual(true, testPowerSet.Get(10));
            Assert.AreEqual(true, testPowerSet.Get(12));
            Assert.AreEqual(true, testPowerSet.Get(14));
            Assert.AreEqual(true, testPowerSet.Get(16));
            Assert.AreEqual(true, testPowerSet.Get(162));
            Assert.AreEqual(true, testPowerSet.Get(0));
            Assert.AreEqual(true, testPowerSet.Get(5));
            Assert.AreEqual(false, testPowerSet.Get(13));

            // Union with empty set
            Assert.AreEqual(5, testPowerSet1.Union(testPowerSet0).capacity);
            Assert.AreEqual(5, testPowerSet0.Union(testPowerSet1).capacity);
        }


        [TestMethod]
        public void Difference()
        {
            // Difference with PowerSet2 contains 2 similar items (expected 3 different items)
            testPowerSet = testPowerSet1.Difference(testPowerSet2);
            Assert.AreEqual(3, testPowerSet.capacity);
            Assert.AreEqual(true, testPowerSet.Get(8));
            Assert.AreEqual(true, testPowerSet.Get(10));
            Assert.AreEqual(true, testPowerSet.Get(12));
            Assert.AreEqual(false, testPowerSet.Get(16));

            testPowerSet = testPowerSet2.Difference(testPowerSet1);
            Assert.AreEqual(3, testPowerSet.capacity);
            Assert.AreEqual(true, testPowerSet.Get(162));
            Assert.AreEqual(true, testPowerSet.Get(0));
            Assert.AreEqual(true, testPowerSet.Get(5));
            Assert.AreEqual(false, testPowerSet.Get(12));

            // Difference with empty set (A / 0 = A)
            Assert.AreEqual(5, testPowerSet1.Difference(testPowerSet0).capacity);

            // Difference with empty set (0 / A = 0)
            Assert.AreEqual(0, testPowerSet0.Difference(testPowerSet1).capacity);
        }

        [TestMethod]
        public void IsSubSet()
        {
            // IsSubSet with PowerSet2 contains 5 items (expected false)
            Assert.AreEqual(false, testPowerSet1.IsSubset(testPowerSet2));
            Assert.AreEqual(false, testPowerSet2.IsSubset(testPowerSet1));

            // IsSubSet with empty set (0 isSubset(A) = false)
            Assert.AreEqual(false, testPowerSet0.IsSubset(testPowerSet1));

            // IsSubSet with empty set (A isSubset(0) = true)
            Assert.AreEqual(true, testPowerSet1.IsSubset(testPowerSet0));

            // empty set with empty set (0 isSubset(0) = true)
            Assert.AreEqual(true, testPowerSet0.IsSubset(testPowerSet0));

            // Putting 3 items to the empty set
            testPowerSet0.Put(10);
            testPowerSet0.Put(12);
            testPowerSet0.Put(14);
            Assert.AreEqual(3, testPowerSet0.capacity);

            // IsSubSet with PowerSet0 contains 3 items (expected true)
            Assert.AreEqual(true, testPowerSet1.IsSubset(testPowerSet0));
            // IsSubSet with PowerSet1 contains 5 items from PowerSet0 contains 3 items (expected false)
            Assert.AreEqual(false, testPowerSet0.IsSubset(testPowerSet1));

        }
    }
}
