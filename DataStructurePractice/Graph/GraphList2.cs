using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphList2<V, E> : IGraph2<V, E>
    {
        private Dictionary<V, IVertex2<V>> vertexCollection;
        private Dictionary<VertexPair<V>, IEdge2<V, E>> edgeCollection;

        public IEnumerable<IVertex2<V>> Vertices => vertexCollection.Values;
        public IEnumerable<IEdge2<V, E>> Edges => edgeCollection.Values;

        public int Size => vertexCollection.Count;

        private uint vertexID;
        private Dictionary<IVertex2<V>, List<IVertex2<V>>> adjacencyList;

        public GraphList2()
        {
            vertexCollection = new Dictionary<V, IVertex2<V>>();
            edgeCollection = new Dictionary<VertexPair<V>, IEdge2<V, E>>();

            vertexID = 0;
            adjacencyList = new Dictionary<IVertex2<V>, List<IVertex2<V>>>();
        }

        public void AddVertex(IVertex2<V> v)
        {
            if (!vertexCollection.ContainsKey(v.Value))
            {
                v.ID = vertexID;
                vertexID++;

                vertexCollection[v.Value] = v;
                if (!adjacencyList.ContainsKey(v))
                    adjacencyList[v] = new List<IVertex2<V>>();
            }
        }

        public void AddEdge(IEdge2<V, E> edge)
        {
            edgeCollection[edge.Pair] = edge;
            if (!adjacencyList.ContainsKey(edge.Start))
                adjacencyList[edge.Start] = new List<IVertex2<V>>();
            
            adjacencyList[edge.Start].Add(edge.End);
        }

        public IEnumerable<IVertex2<V>> GetNeighbours(IVertex2<V> vertex)
        {
            return adjacencyList[vertex];
        }

        public IVertex2<V> GetVertexByID(uint id)
        {
            return vertexCollection.Where( kv => kv.Value.ID == id).Select(kv => kv.Value).FirstOrDefault();
        }

        public IVertex2<V> GetVertex(V value)
        {
            return vertexCollection[value];
        }

        public IEdge2<V, E> GetEdge(IVertex2<V> start, IVertex2<V> end)
        {
            var index = new VertexPair<V>(start, end);
            return edgeCollection[index];
        }

        public bool HasEdge(IVertex2<V> start, IVertex2<V> end)
        {
            return GetEdge(start, end) != null;
        }
    }
}
