using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class ListVertexVisitor<T> : IVisitor<IVertex<T>>
    {
        public List<IVertex<T>> VertexList { get; }

        public ListVertexVisitor()
        {
            VertexList = new List<IVertex<T>>();
        }

        public void PreVisit(IVertex<T> value)
        {
            VertexList.Add(value);
        }

        public void Visit(IVertex<T> value)
        {

        }

        public void PostVisit(IVertex<T> value)
        {
            
        }
    }
}
