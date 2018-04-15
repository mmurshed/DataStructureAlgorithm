namespace Graph.Algorithms
{
    public interface IAStarHeuristic<V>
    {
        int Distance(IVertex2<V> start, IVertex2<V> end);
    }
}
