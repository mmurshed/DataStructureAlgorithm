﻿using System;

namespace DataStructure.Graph
{
    public class DummyEdgeVisitor<V, E> : IVisitor<IEdge<V, E>>
    {
        public void PreVisit(IEdge<V, E> value)
        {
        }

        public void Visit(IEdge<V, E> value)
        {
        }

        public void PostVisit(IEdge<V, E> value)
        {
            
        }
    }
}
