using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class DepthFirstEnumerator<V, E> : GraphEnumerator<V, E>
    {
        public DepthFirstEnumerator(IGraph2<V, E> graph) : base(graph) { }

        protected override IEnumerable<IVertex2<V>> Search(IVertex2<V> root)
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
