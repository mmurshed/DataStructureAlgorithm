using System;
namespace Graph
{
    public abstract class MinimalSpanningTree<V>
    {
        protected const int INFINITY = 99999;
        protected readonly IGraph2<V, int> graph;
        protected readonly IVertex2<V> source;

        public IGraph2<V, int> MST { get; }

        public MinimalSpanningTree(IGraph2<V, int> graph, IVertex2<V> source)
        {
            this.graph = graph;
            this.source = source;
            MST = new GraphList2<V, int>();
        }

        public abstract void GenerateMST();
    }
}
