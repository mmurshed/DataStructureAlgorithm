using System;
using System.Collections.Generic;

namespace Graph
{
    public interface IVertex2<V> : IEquatable<IVertex2<V>>
    {
        uint ID { get; set; }
        V Value { get; }
    }

}
