using System;
using DataStructure.Graph;
using DataStructure.Queue;

namespace Algorithm.Graph.ShortestPath
{
    public class SingleSourceShortestPathPQ<V> : SingleSourceShortestPath<V>
        where V: IComparable
    {
        PriorityQueueDeprecated<IVertex<V>> queue;
        public SingleSourceShortestPathPQ(IGraph<V, int> graph, IVertex<V> source)
            : base(graph, source)
        {
        }

        protected override void Init()
        {
            base.Init();
            queue = new PriorityQueueDeprecated<IVertex<V>>( (a, b) => Distance[a.ID] - Distance[b.ID] );
            foreach (var vertex in graph.Vertices)
            {
                queue.Enqueue(vertex);
            }
        }

        // Dijkstra
        public override void ShortestPath()
        {
            Init();

            while(!queue.Empty)
            {
                var v = queue.Dequeue();

                foreach(var w in graph.GetNeighbours(v))
                {
                    if(Relax(v, w))
                        queue.Enqueue(w);
                }
            }
        }
    }
}
