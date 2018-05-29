using System.Linq;
using DataStructure.Graph;

namespace Algorithm.Graph
{
    public class MinimalSpanningTreeKruskal<V> : MinimalSpanningTree<V>
    {
        UnionFind<V, int> unionFind;

        public MinimalSpanningTreeKruskal(IGraph<V, int> graph, IVertex<V> source)
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


        // Kruskal's MST
        /*
         * 1. Sort edges by decresing weight
         * 2. Pick the first edge with lowest weight
         * 3. Detect cycle
         * 4. Add to graph if not cycle
        */
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
