using DataStructure.Graph;
using DataStructure.Queue;

namespace Algorithm.Graph
{
    /*
     * Sedgewick Book
    Prim’s algorithm
    Our first MST method, known as Prim’s algorithm, is to attach a new edge to a single growing tree at each step. Start with any vertex as a single-ver- tex tree; then add V􏰀1 edges to it, always taking next (coloring black) the minimum-

    Proposition L. Prim’s algorithm computes the MST of any connected edge-weighted graph.
    Proof: Immediate from Proposition K. The growing tree defines a cut with no black edges; the algorithm takes the crossing edge of minimal weight, so it is successively coloring edges black in accordance with the greedy algorithm.
         tree edge (thick black)
    minimum-weight
    crossing edge must be on MST
      Prim’s MST algorithm
    The one-sentence description of Prim’s algorithm just given
    leaves unanswered a key question: How do we (efficiently) find the crossing edge of minimal weight? Several methods have been proposed—we will discuss some of them after we have developed a full solution based on a particularly
    simple approach.
    Data structures. We implement Prim’s algorithm with the aid of a few simple and familiar data structures. In particular, we represent the vertices on the tree, the edges on the tree, and the crossing edges, as follows:
    ■ Vertices on the tree : We use a vertex-indexed boolean array marked[], where marked[v] is true if v is on the tree.
    ■ Edges on the tree : We use one of two data structures: a queue mst to collect MST edges or a vertex-indexed array edgeTo[] of Edge objects, where edgeTo[v] is the Edge that connects v to the tree.
    ■ Crossing edges : We use a MinPQ<Edge> priority queue that compares edges by weight (see page 610).
    These data structures allow us to directly answer the basic question “Which is the min- imal-weight crossing edge?”
    Maintaining the set of crossing edges. Each time that we add an edge to the tree, we also add a vertex to the tree. To maintain the set of crossing edges, we need to add to the priority queue all edges from that vertex to any non-tree vertex (using marked[] to identify such edges). But we must do more: any edge connecting the vertex just added to a tree vertex that is already on the priority queue now becomes ineligible (it is no longer a crossing edge because it connects two tree vertices). An eager implementation

    of Prim’s algorithm would remove such edges from the priority queue; we first consider a simpler lazy implementation of the algorithm where we leave such edges on the priority queue, deferring the eli- gibility test to when we remove them.
    */
    // Space O(e)
    // Time O(e*log(e))
    public class MinimalSpanningTreePrim2<V, E> : MinimalSpanningTree<V>
    {
        private bool[] componentOfMST;
        PriorityQueueDeprecated<IEdge<V, int>> queue;

        public MinimalSpanningTreePrim2(IGraph<V, int> graph, IVertex<V> source)
            : base(graph, source)
        {
            componentOfMST = new bool[graph.Size];
        }



        private void Init()
        {
            queue = new PriorityQueueDeprecated<IEdge<V, int>>((a, b) => a.Value - b.Value);

            for (int i = 0; i < graph.Size; i++)
            {
                componentOfMST[i] = false;
            }

            foreach (var v in graph.Vertices)
            {
                MST.AddVertex(v);
            }

            Visit(source);
        }

        // Prim's MST
        public override void GenerateMST()
        {
            Init();

            while (!queue.Empty)
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
                if (!componentOfMST[v.ID])
                    queue.Enqueue(graph.GetEdge(vertex, v));
            }
        }
    }
}
