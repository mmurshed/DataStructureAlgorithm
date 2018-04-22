using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class LinkedVertex<V, E> : ILinkedVertex<V, E>
    {
        public V Value { get; }
        public IDictionary<ILinkedVertex<V, E>, IEdge<V, E>> Neighbours { get; }
        public int NeighbourCount => Neighbours.Count;

        public LinkedVertex(V value)
        {
            Value = value;
            Neighbours = new Dictionary<ILinkedVertex<V, E>, IEdge<V, E>>();
        }

        public void Add(ILinkedVertex<V, E> vertex, IEdge<V, E> edge)
        {
            Neighbours.Add(vertex, edge);
        }

        public void Remove(ILinkedVertex<V, E> vertex)
        {
            Neighbours.Remove(vertex);
        }

        public override bool Equals(object obj)
        {
            var vertex = obj as LinkedVertex<V, E>;
            return Value.Equals(vertex.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
