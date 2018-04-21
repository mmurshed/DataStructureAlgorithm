using System;
using System.Collections.Generic;

namespace Graph.Deprecated
{
    public interface IGraph<V, E>
    {
        ICollection<IVertex<V>> Vertices { get; }
        int Size { get; }
        void AddVertex(IVertex<V> vertex);
        void AddEdge(IEdge<V, E> edge);

        IVertex<V> GetVertex(uint ID);
        bool HasEdge(IVertex<V> start, IVertex<V> end);
        IEdge<V, E> GetEdge(IVertex<V> start, IVertex<V> end);
    }
}
