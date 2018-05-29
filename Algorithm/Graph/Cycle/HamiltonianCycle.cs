using System;
using DataStructure.Graph;
using System.Collections.Generic;

namespace Algorithm.Graph.Cycle
{
    public class HamiltonianCycle<V, E>
    {
        /*
         * Source: https://www.geeksforgeeks.org/backtracking-set-7-hamiltonian-cycle/
         * 
         * Hamiltonian Path in an undirected graph is a path that visits each 
         * vertex exactly once. A Hamiltonian cycle (or Hamiltonian circuit) is
         * a Hamiltonian Path such that there is an edge (in graph) from the 
         * last vertex to the first vertex of the Hamiltonian Path. Determine 
         * whether a given graph contains Hamiltonian Cycle or not. If it 
         * contains, then print the path. Following are the input and output 
         * of the required function.
         */

        private IGraph<V, E> graph;
        private IVertex<V> source;
        public HashSet<IVertex<V>> path { get; private set; }

        private bool ContainsHamiltonianCycle(IVertex<V> cur)
        {
            // base case: If all vertices are included in Hamiltonian Cycle
            if (path.Count == graph.Size)
            {
                // True iff there is an edge from the last included vertex
                // to the first vertex
                return graph.HasEdge(cur, source);
            }

            // Try neighbouring vertices as a next candidate in Hamiltonian Cycle
            foreach(var v in graph.GetNeighbours(cur))
            {
                // Check if this vertex can be added to Hamiltonian Cycle
                if (!path.Contains(v))
                {
                    path.Add(v);

                    // recur to construct rest of the path
                    if (ContainsHamiltonianCycle(v))
                        return true;

                    // If adding vertex v doesn't lead to a solution, then remove it
                    path.Remove(v);
                }
            }

            // If no vertex can be added to Hamiltonian Cycle constructed so far,
            // then return false
            return false;
        }


        public bool ContainsHamiltonianCycle(IGraph<V, E> _graph)
        {
            this.graph = _graph;
            path = new HashSet<IVertex<V>>();

            source = null;
            var en = graph.Vertices.GetEnumerator();

            if (en.MoveNext())
            {
                source = en.Current;
            }

            if (source == null)
                return false;

            path.Add(source);

            return ContainsHamiltonianCycle(source);
        }

    }
}
