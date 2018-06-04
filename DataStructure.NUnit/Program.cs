using System;
using System.Linq;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main1(string[] args)
        {
            //LinkedList<int> list = new LinkedList<int>();
            //list.Add(10);
            //list.Add(20);
            //list.Add(30);
            //list.Add(40);
            //PrintList(list);


            //testGraph.Build();
            //// Check to see that all neighbors are properly set up
            //foreach (var vertex in testGraph.Graph.Vertices)
            //{
            //    Console.WriteLine(vertex.Value.ToString());
            //}

            //Console.WriteLine();

            //var visitor = new Graph.ConsoleWriterVisitor<string>();
            //var visitorEdge = new Graph.DummyEdgeVisitor<string, int>();

            // var graphSearch = new Graph.DepthFirstSearchStack<string, int>();

            //graphSearch.Search(testGraph.Graph, visitor, visitorEdge);

            //Console.WriteLine();

            //var graphSearch = new Graph.BreadthFirstSearch<string, int>();

            //graphSearch.Search(testGraph.Graph, visitor, visitorEdge);

            //Console.WriteLine();
            //Console.WriteLine();

            //var genum = new Graph.DepthFirstEnumeratorStack<string, int>(testGraph.Graph);

            //while(genum.MoveNext())
            //{
            //    Console.WriteLine(genum.Current.Value);
            //}

            //Console.WriteLine();

            //var genum = new Graph.BreadthFirstEnumerator<string, int>(testGraph.Graph);

            //while(genum.MoveNext())
            //{
            //    Console.WriteLine(genum.Current.Value);
            //}

            //var topoGraphBuilder = new Graph.TopoGraphListBuilder();
            //topoGraphBuilder.Build();
            //var topS = new Graph.Algorithms.TopologicalSortBFS<int, int>();
            //var sort = topS.Sort(topoGraphBuilder.Graph);
            //foreach(var x in sort)
            //{
            //    Console.WriteLine(x.ID);
            //}

            //PriorityQueue.PriorityQueue<int> pq = new PriorityQueue.PriorityQueue<int>(new PriorityQueue.MaxComparer<int>());

            //pq.Insert(10);
            //pq.Insert(5);
            //pq.Insert(17);
            //pq.Insert(12);

            //while(pq.Count > 0)
            //{
            //    Console.WriteLine(pq.Extract());
            //}

            //var graphBuilder = new ShortestPathGraphMatrixBuilder();
            //graphBuilder.Build();
            //var source = new Vertex<int>(0, 0);
            //var target = new Vertex<int>(4, 4);
            //var algo = new Algorithms.SingleSourceShortestPathPQ<int>(graphBuilder.Graph, source);
            //algo.ShortestPath();
            //var dist = algo.Distance;
            //var path = algo.GetPath(source, target);
            //int i = 0;
            //foreach(var x in path)
            //{
            //    Console.WriteLine($"{i} Distance: {x}");
            //    i++;
            //}

            //foreach(var v in graphBuilder.Graph.Vertices)
            //{
            //    int d = algo.GetDistance(source, v);
            //    Console.WriteLine($"From {source.ID} to {v.ID} distance {d}.");
            //}

            //var graphBuilder = new ShortestPathGraphListBuilder();
            //graphBuilder.Build();
            //var source = new Vertex2<int>(0, 0);
            //var target = new Vertex2<int>(3, 3);
            //var algo = new Algorithms.SingleSourceShortestPathPQ<int>(graphBuilder.Graph, source);
            //algo.ShortestPath();

            //var path = algo.GetPath(source, target);
            //int i = 0;
            //foreach (var x in path)
            //{ 
            //    Console.WriteLine($"{i} Distance: {x}");
            //    i++;
            //}

            //foreach (var v in graphBuilder.Graph.Vertices)
            //{
            //    int d = algo.GetDistance(source, v);
            //    Console.WriteLine($"From {source.ID} to {v.ID} distance {d}.");
            //}

            //var graphBuilder = new MSTGraphListBuilder();
            //graphBuilder.Build();
            //var source = new Vertex2<int>(0, 0);
            //var target = new Vertex2<int>(3, 3);
            //var algo = new MinimalSpanningTreePrim<int>(graphBuilder.Graph, source);
            //algo.GenerateMST();

            //var genum = new BreadthFirstEnumerator<int, int>(graphBuilder.Graph);

            //while(genum.MoveNext())
            //{
            //    Console.WriteLine(genum.Current.Value);
            //}

            // Let the given dictionary be following
            //var dictionary = new[] { "GEEKS", "FOR", "QUIZ", "GEE" };
            //var bog = new Boggle(dictionary);

            //var boggle = new[,]
            //{
            //    {'G','I','Z'},
            //    {'U','E','K'},
            //    {'Q','S','E'}
            //};

            //var words = bog.FindWords(boggle);
            //foreach (var word in words)
            //Console.WriteLine(word);

            //RadixTree rd = new RadixTree();
            //rd.Insert("cat");
            //rd.Insert("badden");
            //rd.Insert("ban");
            //rd.Insert("badded");
            //rd.Insert("ba");

            //var node = rd.Find("badded");
            //node = rd.Find("can");

            // Let the given dictionary be following
            //var dictionary = new[] { "GEEKS", "FOR", "QUIZ", "GEE" };
            //var bog = new BoggleRadix(dictionary);

            //var boggle = new[,]
            //{
            //    {'G','I','Z'},
            //    {'U','E','K'},
            //    {'Q','S','E'}
            //};

            //var words = bog.FindWords(boggle);
            //foreach (var word in words)
            //Console.WriteLine(word);

            //int[] data = new int[] { 1, 3, 5, 7, 9, 11};
            //var tree = new SegmentTree<int>(data, (a, b) => a + b);
            //var r = tree.Find(2, 5);
            //Console.WriteLine(r);
            //tree.Update(3, 10);
            //r = tree.Find(2, 5);
            //Console.WriteLine(r);


            //Tree.HuffmanTree ht = new HuffmanTree(string.Empty);
            //ht.Build(line.ToCharArray(), freq);
            //var list = ht.GetCode();
            //foreach(var x in list)
            //Console.WriteLine($"{x.Code}: {x.HuffmanCode}");

            //int[] data = {5, 10, 40, 30, 28};
            //var c = new CartesianTree<int>();
            //c.BuildLinear(data);
            //var inorder = c.GetInOrderEnumerator();
            //foreach(var x in inorder)
            //{
            //    Console.Write($"{x} ");
            //}

            //var arr = "test".ToCharArray();
            //var cs = new Sorting.CountingSort(26);
            //cs.Sort(arr);
            //Console.WriteLine(arr);

            //var arr = new []{ 768, 5, 10, 24 };
            //// var rs = new Sorting.RadixSort();
            //var rs = new Sorting.QuickSort<int>();
            //rs.Sort(arr);
            //foreach (var x in arr)
            //Console.WriteLine(x);


            // var cache = new Miscellaneous.LFUCache(0 /* capacity */ );

            //cache.Put(1, 1);
            //cache.Put(2, 2);
            //Console.WriteLine(cache.Get(1));       // returns 1
            //cache.Put(3, 3);    // evicts key 2
            //Console.WriteLine(cache.Get(2));       // returns -1 (not found)
            //Console.WriteLine(cache.Get(3));       // returns 3.
            //cache.Put(4, 4);    // evicts key 1.
            //Console.WriteLine(cache.Get(1));       // returns -1 (not found)
            //Console.WriteLine(cache.Get(3));       // returns 3
            //Console.WriteLine(cache.Get(4));       // returns 4

            //cache.Put(3, 1);
            //cache.Put(2, 1);
            //cache.Put(2, 2); // Updates 2
            //cache.Put(4, 4);    // evicts key 3.
            //Console.WriteLine(cache.Get(2));       // returns -1 (not found)        

            //cache.Put(0, 0);
            //Console.WriteLine(cache.Get(0));       // returns -1 (not found)        

            //var bc = new DataStructurePractice.GoogleProblems.BasicCalculator();
            //int n = bc.Calculate("(1+(4+5+2)-3)+(6+8)");
            //Console.WriteLine(n);

            //var cache = new Miscellaneous.LRUCache(2 /* capacity */ );

            //cache.Put(1, 1);
            //cache.Put(2, 2);
            //Console.WriteLine(cache.Get(1));       // returns 1
            //cache.Put(3, 3);    // evicts key 2
            //Console.WriteLine(cache.Get(2));       // returns -1 (not found)
            //cache.Put(4, 4);    // evicts key 1
            //Console.WriteLine(cache.Get(1));       // returns -1 (not found)
            //Console.WriteLine(cache.Get(3));       // returns 3
            //Console.WriteLine(cache.Get(4));       // returns 4


            //int s = 64;
            //var v = new Vector.BitVector(s);
            //for (int i = 0; i < s; i++)
            //{
            //    v.Update(i, true);
            //}

            //v.Clear();
            //Console.WriteLine(v);
        
        }

        //static void PrintList(LinkedList.ILinkedList<int> list)
        //{
        //	var en = list.GetEnumerator();
        //	while (en.Current != null)
        //	{
        //		Console.WriteLine(en.Current.Value);
        //		en.MoveNext();
        //	}
        //}
       

    }
}
