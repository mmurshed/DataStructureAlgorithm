using System;
using DataStructure.Graph.Simple2;

namespace Algorithm.Graph
{
    public class ReverseGraph
    {
        public static DataStructure.Graph.Simple2.Graph GetReverse(DataStructure.Graph.Simple2.Graph g)
        {
            var r = new DataStructure.Graph.Simple2.Graph();
            r.Vertices.AddRange(g.Vertices);
            foreach(var kv in g.Edges)
            {
                var e = kv.Key;
                r.Add(new Edge(e.Second, e.First, e.Weight));
            }

            return r;
        }
    }
}
