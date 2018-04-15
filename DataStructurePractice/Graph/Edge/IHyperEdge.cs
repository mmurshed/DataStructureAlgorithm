using System;
using System.Collections.Generic;

namespace Graph
{
    public interface IHyperEdge<V, E>
    {
        ICollection<IVertex<V>> Vertices { get; }
        int VerticesCount { get; }
        E Value { get; set; }

        void Add(IVertex<V> vertex);
        void Add(IEnumerable<IVertex<V>> vertices);
    }
}
