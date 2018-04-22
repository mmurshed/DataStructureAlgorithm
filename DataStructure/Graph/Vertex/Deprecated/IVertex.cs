using System;
using System.Collections.Generic;

namespace DataStructure.Graph.Deprecated
{
    public interface IVertex<V>
    {
        uint ID { get; set; }
        V Value { get; }
        ICollection<IVertex<V>> Neighbours { get; }
        int NeighbourCount { get; }

        void Add(IVertex<V> vertex);
        void Remove(IVertex<V> vertex);
    }

}
