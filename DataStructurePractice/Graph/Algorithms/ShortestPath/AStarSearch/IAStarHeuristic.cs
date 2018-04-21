namespace Graph.Algorithms
{
    public interface IAStarHeuristic<V>
    {
        int Distance(IVertex<V> start, IVertex<V> end);
    }
}
