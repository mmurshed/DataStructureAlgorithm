using System.Collections.Generic;

namespace DataStructure.Graph.Simple2
{
    public class Vertex
    {
        public readonly int Value;
        public List<Vertex> Neighbours;

        public Vertex(int v)
        {
            Value = v;
            Neighbours = new List<Vertex>();
        }
    }
}
