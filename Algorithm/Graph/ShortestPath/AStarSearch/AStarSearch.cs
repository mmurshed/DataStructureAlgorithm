using System;
using System.Collections.Generic;
using DataStructure.Graph;
using DataStructure.Queue;

namespace Algorithm.Graph.ShortestPath
{
    public class AStarSearch<V> : SingleSourceShortestPath<V>
        where V: IComparable
    {
        public class VertexComparer : IComparer<IVertex<V>>
        {
            public int Compare(IVertex<V> x, IVertex<V> y)
            {
                return x.Value.CompareTo(y.Value);
            }
        }

        private PriorityQueueDeprecated<IVertex<V>> queue;
        private IAStarHeuristic<V> heuristic;
        private IVertex<V> target;

        public AStarSearch(IGraph<V, int> graph, IVertex<V> source, IVertex<V> target, IAStarHeuristic<V> heuristic)
            : base(graph, source)
        {
            this.heuristic = heuristic;
            this.target = target;
        }

        protected override void Init()
        {
            base.Init();
            queue = new PriorityQueueDeprecated<IVertex<V>>(new VertexComparer());
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
