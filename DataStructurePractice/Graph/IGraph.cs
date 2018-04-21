﻿using System;
using System.Collections.Generic;

namespace Graph
{
    public interface IGraph<V, E>
    {
        IEnumerable<IVertex<V>> Vertices { get; }
        IEnumerable<IEdge<V, E>> Edges { get; }

        int Size { get; }

        // Create
        void AddVertex(IVertex<V> vertex);
        void AddEdge(IEdge<V, E> edge);

        // Read
        IVertex<V> GetVertexByID(uint id);
        IVertex<V> GetVertex(V value);
        IEnumerable<IVertex<V>> GetNeighbours(IVertex<V> vertex);

        bool HasEdge(IVertex<V> start, IVertex<V> end);
        IEdge<V, E> GetEdge(IVertex<V> start, IVertex<V> end);

        // Update

        // Delete
        void RemoveVertex(V value);
        void RemoveEdge(IVertex<V> start, IVertex<V> end);
    }
}
