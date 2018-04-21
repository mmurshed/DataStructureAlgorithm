using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphList<V, E> : IGraph<V, E>
    {
        private Dictionary<V, IVertex<V>> vertexCollection;
        private Dictionary<VertexPair<V>, IEdge<V, E>> edgeCollection;

        public IEnumerable<IVertex<V>> Vertices => vertexCollection.Values;
        public IEnumerable<IEdge<V, E>> Edges => edgeCollection.Values;

        public int Size => vertexCollection.Count;

        private uint vertexID;
        private Dictionary<IVertex<V>, List<IVertex<V>>> adjacencyList;

        public GraphList()
        {
            vertexCollection = new Dictionary<V, IVertex<V>>();
            edgeCollection = new Dictionary<VertexPair<V>, IEdge<V, E>>();

            vertexID = 0;
            adjacencyList = new Dictionary<IVertex<V>, List<IVertex<V>>>();
        }

        public void AddVertex(IVertex<V> v)
        {
            if (!vertexCollection.ContainsKey(v.Value))
            {
                v.ID = vertexID;
                vertexID++;

                vertexCollection[v.Value] = v;
                if (!adjacencyList.ContainsKey(v))
                    adjacencyList[v] = new List<IVertex<V>>();
            }
        }

        public void AddEdge(IEdge<V, E> edge)
        {
            edgeCollection[edge.Pair] = edge;
            if (!adjacencyList.ContainsKey(edge.Start))
                adjacencyList[edge.Start] = new List<IVertex<V>>();
            
            adjacencyList[edge.Start].Add(edge.End);
        }

        public IEnumerable<IVertex<V>> GetNeighbours(IVertex<V> vertex)
        {
            return adjacencyList[vertex];
        }

        public IVertex<V> GetVertexByID(uint id)
        {
            return vertexCollection.Where( kv => kv.Value.ID == id).Select(kv => kv.Value).FirstOrDefault();
        }

        public IVertex<V> GetVertex(V value)
        {
            return vertexCollection[value];
        }

        public IEdge<V, E> GetEdge(IVertex<V> start, IVertex<V> end)
        {
            var index = new VertexPair<V>(start, end);
            return edgeCollection[index];
        }

        public bool HasEdge(IVertex<V> start, IVertex<V> end)
        {
            return GetEdge(start, end) != null;
        }

        public void RemoveVertex(V value)
        {
            vertexCollection.Remove(value);
        }

        public void RemoveEdge(IVertex<V> start, IVertex<V> end)
        {
            edgeCollection.Remove(new VertexPair<V>(start, end));
            adjacencyList[start].Remove(end);
        }

    }
}
