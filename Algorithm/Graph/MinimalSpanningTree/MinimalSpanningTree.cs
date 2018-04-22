using DataStructure.Graph;

namespace Algorithm.Graph
{
    public abstract class MinimalSpanningTree<V>
    {
        protected const int INFINITY = 99999;
        protected readonly IGraph<V, int> graph;
        protected readonly IVertex<V> source;

        public IGraph<V, int> MST { get; }

        public MinimalSpanningTree(IGraph<V, int> graph, IVertex<V> source)
        {
            this.graph = graph;
            this.source = source;
            MST = new GraphList<V, int>();
        }

        public abstract void GenerateMST();
    }
}
