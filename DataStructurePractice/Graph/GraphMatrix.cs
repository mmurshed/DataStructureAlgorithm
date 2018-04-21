using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphMatrix2<V, E> : IGraph<V, E>
        where V: struct
    {
        private Dictionary<V, IVertex2<V>> vertexCollection;

        public IEnumerable<IVertex2<V>> Vertices => vertexCollection.Values;
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

        public GraphMatrix2(int count)
        {
            vertexCollection = new Dictionary<V, IVertex2<V>>();

            vertexID = 0;
            adjacencyMatrix = new IEdge<V, E>[count, count];
        }

        public void AddVertex(IVertex2<V> v)
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

        public IEnumerable<IVertex2<V>> GetNeighbours(IVertex2<V> vertex)
        {
            for (int i = 0; i < Size; i++)
            {
                if(adjacencyMatrix[vertex.ID, i] != null)
                    yield return adjacencyMatrix[vertex.ID, i].GetOtherVertex(vertex);
            }
        }

        public IVertex2<V> GetVertexByID(uint id)
        {
            return vertexCollection.Where(kv => kv.Value.ID == id).Select(kv => kv.Value).FirstOrDefault();
        }

        public IVertex2<V> GetVertex(V value)
        {
            return vertexCollection[value];
        }

        public IEdge<V, E> GetEdge(IVertex2<V> start, IVertex2<V> end)
        {
            return adjacencyMatrix[start.ID, end.ID];
        }

        public bool HasEdge(IVertex2<V> start, IVertex2<V> end)
        {
            return adjacencyMatrix[start.ID, end.ID] != null;
        }
    }
}
