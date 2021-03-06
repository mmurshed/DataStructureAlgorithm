﻿using DataStructure.Graph;

namespace Algorithm.Graph
{
    // https://www.geeksforgeeks.org/greedy-algorithms-set-5-prims-minimum-spanning-tree-mst-2/
    /* 
     * We have discussed Kruskal’s algorithm for Minimum Spanning Tree.
     * Like Kruskal’s algorithm, Prim’s algorithm is also a Greedy algorithm. 
     * 
     * It starts with an empty spanning tree. The idea is to maintain two sets of 
vertices. The first set contains the vertices already included in the MST, 
the other set contains the vertices not yet included. At every step, it 
considers all the edges that connect the two sets, and picks the minimum 
weight edge from these edges. After picking the edge, it moves the other 
endpoint of the edge to the set containing MST.

A group of edges that connects two set of vertices in a graph is called cut in 
graph theory. So, at every step of Prim’s algorithm, we find a cut (of two sets,
one contains the vertices already included in MST and other contains rest of 
the verices), pick the minimum weight edge from the cut and include this 
vertex to MST Set (the set that contains already included vertices).

How does Prim’s Algorithm Work? The idea behind Prim’s algorithm is simple, 
a spanning tree means all vertices must be connected. So the two disjoint 
subsets (discussed above) of vertices must be connected to make a Spanning 
Tree. And they must be connected with the minimum weight edge to make it a 
Minimum Spanning Tree.

Algorithm
1) Create a set mstSet that keeps track of vertices already included in MST.

2) Assign a key value to all vertices in the input graph. Initialize all key
values as INFINITE. Assign key value as 0 for the first vertex so that it is 
picked first.

3) While mstSet doesn’t include all vertices
    a) Pick a vertex u which is not there in mstSet and has minimum key value.
    b) Include u to mstSet.
    c) Update key value of all adjacent vertices of u. To update the key values,
    iterate through all adjacent vertices. For every adjacent vertex v, if 
    weight of edge u-v is less than the previous key value of v, update the key 
    value as weight of u-v

The idea of using key values is to pick the minimum weight edge from cut. 
The key values are used only for vertices which are not yet included in MST, 
the key value for these vertices indicate the minimum weight edges connecting
them to the set of vertices included in MST.

Let us understand with the following example:
      ①--8--②--7--③
   /|     |\     |\
  4 |     2 \    | 9
 /  |    ⑧    \   |  \
⓪  11   / |   4  14  ④
 \  |  7  6    \ |   /
  8 | /   |     \|  /
   \⑦--1--⑥--2--⑤/
   
The set mstSet is initially empty and keys assigned to vertices are 
{0, INF, INF, INF, INF, INF, INF, INF} where INF indicates infinite. 
Now pick the vertex with minimum key value. The vertex 0 is picked, include it 
in mstSet. So mstSet becomes {0}. After including to mstSet, update key values 
of adjacent vertices. Adjacent vertices of 0 are 1 and 7. The key values of 1 
and 7 are updated as 4 and 8. Following subgraph shows vertices and their key 
values, only the vertices with finite key values are shown. The vertices 
included in MST are shown in green color.

    4
      ①
   /
  /
0/  
⓪  
 \ 
  \
   \⓻
    8

Pick the vertex with minimum key value and not already included in MST 
(not in mstSET). The vertex 1 is picked and added to mstSet. So mstSet now 
becomes {0, 1}. Update the key values of adjacent vertices of 1. The key value 
of vertex 2 becomes 8.

    4    8
      ①----⓶
   /
  /
0/  
⓪  
 \ 
  \
   \⓻
    8


Pick the vertex with minimum key value and not already included in MST 
(not in mstSET). We can either pick vertex 7 or vertex 2, let vertex 7 is 
picked. So mstSet now becomes {0, 1, 7}. Update the key values of adjacent 
vertices of 7. The key value of vertex 6 and 8 becomes finite (7 and 1 
respectively).

    4    8
      ①----⓶
   /
  /
0/       7
⓪             ⓼
 \      /
  \    /
   \⓻/----⓺ 
    8      1


Pick the vertex with minimum key value and not already included in MST 
(not in mstSET). Vertex 6 is picked. So mstSet now becomes {0, 1, 7, 6}.
Update the key values of adjacent vertices of 6. The key value of vertex
5 and 8 are updated.

    4    8
      ①----⓶
   /
  /
0/         6
⓪                ⓼
 \         |
  \        |
   \⓻-----⑥-----⓹
    8      1      2


We repeat the above steps until mstSet includes all vertices of given graph.
Finally, we get the following graph.

    4      4      7
      ①          ②------③
   /       |\       \
  /        | \       \
0/         |  \       \
⓪                ⑧     \      ④
 \         2    \     9
  \              \
   \⓻-----⑥-----⑤
    8      1      2

How to implement the above algorithm?
We use a boolean array mstSet[] to represent the set of vertices included in MST. If a value mstSet[v] is true, then vertex v is included in MST, otherwise not. Array key[] is used to store key values of all vertices. Another array parent[] to store indexes of parent nodes in MST. The parent array is the output array which is used to show the constructed MST.
    */
    public class MinimalSpanningTreePrim<V> : MinimalSpanningTree<V>
    {
        private bool[] componentOfMST;
        private int[] distance;
        private IVertex<V>[] neighbor;

        public MinimalSpanningTreePrim(IGraph<V, int> graph, IVertex<V> source)
            : base(graph, source)
        {
            componentOfMST = new bool[graph.Size];
            distance = new int[graph.Size];
            neighbor = new IVertex<V>[graph.Size];
        }

        private int FindMinimumDistance()
        {
            int min = INFINITY;
            int min_index = -1;

            for (int v = 0; v < distance.Length; v++)
            {
                if (!componentOfMST[v] && distance[v] <= min)
                {
                    min = distance[v];
                    min_index = v;
                }
            }

            return min_index;
        }


        private void Init()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                componentOfMST[i] = false;
                neighbor[i] = source;
                distance[i] = INFINITY;
            }

            foreach(var v in graph.GetNeighbours(source))
            {
                distance[v.ID] = graph.GetEdge(source, v).Value;
            }

            foreach(var v in graph.Vertices)
            {
                MST.AddVertex(v);
            }

            componentOfMST[source.ID] = true;
        }

        // Prim's MST
        public override void GenerateMST()
        {
            Init();

            for (int i = 0; i < graph.Size; i++)
            {
                int v = FindMinimumDistance();
                var newDistance = distance[v];
                if (newDistance < INFINITY)
                {
                    componentOfMST[v] = true;

                    var v1 = graph.GetVertexByID((uint)v);
                    var v2 = neighbor[v];
                    var edge = new Edge<V, int>(v1, v2);
                    MST.AddEdge(edge);

                    foreach (var w in graph.GetNeighbours(v1))
                    {
                        var e2 = graph.GetEdge(v1, w);
                        if (!componentOfMST[w.ID] && e2.Value < distance[w.ID])
                        {
                            distance[w.ID] = e2.Value;
                            neighbor[w.ID] = v1;
                        }
                    }
                }
                else break;
            }
        }
    }
}
