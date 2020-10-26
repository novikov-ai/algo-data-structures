using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures2
{
    [TestClass]
    public class SimpleGraphTests
    {
        SimpleGraph mySimpleGraph;

        [TestInitialize]
        public void TestInitialize()
        {
            mySimpleGraph = new SimpleGraph(5);

            mySimpleGraph.AddVertex(12);
            mySimpleGraph.AddVertex(5);
            mySimpleGraph.AddVertex(43);
            mySimpleGraph.AddVertex(50);
        }

        [TestMethod]
        public void IsEdge()
        {
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 3]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 4]);

            Assert.AreEqual(0, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[2, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[3, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[4, 0]);
        }

        [TestMethod]
        public void AddVertex()
        {
            // add vertex
            // no edges

            Assert.AreEqual(4, mySimpleGraph.capacity);

            mySimpleGraph.AddVertex(0);
            Assert.AreEqual(5, mySimpleGraph.capacity);

            mySimpleGraph.AddVertex(13);
            Assert.AreEqual(5, mySimpleGraph.capacity);
        }

        [TestMethod]
        public void AddEdge()
        {
            // no edges
            // add
            // edges

            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[2, 0]);

            mySimpleGraph.AddEdge(0, 1);
            mySimpleGraph.AddEdge(0, 2);
            mySimpleGraph.AddEdge(0, 0);

            Assert.AreEqual(1, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[2, 0]);
        }

        [TestMethod]
        public void RemoveEdge()
        {
            // edge
            // remove
            // no edge

            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[2, 0]);

            mySimpleGraph.AddEdge(0, 1);
            mySimpleGraph.AddEdge(0, 2);

            Assert.AreEqual(1, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[2, 0]);

            mySimpleGraph.RemoveEdge(0, 2);

            Assert.AreEqual(1, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[2, 0]);
        }

        [TestMethod]
        public void RemoveVertex()
        {
            // vertex and edges
            // remove
            // no vertex and edges

            Assert.AreEqual(4, mySimpleGraph.capacity);

            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[2, 0]);

            mySimpleGraph.AddEdge(0, 1);
            mySimpleGraph.AddEdge(0, 2);

            Assert.AreEqual(1, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(1, mySimpleGraph.m_adjacency[2, 0]);

            mySimpleGraph.RemoveVertex(0);

            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 1]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[0, 2]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[1, 0]);
            Assert.AreEqual(0, mySimpleGraph.m_adjacency[2, 0]);

            Assert.AreEqual(3, mySimpleGraph.capacity);

            mySimpleGraph.RemoveVertex(3);
            mySimpleGraph.RemoveVertex(2);

            mySimpleGraph.RemoveVertex(0);
            Assert.AreEqual(1, mySimpleGraph.capacity);

            mySimpleGraph.RemoveVertex(1);
            Assert.AreEqual(0, mySimpleGraph.capacity);
        }
    }
}
