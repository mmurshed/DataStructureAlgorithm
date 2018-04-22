using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Graph
{
    public class DepthFirstEnumerator<V, E> : GraphEnumerator<V, E>
    {
        public DepthFirstEnumerator(IGraph<V, E> graph) : base(graph) { }

        protected override IEnumerable<IVertex<V>> Search(IVertex<V> root)
        {
            if (IsVisited(root))
                yield break;

            SetVisited(root);

            yield return root;

            foreach (var neighbor in graph.GetNeighbours(root).SelectMany(w => Search(w)))
            {
                yield return neighbor;
            }
        }
    }
}
