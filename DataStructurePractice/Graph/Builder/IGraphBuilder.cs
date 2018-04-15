using System;

namespace Graph
{
    public interface IGraphBuilder<V, E>
    {
        IGraph<V, E> Graph { get; }
    }
}
