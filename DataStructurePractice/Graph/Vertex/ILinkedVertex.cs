using System;
using System.Collections.Generic;

namespace Graph
{
    public interface ILinkedVertex2<V, E>
    {
        V Value { get; }
        IDictionary<ILinkedVertex2<V, E>, IEdge<V, E>> Neighbours { get; }
        int NeighbourCount { get; }

        void Add(ILinkedVertex2<V, E> vertex, IEdge<V, E> edge);
        void Remove(ILinkedVertex2<V, E> vertex);
    }

}
