using DataStructure.Graph;

namespace DataStructure.NUnit.Graph.Builder
{
    public interface IGraphBuilder<V, E>
    {
        IGraph<V, E> Graph { get; }
    }
}
