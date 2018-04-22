using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.NUnit.Graph
{
    [TestFixture()]
    public class GraphSearchVisitorTests
    {
        [Test()]
        public void TestBreadthFirstVisitor()
        {
            // Arrange
            var testGraph = new DataStructure.NUnit.Builder.TestGraphMatrixBuilder();
            testGraph.Build();

            var vertexVisitor = new DataStructure.Graph.ListVertexVisitor<string>();
            var edgeVisitor = new DataStructure.Graph.DummyEdgeVisitor<string, int>();

            var graphSearch = new DataStructure.Graph.BreadthFirstSearch<string, int>();

            var expectedResult = new List<string> { "Los Angeles" };

            // Act
            graphSearch.Search(testGraph.Graph, vertexVisitor, edgeVisitor);

            // Assert
            CollectionAssert.AreEqual(expectedResult, vertexVisitor.VertexList.Select(x => x.Value.ToString()));
        }
    }
}
