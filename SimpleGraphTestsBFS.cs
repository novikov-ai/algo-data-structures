using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    [TestClass]
    public class SimpleGraphTests
    {
        SimpleGraph<int> myGraph;

        [TestInitialize]
        public void TestInitialize()
        {
            myGraph = new SimpleGraph<int>(30);

            myGraph.AddVertex(1); // 0
            myGraph.AddVertex(2); // 1
            myGraph.AddVertex(3); // 2
            myGraph.AddVertex(6); // 3
            myGraph.AddVertex(5); // 4
            myGraph.AddVertex(7); // 5
            myGraph.AddVertex(4); // 6
            myGraph.AddVertex(8); // 7
            myGraph.AddVertex(9); // 8
            myGraph.AddVertex(10); // 9
            myGraph.AddVertex(13); // 10
            myGraph.AddVertex(12); // 11
            myGraph.AddVertex(14); // 12
            myGraph.AddVertex(77); // 13

            myGraph.AddEdge(0, 1);
            myGraph.AddEdge(0, 2);
            myGraph.AddEdge(0, 3);
            myGraph.AddEdge(1, 4);
            myGraph.AddEdge(1, 5);
            myGraph.AddEdge(2, 6);
            myGraph.AddEdge(3, 7);
            myGraph.AddEdge(7, 8);
            myGraph.AddEdge(7, 9);

            myGraph.AddEdge(2, 8);
            myGraph.AddEdge(8, 10);
            myGraph.AddEdge(1, 10);
            myGraph.AddEdge(2, 10);
            myGraph.AddEdge(4, 10);
            myGraph.AddEdge(6, 8);
            myGraph.AddEdge(6, 10);
            myGraph.AddEdge(6, 3);
            myGraph.AddEdge(1, 2);
            myGraph.AddEdge(2, 3);
            myGraph.AddEdge(9, 11);
            myGraph.AddEdge(11, 12);
            myGraph.AddEdge(11, 7);
            myGraph.AddEdge(12, 7);
            myGraph.AddEdge(3, 11);
            myGraph.AddEdge(0, 12);
            myGraph.AddEdge(3, 13);
            myGraph.AddEdge(12, 13);
            myGraph.AddEdge(0, 13);
            myGraph.AddEdge(9, 13);
        }

        [TestMethod]
        public void IsEdge()
        {
            // vertex[0]
            Assert.AreEqual(true, myGraph.IsEdge(0,13));
            Assert.AreEqual(true, myGraph.IsEdge(0,1));
            Assert.AreEqual(true, myGraph.IsEdge(0,2));
            Assert.AreEqual(true, myGraph.IsEdge(0,3));
            Assert.AreEqual(true, myGraph.IsEdge(0,12));

            // vertex[1]
            Assert.AreEqual(true, myGraph.IsEdge(1,4));
            Assert.AreEqual(true, myGraph.IsEdge(1,5));
            Assert.AreEqual(true, myGraph.IsEdge(1,10));
            Assert.AreEqual(true, myGraph.IsEdge(1,2));

            // vertex[2]
            Assert.AreEqual(true, myGraph.IsEdge(2, 3));
            Assert.AreEqual(true, myGraph.IsEdge(2, 8));
            Assert.AreEqual(true, myGraph.IsEdge(2, 6));
            Assert.AreEqual(true, myGraph.IsEdge(2, 10));

            // vertex[3]
            Assert.AreEqual(true, myGraph.IsEdge(3, 6));
            Assert.AreEqual(true, myGraph.IsEdge(3, 7));
            Assert.AreEqual(true, myGraph.IsEdge(3, 11));
            Assert.AreEqual(true, myGraph.IsEdge(3, 13));

            // vertex[4]
            Assert.AreEqual(true, myGraph.IsEdge(4, 10));

            // vertex[6]
            Assert.AreEqual(true, myGraph.IsEdge(6, 8));
            Assert.AreEqual(true, myGraph.IsEdge(6, 10));

            // vertex[7]
            Assert.AreEqual(true, myGraph.IsEdge(7, 8));
            Assert.AreEqual(true, myGraph.IsEdge(7, 9));
            Assert.AreEqual(true, myGraph.IsEdge(7, 11));
            Assert.AreEqual(true, myGraph.IsEdge(7, 12));

            // vertex[8]
            Assert.AreEqual(true, myGraph.IsEdge(8, 10));

            // vertex[9]
            Assert.AreEqual(true, myGraph.IsEdge(9, 11));
            Assert.AreEqual(true, myGraph.IsEdge(9, 13));

            // vertex[11]
            Assert.AreEqual(true, myGraph.IsEdge(11, 12));

            // vertex[12]
            Assert.AreEqual(true, myGraph.IsEdge(12, 13));
        }

        [TestMethod]
        public void BreadthFirstSearch()
        {
            List<Vertex<int>> test = new List<Vertex<int>>();
            string ResultString = "";

            // 4-6-77
            test = myGraph.BreadthFirstSearch(6, 13);

            if (test.Count > 0)
            {
                foreach (Vertex<int> item in test)
                {
                    ResultString += item.Value.ToString()+" ";
                }
            }

            Assert.AreEqual("4 6 77 ", ResultString);
            ResultString = "";

            // 1-2-13
            test = myGraph.BreadthFirstSearch(0, 10);

            if (test.Count > 0)
            {
                foreach (Vertex<int> item in test)
                {
                    ResultString += item.Value.ToString() + " ";
                }
            }

            Assert.AreEqual("1 2 13 ", ResultString);
            ResultString = "";

            // 5-2-1-77
            test = myGraph.BreadthFirstSearch(4, 13);

            if (test.Count > 0)
            {
                foreach (Vertex<int> item in test)
                {
                    ResultString += item.Value.ToString() + " ";
                }
            }

            Assert.AreEqual("5 2 1 77 ", ResultString);
            ResultString = "";

            // 13-9-8-14
            // 13-2-1-14
            test = myGraph.BreadthFirstSearch(10, 12);

            if (test.Count > 0)
            {
                foreach (Vertex<int> item in test)
                {
                    ResultString += item.Value.ToString() + " ";
                }
            }

            Assert.AreEqual("13 2 1 14 ", ResultString);
            ResultString = "";

            // не найден (индекс за пределами)
            test = myGraph.BreadthFirstSearch(-5, 242);

            if (test.Count > 0)
            {
                foreach (Vertex<int> item in test)
                {
                    ResultString += item.Value.ToString() + " ";
                }
            }

            Assert.AreEqual("", ResultString);
            ResultString = "";

            // 5
            test = myGraph.BreadthFirstSearch(5, 5);

            if (test.Count > 0)
            {
                foreach (Vertex<int> item in test)
                {
                    ResultString += item.Value.ToString() + " ";
                }
            }

            Assert.AreEqual("7 ", ResultString);
            ResultString = "";
        }
    }
}