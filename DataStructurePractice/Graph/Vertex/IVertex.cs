using System;
using System.Collections.Generic;

namespace Graph
{
    public interface IVertex<V> : IEquatable<IVertex<V>>
    {
        uint ID { get; set; }
        V Value { get; }
    }

}
