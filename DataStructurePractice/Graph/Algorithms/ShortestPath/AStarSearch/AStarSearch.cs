using System;
using System.Collections.Generic;

namespace Graph.Algorithms
{
    public class AStarSearch<V> : SingleSourceShortestPath<V>
        where V: IComparable
    {
        public class VertexComparer : IComparer<IVertex2<V>>
        {
            public int Compare(IVertex2<V> x, IVertex2<V> y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }

        private PriorityQueue.PriorityQueue<IVertex2<V>> queue;
        private IAStarHeuristic<V> heuristic;
        private IVertex2<V> target;

        public AStarSearch(IGraph2<V, int> graph, IVertex2<V> source, IVertex2<V> target, IAStarHeuristic<V> heuristic)
            : base(graph, source)
        {
            this.heuristic = heuristic;
            this.target = target;
        }

        protected override void Init()
        {
            base.Init();
            queue = new PriorityQueue.PriorityQueue<IVertex2<V>>(new VertexComparer());
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
                    int heuristicDistance = heuristic.Distance(w, target);
                    var newDistance = Distance[(int)v.ID] + edge.Value + heuristicDistance;

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
