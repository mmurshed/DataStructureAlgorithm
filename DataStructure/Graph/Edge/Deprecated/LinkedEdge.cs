using System;
using System.Collections.Generic;

namespace DataStructure.Graph.Deprecated
{
    public class LinkedEdge<V, E> : ILinkedEdge<V, E>
    {
        public IVertex<V> Start { get; set; }
        public IVertex<V> End { get; set; }
        public E Value { get; set; }

        public LinkedEdge(IVertex<V> start, IVertex<V> end, E value)
        {
            Start = start;
            End = end;
            Value = value;
            if (!Start.Neighbours.Contains(End))
            {
                Start.Neighbours.Add(End);
            }
        }

        public override bool Equals(object obj)
        {
            Edge<V, E> edge = obj as Edge<V, E>;
            return Value.Equals(edge.Value) && Start.Equals(edge.Start) && End.Equals(edge.End);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Start.GetHashCode() ^ End.GetHashCode();
        }

        public override string ToString()
        {
            return $"[Edge: Start={Start}, End={End}, Value={Value}]";
        }
    }
}
