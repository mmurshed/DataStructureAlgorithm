﻿using System;
using System.Collections.Generic;
using DataStructure.Graph;

namespace Algorithm.Graph.ShortestPath
{
    public abstract class SingleSourceShortestPath<V> : IShortestPath<V>
    {
        protected const int INFINITY = 99999;
        protected readonly IGraph<V, int> graph;
        protected readonly IVertex<V> source;

        public int[] Distance { get; }
        public IVertex<V>[] PreviousVertex { get; }

        public SingleSourceShortestPath(IGraph<V, int> graph, IVertex<V> source)
        {
            this.graph = graph;
            this.source = source;
            Distance = new int[graph.Size];
            PreviousVertex = new IVertex<V>[graph.Size];
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

        public int GetDistance(IVertex<V> u, IVertex<V> v)
        {
            if(u != source)
            {
                throw new ArgumentException("Distance not available for the source vertex.");
            }
            return Distance[v.ID];
        }

        public LinkedList<IVertex<V>> GetPath(IVertex<V> u, IVertex<V> v)
        {
            var path = new LinkedList<IVertex<V>>();

            var w = v;

            while (PreviousVertex[w.ID] != null)
            {
                path.AddFirst(w);
                w = PreviousVertex[w.ID];
            }
            path.AddFirst(w);

            return path;
        }

        public bool Relax(IVertex<V> v, IVertex<V> w)
        {
            return Relax(graph.GetEdge(v, w));
        }

        public bool Relax(IEdge<V, int> edge)
        {
            var v = edge.Start;
            var w = edge.End;

            var newDistance = Distance[(int)v.ID] + edge.Value;

            // If the new distance is smaller than the previous distance calculated
            if (newDistance < Distance[(int)w.ID])
            {
                Distance[(int)w.ID] = newDistance;
                PreviousVertex[(int)w.ID] = v;
                return true;
            }

            return false;
        }

    }
}
