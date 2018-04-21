using System;
using System.Collections.Generic;

namespace Graph.Algorithms
{
    public class SingleSourceShortestPathPQ<V> : SingleSourceShortestPath<V>
        where V: IComparable
    {
        PriorityQueue.PriorityQueue<IVertex<V>> queue;
        public SingleSourceShortestPathPQ(IGraph<V, int> graph, IVertex<V> source)
            : base(graph, source)
        {
        }

        protected override void Init()
        {
            base.Init();
            queue = new PriorityQueue.PriorityQueue<IVertex<V>>( (a, b) => Distance[a.ID] - Distance[b.ID] );
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
                    var edge = graph.GetEdge(v, w);
                    var newDistance = Distance[(int)v.ID] + edge.Value;

                    if (newDistance < Distance[(int)w.ID])
                    {
                        Distance[(int)w.ID] = newDistance;
                        PreviousVertex[(int)w.ID] = v;
                    }
                }
            }
        }
    }
}
