using System;
using System.Collections.Generic;

namespace Graph.Algorithms
{
    public class DFSTopoSortVisitor<V> : IVisitor<IVertex<V>>
    {
        public LinkedList<IVertex<V>> TopologicalSortedList { get; set; }
        public DFSTopoSortVisitor()
        {
            TopologicalSortedList = new LinkedList<IVertex<V>>();
        }
        public void PreVisit(IVertex<V> value)
        {
        }
        public void Visit(IVertex<V> value)
        {
        }
        public void PostVisit(IVertex<V> value)
        {
            TopologicalSortedList.AddFirst(value);
        }
    }
}
