using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using DataStructure.Graph;

namespace DataStructure.NUnit.Graph
{
    [TestFixture()]
    public class GraphSearchVisitorTests
    {
        [Test()]
        public void TestBreadthFirstVisitor()
        {
            // Arrange
            var testGraph = new DataStructure.NUnit.Graph.Builder.TestGraphMatrixBuilder();
            testGraph.Build();

            var vertexVisitor = new DataStructure.Graph.ListVertexVisitor<string>();
            var edgeVisitor = new DataStructure.Graph.DummyEdgeVisitor<string, int>();

            var graphSearch = new DataStructure.Graph.BreadthFirstSearch<string, int>();

            var expectedResult = new List<string> { "Los Angeles", "San Francisco", "Las Vegas", "Portland", "Seattle", "Austin" };

            // Act
            graphSearch.Search(testGraph.Graph, vertexVisitor, edgeVisitor);

            // Assert
            CollectionAssert.AreEqual(expectedResult, vertexVisitor.VertexList.Select(x => x.Value.ToString()));
        }

		[Test()]
		public void TestDepthFirstVisitor()
		{
			// Arrange
			var testGraph = new DataStructure.NUnit.Graph.Builder.TestGraphMatrixBuilder();
			testGraph.Build();

			var vertexVisitor = new DataStructure.Graph.ListVertexVisitor<string>();
			var edgeVisitor = new DataStructure.Graph.DummyEdgeVisitor<string, int>();

			var graphSearch = new DataStructure.Graph.DepthFirstSearch<string, int>();

			var expectedResult = new List<string> { "Los Angeles", "San Francisco", "Portland", "Seattle", "Las Vegas", "Austin" };

			// Act
			graphSearch.Search(testGraph.Graph, vertexVisitor, edgeVisitor);

			// Assert
			CollectionAssert.AreEqual(expectedResult, vertexVisitor.VertexList.Select(x => x.Value.ToString()));
		}

		[Test()]
		public void TestDepthFirstStackVisitor()
		{
			// Arrange
			var testGraph = new DataStructure.NUnit.Graph.Builder.TestGraphMatrixBuilder();
			testGraph.Build();

			var vertexVisitor = new DataStructure.Graph.ListVertexVisitor<string>();
			var edgeVisitor = new DataStructure.Graph.DummyEdgeVisitor<string, int>();

			var graphSearch = new DataStructure.Graph.DepthFirstSearchStack<string, int>();

			var expectedResult = new List<string> { "Los Angeles", "Portland", "Seattle", "San Francisco", "Las Vegas", "Austin" };

			// Act
			graphSearch.Search(testGraph.Graph, vertexVisitor, edgeVisitor);

			// Assert
			CollectionAssert.AreEqual(expectedResult, vertexVisitor.VertexList.Select(x => x.Value.ToString()));
		}
	}
}
