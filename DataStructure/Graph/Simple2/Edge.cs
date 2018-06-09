using System;
namespace DataStructure.Graph.Simple2
{
    public class Edge
    {
        public readonly int First;
        public readonly int Second;
        public readonly int Weight;
        public Edge(int f, int s, int w = 0)
        {
            First = f;
            Second = s;
            Weight = w;
        }
    }
}
