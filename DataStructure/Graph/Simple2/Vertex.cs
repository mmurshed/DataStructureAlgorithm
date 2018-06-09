using System.Collections.Generic;

namespace DataStructure.Graph.Simple2
{
    public class Vertex
    {
        public readonly int Value;
        public List<int> Neighbours;

        public Vertex(int v)
        {
            Value = v;
            Neighbours = new List<int>();
        }
    }
}
