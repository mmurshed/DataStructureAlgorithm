using System;
namespace DataStructure.Graph.Simple
{
    public class Edge
    {
        public readonly int First;
        public readonly int Second;
        public Edge(int f, int s)
        {
            First = f;
            Second = s;
        }
        public bool Equals(Edge p)
        {
            return p.First == First && p.Second == Second;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge);
        }

        public override int GetHashCode()
        {
            return First.GetHashCode() ^ Second.GetHashCode();
        }
    }
}
