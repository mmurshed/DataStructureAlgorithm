using System;

namespace Graph
{
    public interface IGraphBuilder2<V, E>
    {
        IGraph2<V, E> Graph { get; }
    }
}
