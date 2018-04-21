using System;
using System.Collections.Generic;

namespace Graph.Deprecated
{
    public class LinkedVertex<V, E> : ILinkedVertex<V, E>
    {
        public uint ID { get; set; }
        public V Value { get; }
        public ICollection<IVertex<V>> Neighbours { get; }
        public int NeighbourCount => Neighbours.Count;

        public ICollection<IEdge<V, E>> Edges { get; set; }

        public LinkedVertex(V value) : this(default(uint), value)
        {
        }

        public LinkedVertex(uint id, V value)
        {
            ID = id;
            Value = value;
            Neighbours = new List<IVertex<V>>();
            Edges = new List<IEdge<V, E>>();
        }

        public void Add(IVertex<V> vertex)
        {
            Neighbours.Add(vertex);
        }

        public void Remove(IVertex<V> vertex)
        {
            Neighbours.Remove(vertex);
        }
    }
}
