using System;

namespace Graph.Algorithms
{
    public class AStarManhattanHeuristic<V> : IAStarHeuristic<V>
    {
        public int Distance(IVertex<V> start, IVertex<V> end)
        {
            return Math.Abs((int)start.ID - (int)end.ID);
        }
    }
}
