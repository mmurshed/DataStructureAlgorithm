using System;

namespace Graph.Algorithms
{
    public class AStarManhattanHeuristic<V> : IAStarHeuristic<V>
    {
        public int Distance(IVertex2<V> start, IVertex2<V> end)
        {
            return Math.Abs((int)start.ID - (int)end.ID);
        }
    }
}
