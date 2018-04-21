using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphMatrix<V, E> : IGraph<V, E>
    {
        private Dictionary<V, IVertex<V>> vertexCollection;

        public IEnumerable<IVertex<V>> Vertices => vertexCollection.Values;
        public IEnumerable<IEdge<V, E>> Edges 
        {
            get
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if(adjacencyMatrix[i, j] != null)
                            yield return adjacencyMatrix[i, j];
                    }
                }

            }
        }

        public int Size => vertexCollection.Count;

        private uint vertexID;
        private IEdge<V, E>[,] adjacencyMatrix;

        public GraphMatrix(int count)
        {
            vertexCollection = new Dictionary<V, IVertex<V>>();

            vertexID = 0;
            adjacencyMatrix = new IEdge<V, E>[count, count];
        }

        public void AddVertex(IVertex<V> v)
        {
            if (!vertexCollection.ContainsKey(v.Value))
            {
                v.ID = vertexID;
                vertexID++;
                vertexCollection[v.Value] = v;
            }
        }

        public void AddEdge(IEdge<V, E> edge)
        {
            adjacencyMatrix[edge.Start.ID, edge.End.ID] = edge;
        }

        public IEnumerable<IVertex<V>> GetNeighbours(IVertex<V> vertex)
        {
            for (int i = 0; i < Size; i++)
            {
                if(adjacencyMatrix[vertex.ID, i] != null)
                    yield return adjacencyMatrix[vertex.ID, i].GetOtherVertex(vertex);
            }
        }

        public IVertex<V> GetVertexByID(uint id)
        {
            return vertexCollection.Where(kv => kv.Value.ID == id).Select(kv => kv.Value).FirstOrDefault();
        }

        public IVertex<V> GetVertex(V value)
        {
            return vertexCollection[value];
        }

        public IEdge<V, E> GetEdge(IVertex<V> start, IVertex<V> end)
        {
            return adjacencyMatrix[start.ID, end.ID];
        }

        public bool HasEdge(IVertex<V> start, IVertex<V> end)
        {
            return adjacencyMatrix[start.ID, end.ID] != null;
        }

        public void RemoveVertex(V value)
        {
            vertexCollection.Remove(value);
        }

        public void RemoveEdge(IVertex<V> start, IVertex<V> end)
        {
            adjacencyMatrix[start.ID, end.ID] = null;
        }
    }
}
