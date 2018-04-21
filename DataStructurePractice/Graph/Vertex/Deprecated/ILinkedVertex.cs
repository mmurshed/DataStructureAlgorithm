using System;
using System.Collections.Generic;

namespace Graph.Deprecated
{
    public interface ILinkedVertex<V, E> : IVertex<V>
    {
        ICollection<IEdge<V, E>> Edges { get; }
    }

}
