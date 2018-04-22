using System;
using System.Collections.Generic;

namespace DataStructure.Graph.Deprecated
{
    public class Vertex<V> : IVertex<V>
    {
        public uint ID { get; set; }
        public V Value { get; }
        public ICollection<IVertex<V>> Neighbours { get; }
        public int NeighbourCount => Neighbours.Count;

        public Vertex(V value) : this (default(uint), value)
        {
        }

        public Vertex(uint id, V value)
        {
            ID = id;
            Value = value;
            Neighbours = new List<IVertex<V>>();
        }

        public void Add(IVertex<V> vertex)
        {
            Neighbours.Add(vertex);
        }

        public void Remove(IVertex<V> vertex)
        {
            Neighbours.Remove(vertex);
        }

        public override bool Equals(object obj)
        {
            Vertex<V> vertex = obj as Vertex<V>;
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
