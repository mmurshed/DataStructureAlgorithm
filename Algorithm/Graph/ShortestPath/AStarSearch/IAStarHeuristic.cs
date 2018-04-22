using DataStructure.Graph;

namespace Algorithm.Graph.ShortestPath
{
    public interface IAStarHeuristic<V>
    {
        int Distance(IVertex<V> start, IVertex<V> end);
    }
}
