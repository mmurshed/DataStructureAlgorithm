using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Facebook
{
    public class AlienDictionary
    {
        private class Node
        {
            public char v;
            public Dictionary<char, Node> children;
            public Node(char ch)
            {
                v = ch;
                children = new Dictionary<char, Node>();
            }
        }

        private class Graph
        {
            public Dictionary<char, Node> adj;
            public Graph()
            {
                adj = new Dictionary<char, Node>();
            }

            public void AddNode(char a)
            {
                if (!adj.ContainsKey(a))
                    adj.Add(a, new Node(a));
            }

            public void InsertEdgeOrdered(char a, char b)
            {
                var an = adj[a];
                var bn = adj[b];

                if (!an.children.ContainsKey(b))
                {
                    var list = TopologicalSorter.Sort(an);
                    foreach (var c in list)
                    {
                        if (c == b)
                            return;
                    }
                    an.children.Add(b, bn);
                }
            }


        }

        private class TopologicalSorter
        {
            public static string SortToString(Graph g)
            {
                LinkedList<char> list = null;
                try
                {
                    list = Sort(g);
                }
                catch
                {
                    return string.Empty;
                }

                if (list == null || list.Count == 0)
                    return string.Empty;

                return new string(list.ToArray());
            }


            public static LinkedList<char> Sort(Graph g)
            {
                var list = new LinkedList<char>();
                var visited = new HashSet<char>();

                foreach (var node in g.adj)
                {
                    Sort(node.Value, list, visited);
                }

                return list;
            }

            public static LinkedList<char> Sort(Node node, LinkedList<char> list = null, HashSet<char> visited = null)
            {
                if (list == null)
                    list = new LinkedList<char>();
                if (visited == null)
                    visited = new HashSet<char>();
                var recursed = new HashSet<char>();

                DFS(node, list, visited, recursed);

                return list;
            }


            public static void DFS(Node node, LinkedList<char> list, HashSet<char> visited, HashSet<char> recursed)
            {
                var v = node.v;
                if (recursed.Contains(v))
                    throw new Exception();
                if (visited.Contains(v))
                    return;
                visited.Add(v);
                recursed.Add(v);

                foreach (var c in node.children)
                {
                    DFS(c.Value, list, visited, recursed);
                }


                list.AddFirst(node.v);
                recursed.Remove(v);
            }

        }

        public string AlienOrder(string[] words)
        {

            int len = 0;
            for (int i = 0; i < words.Length; i++)
                len = Math.Max(len, words[i].Length);


            var g = new Graph();

            for (int i = 0; i < words.Length; i++)
                for (int l = 0; l < words[i].Length; l++)
                    g.AddNode(words[i][l]);

            var skip = new bool[words.Length];

            for (int l = 0; l < len; l++)
            {
                for (int i = 0; i < words.Length - 1; i++)
                {
                    if (skip[i + 1])
                        continue;
                    if (l >= words[i].Length)
                        continue;
                    if (words[i][l] == words[i + 1][l])
                        continue;
                    try
                    {
                        g.InsertEdgeOrdered(words[i][l], words[i + 1][l]);
                    }
                    catch
                    {
                        return string.Empty;
                    }
                    skip[i + 1] = true;
                }
            }

            return TopologicalSorter.SortToString(g);

        }
    }
}