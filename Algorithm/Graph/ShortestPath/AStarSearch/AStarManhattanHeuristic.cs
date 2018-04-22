using System;
using DataStructure.Graph;

namespace Algorithm.Graph.ShortestPath
{
    public class AStarManhattanHeuristic<V> : IAStarHeuristic<V>
    {
        public int Distance(IVertex<V> start, IVertex<V> end)
        {
            return Math.Abs((int)start.ID - (int)end.ID);
        }
    }
}
