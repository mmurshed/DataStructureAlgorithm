using System;
using System.Collections.Generic;

namespace Graph
{
    public class Vertex2<V> : IVertex2<V>
    {
        public uint ID { get; set; }
        public V Value { get; }

        public Vertex2(V value) : this(default(uint), value)
        {
        }

        public Vertex2(uint ID, V value)
        {
            this.ID = ID;
            Value = value;
        }

        public bool Equals(IVertex2<V> vertex)
        {
            return vertex.Value.Equals(Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex2<V>);
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
