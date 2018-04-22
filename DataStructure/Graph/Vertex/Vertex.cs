using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Vertex<V> : IVertex<V>
    {
        public uint ID { get; set; }
        public V Value { get; }

        public Vertex(V value) : this(default(uint), value)
        {
        }

        public Vertex(uint ID, V value)
        {
            this.ID = ID;
            Value = value;
        }

        public bool Equals(IVertex<V> vertex)
        {
            return vertex.Value.Equals(Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex<V>);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"[Vertex: Value={Value}]";
        }
    }
}
