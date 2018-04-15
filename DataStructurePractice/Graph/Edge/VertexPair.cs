using System;
namespace Graph
{
    public class VertexPair<V> : IEquatable<VertexPair<V>>
    {
        public IVertex2<V> Start { get; set; }
        public IVertex2<V> End { get; set; }
   
        public VertexPair(IVertex2<V> start, IVertex2<V> end)
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
