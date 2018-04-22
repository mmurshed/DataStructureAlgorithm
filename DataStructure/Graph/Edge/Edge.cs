using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class Edge<V, E> : IEdge<V, E>
    {
        public VertexPair<V> Pair { get; set; }
        public IVertex<V> Start => Pair.Start;
        public IVertex<V> End => Pair.End;
        public E Value { get; set; }

        public Edge(IVertex<V> start, IVertex<V> end) : this(start, end, default(E))
        {
        }

        public Edge(IVertex<V> start, IVertex<V> end, E value)
        {
            Pair = new VertexPair<V>(start, end);
            Value = value;
        }

        public IVertex<V> GetOtherVertex(IVertex<V> first)
        {
            return Pair.Start.Equals(first) ? Pair.End : Pair.Start;
        }

        public bool Equals(IEdge<V, E> edge)
        {
            return Start.Equals(edge.Start) && End.Equals(edge.End);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge<V, E>);
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
