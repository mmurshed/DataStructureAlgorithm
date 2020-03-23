using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Graph.Barebbone
{
    public class Node
    {
        public int v;
        public Dictionary<int, Node> children;
        public Node(int n)
        {
            v = n;
            children = new Dictionary<int, Node>();
        }
    }

    public class Graph
    {
        public Dictionary<int, Node> adj;
        public Graph()
        {
            adj = new Dictionary<int, Node>();
        }

        public void AddVertex(int n)
        {
            if (!adj.ContainsKey(n))
                adj.Add(n, new Node(n));
        }

        public void AddEdge(int s, int e)
        {
            var sn = adj[s];
            var en = adj[e];
            sn.children.Add(e, en);
        }

    }
}
