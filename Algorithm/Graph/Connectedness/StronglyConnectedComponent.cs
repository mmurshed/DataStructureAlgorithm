using System;
using System.Collections.Generic;

namespace Algorithm.Graph.Connectedness
{
    /*
     * Sedgewick Book
Strong connectivity in digraphs We have been careful to maintain a distinction between reachability in digraphs and connectivity in undirected graphs. In an undirect- ed graph, two vertices v and w are connected if there is a path connecting them—we can use that path to get from v to w or to get from w to v. In a digraph, by contrast, a vertex w is reachable from a vertex v if there is a directed path from v to w, but there may or may not be a directed path back to v from w. To complete our study of digraphs, we consider the
   
Definition. Two vertices v and w are strongly connected if they are mutually reachable: that is, if there is a directed path from v to w and a directed path from w to v. A digraph is strongly connected if all its vertices are strongly connected to one another.
                                                   Strongly connected digraphs
natural analog of connectivity in undirected graphs.
Several examples of strongly connected graphs are given in the figure at left. As you can see from the examples, cycles play an important role in understanding strong connectivity. Indeed, recalling that a general directed cycle is a directed cycle that may have repeated vertices, it is easy to see that two vertices are strongly connected if and only if there exists a general directed cycle that contains them both. (Proof : compose the paths from v to w and from w to v.)
Strongcomponents. Likeconnectivityinundirectedgraphs,strongconnectivityindi- graphs is an equivalence relation on the set of vertices, as it has the following properties:
■ Reflexive : Every vertex v is strongly connected to itself.
■ Symmetric : If v is strongly connected to w, then w is strongly connected to v.
■ Transitive : If v is strongly connected to w and w is strongly connected to x, then v
is also strongly connected to x.
As an equivalence relation, strong connectivity partitions the vertices into equivalence clasees. The equivalence classes are maximal subsets
of vertices that are strongly connected to one anoth-
er, with each vertex in exactly one subset. We refer
to these subsets as strongly connected components,
or strong components for short. Our sample digraph
tinyDG.txt has five strong components, as shown
in the diagram at right. A digraph with V vertices
has between 1 and V strong components—a strongly
connected digraph has 1 strong component and a DAG has V strong components. Note that the strong components are defined in terms of the vertices, not the edges. Some edges connect two vertices in the same strong component; some other edges con- nect vertices in different strong components. The latter are not found on any directed cycle. Just as identifying connected components is typically important in processing undirected graphs, identifying strong components is typically important in processing digraphs.
Examples of applications. Strong connectivity is a useful abstraction in understand- ing the structure of a digraph, highlighting inter-
related sets of vertices (strong components). For
example, strong components can help textbook
authors decide which topics should be grouped to-
gether and software developers decide how to orga-
nize program modules. The figure below shows an
example from ecology. It illustrates a digraph that
models the food web connecting living organisms,
where vertices represent species and an edge from
one vertex to another indicates that an organism of
the species indicated by the point from vertex con-
sumes organisms of the species indicated by the

point to vertex for food. Scientific studies on such digraphs (with carefully chosen sets of species and carefully documented relationships) play an important role in helping ecologists answer basic questions about ecological systems. Strong components in such
egret
Typical strong-component applications
digraphs can help ecologists understand en- ergy flow in the food web. The figure on page 591 shows a digraph model of web content, where vertices represent pages and edges rep- resent hyperlinks from one page to another. Strong components in such a digraph can help network engineers partition the huge number of pages on the web into more manageable siz- es for processing. Further properties of these applications and other examples are addressed in the exercises and on the booksite.

Kosaraju’salgorithm. WesawinCC(Algorithm4.3onpage544)thatcomputingcon- nected components in undirected graphs is a simple application of depth-first search. How can we efficiently compute strong components in digraphs? Remarkably, the im- plementation KosarajuSCC on the facing page does the job with just a few lines of code added to CC, as follows:
■ Given a digraph G, use DepthFirstOrder to compute the reverse postorder of its reverse, G R.
■ Run standard DFS on G, but consider the unmarked vertices in the order just computed instead of the standard numerical order.
■ All vertices reached on a call to the recursive dfs() from the constructor are in a strong component (!), so identify them as in CC.
    */
    public class StronglyConnectedComponent
    {
        bool[] visited;
        int[] id; // componet id
        int count;

        bool addtoStack;
        Stack<DataStructure.Graph.Simple2.Vertex> stack;

        public StronglyConnectedComponent(DataStructure.Graph.Simple2.Graph g)
        {
            visited = new bool[g.Vertices.Count];
            id = new int[g.Vertices.Count];
            stack = new Stack<DataStructure.Graph.Simple2.Vertex>();
            count = 0;
            addtoStack = true;

            var r = ReverseGraph.GetReverse(g);

            foreach (var v in r.Vertices)
                DFS(v);

            addtoStack = false;
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            foreach (var v in stack)
            {
                count++;
                DFS(g.Vertices[v.Value]);
            }
        }

        private void PreVisit(DataStructure.Graph.Simple2.Vertex v)
        {
            visited[v.Value] = true;
            id[v.Value] = count;
        }

        private void PostVisit(DataStructure.Graph.Simple2.Vertex v)
        {
            if(addtoStack)
                stack.Push(v);
        }

        private void DFS(DataStructure.Graph.Simple2.Vertex v)
        {
            if (visited[v.Value])
                return;
            PreVisit(v);
            foreach (var w in v.Neighbours)
                DFS(w);
        }
    }
}
