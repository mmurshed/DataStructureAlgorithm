using DataStructure.Graph;
using DataStructure.Queue;

namespace Algorithm.Graph
{
/*
 * Sedgewick Book
To improve the LazyPrimMST, we might try to delete ineligible edges from the priority queue, so that the priority queue contains only the crossing edges between tree vertices and non-tree vertices. But we can elimi- nate even more edges. The key is to note that our only interest is in the minimal edge
connecting v to the tree
v
brings w closer to the tree
from each non-tree vertex to a tree vertex. When we add a vertex v to the tree, the only possible change with respect to each non- tree vertex w is that adding v brings w closer than before to the tree. In short, we do not need to keep on the priority queue all of the edges from w to tree vertices—we just need to keep track
     w of the minimum-weight edge and check whether the addition of v to the tree necessitates that we update that minimum (be- cause of an edge v-w that has lower weight), which we can do as we process each edge in v’s adjacency list. In other words, we
  maintain on the priority queue just one edge for each non-tree vertex w: the shortest edge that connects it to the tree. Any longer edge connecting w to the tree will become ineligible at some point, so there is no need to keep it on the priority queue.
PrimMST (Algorithm 4.7 on page 622) implements Prim’s algorithm using our in- dex priority queue data type from Section 2.4 (see page 320). It replaces the data structures marked[] and mst[] in LazyPrimMST by two vertex-indexed arrays edgeTo[] and distTo[], which have the following properties:
■ If v is not on the tree but has at least one edge connecting it to the tree, then edgeTo[v] is the shortest edge connecting v to the tree, and distTo[v] is the weight of that edge.
■ All such vertices v are maintained on the index priority queue, as an index v as- sociated with the weight of edgeTo[v].
The key implications of these properties is that the minimum key on the priority queue is the weight of the minimal-weight crossing edge, and its associated vertex v is the next to add to the tree. The marked[] array is not needed, since the condition !marked[w] is equivalent to the condition that distTo[w] is infinite (and that edgeTo[w] is null). To maintain the data structures, PrimMST takes an edge v from the priority queue, then checks each edge v-w on its adjacency list. If w is marked, the edge is ineligible; if it is not on the priority queue or its weight is lower than the current best-known edgeTo[w], the code updates the data structures to establish v-w as the best-known way to connect v to the tree.
The figure on the facing page is a trace of PrimMST for our small sample graph tinyEWG.txt. The contents of the edgeTo[] and distTo[] arrays are depicted after each vertex is added to the MST, color-coded to depict the MST vertices (index in black), the non-MST vertices (index in gray), the MST edges (in black), and the priority-queue
 
index/value pairs (in red). In the drawings, the shortest edge connecting each non-MST vertex to an MST vertex is drawn in red. The algorithm adds edges to the MST in the same order as the lazy version; the difference is in the priority-queue operations.
*/
    // Space O(v)
    // Time O(e*log(e))
    public class MinimalSpanningTreePrim3<V, E> : MinimalSpanningTree<V>
    {
        private bool[] componentOfMST;
        PriorityQueue<IEdge<V, int>> queue;

        private IEdge<V, int>[] edgeTo;
        private int[] distTo;

        public MinimalSpanningTreePrim3(IGraph<V, int> graph, IVertex<V> source)
            : base(graph, source)
        {
            componentOfMST = new bool[graph.Size];
            edgeTo = new IEdge<V, int>[graph.Size];
            distTo = new int[graph.Size];
        }



        private void Init()
        {
            queue = new PriorityQueue<IEdge<V, int>>();

            for (int i = 0; i < graph.Size; i++)
            {
                componentOfMST[i] = false;
                distTo[i] = INFINITY;
            }

            foreach(var v in graph.Vertices)
            {
                MST.AddVertex(v);
            }

            Visit(source);
        }

        // Prim's MST
        public override void GenerateMST()
        {
            Init();

            while(!queue.Empty)
            {
                var e = queue.Dequeue();

                var v = e.Start;
                var w = e.End;
                if (componentOfMST[v.ID] && componentOfMST[w.ID])
                    continue;
                MST.AddEdge(e);
                Visit(v);
                Visit(w);
            }
        }

        private void Visit(IVertex<V> vertex)
        {
            if (componentOfMST[vertex.ID])
                return;
            componentOfMST[vertex.ID] = true;
            foreach (var v in graph.GetNeighbours(vertex))
            {
                if (componentOfMST[v.ID])
                    continue;
                var e = graph.GetEdge(vertex, v);
                if (e.Value < distTo[v.ID])
                {
                    edgeTo[v.ID] = e;
                    distTo[v.ID] = e.Value;
                    // TODO: add code for update
                    queue.Enqueue(e);
                }
            }
        }
    }
}
