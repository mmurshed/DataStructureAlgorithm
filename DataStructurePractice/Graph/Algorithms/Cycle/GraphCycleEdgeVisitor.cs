using System;
using System.Collections.Generic;

namespace Graph
{
    public class GraphCycleEdgeVisitor<V, E> : IVisitor<IEdge<V, E>>
    {
        private Dictionary<IVertex<V>, IVertex<V>> parent;
        private readonly GraphSearch<V, E> Search;

        public bool HasCycle { get; private set; }

        public GraphCycleEdgeVisitor(GraphSearch<V, E> search)
        {
            parent = new Dictionary<IVertex<V>, IVertex<V>>();
            Search = search;

            HasCycle = false;
        }

        public void PreVisit(IEdge<V, E> value)
        {
        }

        public void Visit(IEdge<V, E> value)
        {
            if(Search.IsVisited(value.Start) && parent.ContainsKey(value.Start) && parent[value.Start].Equals(value.End))
            {
                // Back edge found
                HasCycle = true;
            }

            if( !parent.ContainsKey(value.Start) )
            {
                parent.Add(value.Start, value.End);
            }
        }

        public void PostVisit(IEdge<V, E> value)
        {
            
        }
    }
}
