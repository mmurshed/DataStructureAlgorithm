using System;
using System.Collections.Generic;

namespace Graph
{
    public class LinkedVertex2<V, E> : ILinkedVertex2<V, E>
    {
        public V Value { get; }
        public IDictionary<ILinkedVertex2<V, E>, IEdge<V, E>> Neighbours { get; }
        public int NeighbourCount => Neighbours.Count;

        public LinkedVertex2(V value)
        {
            Value = value;
            Neighbours = new Dictionary<ILinkedVertex2<V, E>, IEdge<V, E>>();
        }

        public void Add(ILinkedVertex2<V, E> vertex, IEdge<V, E> edge)
        {
            Neighbours.Add(vertex, edge);
        }

        public void Remove(ILinkedVertex2<V, E> vertex)
        {
            Neighbours.Remove(vertex);
        }

        public override bool Equals(object obj)
        {
            var vertex = obj as LinkedVertex2<V, E>;
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
