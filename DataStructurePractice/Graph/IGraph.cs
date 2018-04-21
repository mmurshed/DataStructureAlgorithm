using System;
using System.Collections.Generic;

namespace Graph
{
    public interface IGraph<V, E>
    {
        IEnumerable<IVertex2<V>> Vertices { get; }
        IEnumerable<IEdge2<V, E>> Edges { get; }

        int Size { get; }

        void AddVertex(IVertex2<V> vertex);
        void AddEdge(IEdge2<V, E> edge);

        IVertex2<V> GetVertexByID(uint id);
        IVertex2<V> GetVertex(V value);
        IEnumerable<IVertex2<V>> GetNeighbours(IVertex2<V> vertex);

        bool HasEdge(IVertex2<V> start, IVertex2<V> end);
        IEdge2<V, E> GetEdge(IVertex2<V> start, IVertex2<V> end);
    }
}
