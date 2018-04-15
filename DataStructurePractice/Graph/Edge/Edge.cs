using System;
using System.Collections.Generic;

namespace Graph
{
    public class Edge<V, E> : IEdge<V, E>
    {
        public IVertex<V> Start { get; set; }
        public IVertex<V> End { get; set; }
        public E Value { get; set; }

        public Edge(IVertex<V> start, IVertex<V> end) : this(start, end, default(E))
        {
        }

        public Edge(IVertex<V> start, IVertex<V> end, E value)
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
            return Start.Equals(edge.Start) && End.Equals(edge.End);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() ^ End.GetHashCode();
        }

        public override string ToString()
        {
            return $"[Edge: Start={Start}, End={End}, Value={Value}]";
        }
    }
}
