using System.Collections.Generic;
using DataStructure.Graph;

namespace Algorithm.Graph
{
    public class TopologicalSortBFS<V, E>
    {
        public LinkedList<IVertex<V>> Sort(IGraph<V, E> graph)
        {
            LinkedList<IVertex<V>> list = new LinkedList<IVertex<V>>();
            int[] predecessorCount = new int[graph.Size];
            foreach(var vertex in graph.Vertices)
            {
                foreach(var neighbour in graph.GetNeighbours(vertex))
                {
                    predecessorCount[neighbour.ID]++;
                }
            }

            Queue<IVertex<V>> queue = new Queue<IVertex<V>>();

            foreach (var vertex in graph.Vertices)
            {
                if(predecessorCount[vertex.ID] == 0)
                    queue.Enqueue(vertex);
            }

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                list.AddLast(vertex);

                foreach (var neighbour in graph.GetNeighbours(vertex))
                {
                    predecessorCount[neighbour.ID]--;
                    if(predecessorCount[neighbour.ID] == 0)
                        queue.Enqueue(neighbour);
                }
            }

            return list;
        }
    }
}
