using System;
using System.Collections.Generic;

namespace Graph
{
    public interface ILinkedVertex<V, E>
    {
        V Value { get; }
        IDictionary<ILinkedVertex<V, E>, IEdge<V, E>> Neighbours { get; }
        int NeighbourCount { get; }

        void Add(ILinkedVertex<V, E> vertex, IEdge<V, E> edge);
        void Remove(ILinkedVertex<V, E> vertex);
    }

}
