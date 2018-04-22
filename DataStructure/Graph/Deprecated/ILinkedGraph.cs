using System;
using System.Collections.Generic;

namespace DataStructure.Graph.Deprecated
{
    public interface ILinkedGraph<V, E>
    {
        ICollection<ILinkedVertex<V, E>> Vertices { get; }
        int Size { get; }
        ICollection<IEdge<V, E>> Edges { get; }
        void AddVertex(ILinkedVertex<V, E> vertex);
        void AddEdge(IEdge<V, E> edge);
    }
}
