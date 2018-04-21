using System;
using System.Collections.Generic;

namespace Graph
{
    public class Edge2<V, E> : IEdge2<V, E>
    {
        public VertexPair<V> Pair { get; set; }
        public IVertex2<V> Start => Pair.Start;
        public IVertex2<V> End => Pair.End;
        public E Value { get; set; }

        public Edge2(IVertex2<V> start, IVertex2<V> end) : this(start, end, default(E))
        {
        }

        public Edge2(IVertex2<V> start, IVertex2<V> end, E value)
        {
            Pair = new VertexPair<V>(start, end);
            Value = value;
        }

        public IVertex2<V> GetOtherVertex(IVertex2<V> first)
        {
            return Pair.Start.Equals(first) ? Pair.End : Pair.Start;
        }

        public bool Equals(IEdge2<V, E> edge)
        {
            return Start.Equals(edge.Start) && End.Equals(edge.End);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge2<V, E>);
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
