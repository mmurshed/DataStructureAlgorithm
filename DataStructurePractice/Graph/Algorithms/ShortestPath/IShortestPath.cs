using System.Collections.Generic;

namespace Graph.Algorithms
{
    public interface IShortestPath<V>
    {
        void ShortestPath();
        LinkedList<IVertex2<V>> GetPath(IVertex2<V> u, IVertex2<V> v);
        int GetDistance(IVertex2<V> u, IVertex2<V> v);
    }
}
