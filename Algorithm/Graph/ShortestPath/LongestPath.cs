using System;
namespace Algorithm.Graph.ShortestPath
{
    /*
PropositionT. Wecansolvethelongest-pathsprobleminedge-weightedDAGsin time proportional to E + V.
Proof: Given a longest-paths problem, create a copy of the given edge-weighted DAG that is identical to the original, except that all edge weights are negated. Then the shortest path in this copy is the longest path in the original. To transform the solution of the shortest-paths problem to a solution of the longest-paths problem, negate the weights in the solution. The running time follows immediately from Proposition S.
    */
    public class LongestPath
    {
        public LongestPath()
        {
        }
    }
}
