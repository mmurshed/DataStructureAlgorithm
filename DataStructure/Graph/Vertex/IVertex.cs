using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public interface IVertex<V> : IEquatable<IVertex<V>>
    {
        uint ID { get; set; }
        V Value { get; }
    }

}
