using System;
using System.Collections.Generic;

namespace Graph
{
    public class BipartiteEdgeVisitor<V, E> : IVisitor<IEdge<V, E>>
    {
        public enum Color { Uncolored, White, Black };
        private Dictionary<IVertex<V>, Color> color;

        public bool IsBipartite { get; private set; }

        public BipartiteEdgeVisitor(IGraph<V, E> graph)
        {
            color = new Dictionary<IVertex<V>, Color>();
            foreach (var vertex in graph.Vertices)
                color.Add(vertex, Color.Uncolored);
            IsBipartite = true;
        }

        public void SetColor(IVertex<V> vertex, Color colorSet)
        {
            if (!color.ContainsKey(vertex))
                color.Add(vertex, colorSet);
            else
                color[vertex] = colorSet;
        }

        public void PreVisit(IEdge<V, E> value)
        {
        }

        public void Visit(IEdge<V, E> value)
        {
            if(color.ContainsKey(value.Start) && color.ContainsKey(value.End)
               && color[value.Start] == color[value.End])
            {
                IsBipartite = false;
            }
            color[value.End] = Complement(value.Start);
        }

        private Color Complement(IVertex<V> vertex)
        {
            if (color.ContainsKey(vertex) && color[vertex] == Color.White)
                return Color.Black;
            if (color.ContainsKey(vertex) && color[vertex] == Color.Black)
                return Color.White;
            return Color.Uncolored;
        }

        public void PostVisit(IEdge<V, E> value)
        {
            
        }
    }
}
