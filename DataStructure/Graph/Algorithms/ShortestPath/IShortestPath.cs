using System.Collections.Generic;

namespace DataStructure.Graph.Algorithms
{
    public interface IShortestPath<V>
    {
        void ShortestPath();
        LinkedList<IVertex<V>> GetPath(IVertex<V> u, IVertex<V> v);
        int GetDistance(IVertex<V> u, IVertex<V> v);
    }
}
