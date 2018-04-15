using System;
using System.Linq;

namespace Graph
{
    public class MinimalSpanningTreeKruskal<V> : MinimalSpanningTree<V>
    {
        UnionFind<V, int> unionFind;

        public MinimalSpanningTreeKruskal(IGraph2<V, int> graph, IVertex2<V> source)
            : base(graph, source)
        {
            unionFind = new UnionFind<V, int>(graph.Size);
        }

        private void Init()
        {
            foreach (var v in graph.Vertices)
            {
                MST.AddVertex(v);
            }
        }


        // Prim's MST
        public override void GenerateMST()
        {
            var edgeEnum = graph.Edges.OrderBy(e => e.Value);

            foreach(var nextEdge in edgeEnum)
            {
                var isCycle = unionFind.IsCycle((int)nextEdge.Start.ID, (int)nextEdge.End.ID);
                if(!isCycle)
                {
                    MST.AddEdge(nextEdge);
                }
            }
        }
    }
}
