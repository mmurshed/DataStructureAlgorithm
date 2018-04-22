using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class HamiltonianCycleAlgorithm
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
         * 
         * Input:
         * A 2D array graph[V, V] where V is the number of vertices in graph and
         * graph[V, V] is adjacency matrix representation of the graph. A value 
         * graph[i, j] is 1 if there is a direct edge from i to j, otherwise 
         * graph[i, j] is 0.
         * 
         * Output:
         * An array path[V] that should contain the Hamiltonian Path. path[i] 
         * should represent the ith vertex in the Hamiltonian Path. The code 
         * should also return false if there is no Hamiltonian Cycle in the graph.
         * 
         * For example, a Hamiltonian Cycle in the following graph is 
         * {0, 1, 2, 4, 3, 0}. There are more Hamiltonian Cycles in the graph 
         * like {0, 3, 4, 2, 1, 0}
         * 
         * (0)--(1)--(2)
         * |   / \   |
         * |  /   \  | 
         * | /     \ |
         * (3)-------(4)
         * 
         * And the following graph doesn’t contain any Hamiltonian Cycle.
         * 
         * (0)--(1)--(2)
         * |   / \   |
         * |  /   \  | 
         * | /     \ |
         * (3)      (4) 
         * 
         *
         * Naive Algorithm
         * Generate all possible configurations of vertices and print a 
         * configuration that satisfies the given constraints. There will be 
         * n! (n factorial) configurations.
         * 
         * while there are untried conflagrations
         * {
         *      generate the next configuration
         *      if ( there are edges between two consecutive vertices of this
         *      configuration and there is an edge from the last vertex to 
         *      the first ).
         * 
         *      {
         *          print this configuration;
         *          break;
         *      }
         * }
         * 
         * Backtracking Algorithm
         * Create an empty path array and add vertex 0 to it. Add other 
         * vertices, starting from the vertex 1. Before adding a vertex, 
         * check for whether it is adjacent to the previously added vertex and 
         * not already added. If we find such a vertex, we add the vertex as 
         * part of the solution. If we do not find a vertex then we return false.
        */

        private const int SIZE = 5;


        /// <summary>
        /// A utility function to check if the vertex v can be added at
        /// index 'pos' in the Hamiltonian Cycle constructed so far(stored
        /// in 'path[]')
        /// </summary>
        /// <returns><c>true</c>, if safe was ised, <c>false</c> otherwise.</returns>
        /// <param name="v">V.</param>
        /// <param name="graph">Graph.</param>
        /// <param name="path">Path.</param>
        /// <param name="pos">Position.</param>
        bool IsValid(int v, bool[,] graph, int[] path, int pos)
        {
            // Check if this vertex is an adjacent vertex of the previously
            // added vertex.
            if (graph[path[pos - 1], v] == false)
                return false;

            // Check if the vertex has already been included.
            // This step can be optimized by creating an array of size V 
            for (int i = 0; i < pos; i++)
                if (path[i] == v)
                    return false;

            return true;
        }

        /// <summary>
        /// A recursive utility function to solve hamiltonian cycle problem
        /// </summary>
        /// <returns><c>true</c>, if cycle was hamiltonian, <c>false</c> otherwise.</returns>
        /// <param name="graph">Graph.</param>
        /// <param name="path">Path.</param>
        /// <param name="pos">Position.</param>
        bool HamiltonianCycle(bool[,] graph, int[] path, int pos)
        {
            // base case: If all vertices are included in Hamiltonian Cycle
            if (pos == SIZE)
            {
                // And if there is an edge from the last included vertex to the
                // first vertex
                if (graph[path[pos - 1], path[0]] == true)
                    return true;
                else
                    return false;
            }

            // Try different vertices as a next candidate in Hamiltonian Cycle.
            // We don't try for 0 as we included 0 as starting point in in hamCycle()
            for (int v = 1; v < SIZE; v++)
            {
                // Check if this vertex can be added to Hamiltonian Cycle
                if (IsValid(v, graph, path, pos))
                {
                    path[pos] = v;

                    // recur to construct rest of the path
                    if (HamiltonianCycle(graph, path, pos + 1) == true)
                        return true;

                    // If adding vertex v doesn't lead to a solution, then remove it
                    path[pos] = -1;
                }
            }

            // If no vertex can be added to Hamiltonian Cycle constructed so far,
            // then return false
            return false;
        }

        /* This function solves the Hamiltonian Cycle problem using Backtracking.
          It mainly uses hamCycleUtil() to solve the problem. It returns false
          if there is no Hamiltonian Cycle possible, otherwise return true and
          prints the path. Please note that there may be more than one solutions,
          this function prints one of the feasible solutions. */
        bool HamiltonianCycle(bool[,] graph)
        {
            var path = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
                path[i] = -1;

            /* Let us put vertex 0 as the first vertex in the path. If there is
               a Hamiltonian Cycle, then the path can be started from any point
               of the cycle as the graph is undirected */
            path[0] = 0;
            if (HamiltonianCycle(graph, path, 1) == false)
            {
                Console.Write("Solution does not exist");
                return false;
            }

            printSolution(path);
            return true;
        }

        /* A utility function to print solution */
        void printSolution(int[] path)
        {
            Console.Write("Solution Exists. Following is one Hamiltonian Cycle \n");
            for (int i = 0; i < SIZE; i++)
                Console.Write($" {path[i]} ");

            // Let us print the first vertex again to show the complete cycle
            Console.Write($" {path[0]} ");
            Console.WriteLine();
        }

        // driver program to test above function
        public void Test()
        {
            /* Let us create the following graph
               (0)--(1)--(2)
                |   / \   |
                |  /   \  |
                | /     \ |
               (3)-------(4)    */
            var graph1 = new bool[,]
            {
                {false, true,  false, true,  false},
                {true,  false, true,  true,  true},
                {false, true,  false, false, true},
                {true,  true,  false, false, true},
                {false, true,  true,  true,  false},
            };

            // Print the solution
            HamiltonianCycle(graph1);

            /* Let us create the following graph
               (0)--(1)--(2)
                |   / \   |
                |  /   \  |
                | /     \ |
               (3)       (4)    */
            var graph2 = new bool[,]
            {
                {false, true,  false, true,  false},
                {true,  false, true,  true,  true},
                {false, true,  false, false, true},
                {true,  true,  false, false, false},
                {false, true,  true,  false, false},
            };

            // Print the solution
            HamiltonianCycle(graph2);
        }

    }
}
