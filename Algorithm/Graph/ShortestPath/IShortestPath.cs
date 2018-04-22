﻿using System.Collections.Generic;
using DataStructure.Graph;

namespace Algorithm.Graph.ShortestPath
{
    public interface IShortestPath<V>
    {
        void ShortestPath();
        LinkedList<IVertex<V>> GetPath(IVertex<V> u, IVertex<V> v);
        int GetDistance(IVertex<V> u, IVertex<V> v);
    }
}
