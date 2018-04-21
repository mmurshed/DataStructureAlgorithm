using System;
using System.Collections.Generic;

namespace Graph
{
    public class DepthFirstEnumeratorStack<V, E> : GraphEnumerator<V, E>
    {
        public DepthFirstEnumeratorStack(IGraph<V, E> graph) : base(graph) { }

        protected override IEnumerable<IVertex<V>> Search(IVertex<V> root)
        {
            if (IsVisited(root))
                yield break;
           
            var stack = new Stack<IVertex<V>>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (!IsVisited(vertex))
                {
                    SetVisited(vertex);
                    yield return vertex;

                    foreach (var neighbour in graph.GetNeighbours(vertex))
                    {
                        stack.Push(neighbour);
                    }
                }
            }
        }
    }
}
