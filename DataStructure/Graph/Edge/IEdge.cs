using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public interface IEdge<V, E> : IEquatable<IEdge<V, E>>
    {
        VertexPair<V> Pair { get; }
        IVertex<V> Start { get; }
        IVertex<V> End { get; }

        E Value { get; set; }

        IVertex<V> GetOtherVertex(IVertex<V> first);
    }
}
