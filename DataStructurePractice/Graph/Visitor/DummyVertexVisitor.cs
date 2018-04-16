using System;

namespace Graph
{
    class DummyVertexVisitor<T> : IVisitor<IVertex<T>>
    {
        public void PreVisit(IVertex<T> value)
        {
        }

        public void Visit(IVertex<T> value)
        {
        }

        public void PostVisit(IVertex<T> value)
        {
            
        }
    }
}
