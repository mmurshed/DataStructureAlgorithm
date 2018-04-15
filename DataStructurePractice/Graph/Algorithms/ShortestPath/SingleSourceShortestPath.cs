using System;
using System.Collections.Generic;

namespace Graph.Algorithms
{
    public abstract class SingleSourceShortestPath<V> : IShortestPath<V>
    {
        protected const int INFINITY = 99999;
        protected readonly IGraph2<V, int> graph;
        protected readonly IVertex2<V> source;

        public int[] Distance { get; }
        public IVertex2<V>[] PreviousVertex { get; }

        public SingleSourceShortestPath(IGraph2<V, int> graph, IVertex2<V> source)
        {
            this.graph = graph;
            this.source = source;
            Distance = new int[graph.Size];
            PreviousVertex = new IVertex2<V>[graph.Size];
        }

        protected virtual void Init()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                Distance[i] = INFINITY;
                PreviousVertex[i] = null;
            }
            Distance[source.ID] = 0;
        }

        public abstract void ShortestPath();

        public int GetDistance(IVertex2<V> u, IVertex2<V> v)
        {
            if(u != source)
            {
                throw new ArgumentException("Distance not available for the source vertex.");
            }
            return Distance[v.ID];
        }

        public LinkedList<IVertex2<V>> GetPath(IVertex2<V> u, IVertex2<V> v)
        {
            var path = new LinkedList<IVertex2<V>>();

            var w = v;

            while (PreviousVertex[w.ID] != null)
            {
                path.AddFirst(w);
                w = PreviousVertex[w.ID];
            }
            path.AddFirst(w);

            return path;
        }
    }
}
