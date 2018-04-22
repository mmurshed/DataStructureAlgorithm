using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class HyperEdge<V, E> : IHyperEdge<V, E>
    {
        public ICollection<IVertex<V>> Vertices { get; }

        public int VerticesCount => Vertices.Count;

        public E Value { get; set; }

        public HyperEdge()
        {
            Vertices = new List<IVertex<V>>();
        }

        public void Add(IVertex<V> vertex)
        {
            Vertices.Add(vertex);
        }

        public void Add(IEnumerable<IVertex<V>> vertices)
        {
            foreach(IVertex<V> vertex in Vertices)
                Add(vertex);
        }
    }
}
