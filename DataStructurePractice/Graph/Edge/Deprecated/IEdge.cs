﻿using System;
using System.Collections.Generic;

namespace Graph.Deprecated
{
    public interface IEdge<V, E>
    {
        IVertex<V> Start { get; }
        IVertex<V> End { get; }
        E Value { get; set; }
    }
}
