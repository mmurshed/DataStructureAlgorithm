using System;
namespace Graph
{
    public class VertexPair<V> : IEquatable<VertexPair<V>>
    {
        public IVertex<V> Start { get; set; }
        public IVertex<V> End { get; set; }
   
        public VertexPair(IVertex<V> start, IVertex<V> end)
        {
            Start = start;
            End = end;
        }

        public bool Equals(VertexPair<V> vertexPair)
        {
            return vertexPair.Start.Equals(Start) && vertexPair.End.Equals(End);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as VertexPair<V>);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() ^ End.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format($"[VertexPair: Start={Start}, End={End}]");
        }
    }
}
