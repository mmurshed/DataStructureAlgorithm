using System;
using System.Collections.Generic;

namespace Graph
{
    public interface IEdge2<V, E> : IEquatable<IEdge2<V, E>>
    {
        VertexPair<V> Pair { get; }
        IVertex2<V> Start { get; }
        IVertex2<V> End { get; }

        E Value { get; set; }

        IVertex2<V> GetOtherVertex(IVertex2<V> first);
    }
}
