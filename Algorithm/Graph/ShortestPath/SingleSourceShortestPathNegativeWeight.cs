﻿using System;
using DataStructure.Graph;

namespace Algorithm.Graph.ShortestPath
{
    public class SingleSourceShortestPathNegativeWeight<V> : SingleSourceShortestPath<V>
    {
        public SingleSourceShortestPathNegativeWeight(IGraph<V, int> graph, IVertex<V> source)
            : base(graph, source)
        {
        }

        // Bellman-Ford
        public override void ShortestPath()
        {
            Init();

            for (int i = 0; i < graph.Size; i++)
            {
                foreach (var edge in graph.Edges)
                {
                    var u = edge.Start;
                    var v = edge.End;
                    var newDistance = Distance[u.ID] + edge.Value;
                    if (newDistance < Distance[v.ID])
                    {
                        Distance[v.ID] = newDistance;
                        PreviousVertex[v.ID] = u;
                    }
                }
            }

            // Check Negative
            foreach (var edge in graph.Edges)
            {
                var u = edge.Start;
                var v = edge.End;

                if (Distance[u.ID] + edge.Value < Distance[v.ID])
                {
                    throw new Exception("Negative edge cyecle detected");
                }                    
            }
        }
    }
}