using System;
using Tree;
using System.Linq;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //var binaryTree = new BinarySearchTree<int, int>();

            //binaryTree.Add(5, 10);
            //binaryTree.Add(3, 10);
            //binaryTree.Add(1, 10);
            //binaryTree.Add(4, 10);
            //binaryTree.Add(20, 10);
            //binaryTree.Add(11, 10);
            //binaryTree.Add(14, 10);
            //binaryTree.Add(13, 10);
            //binaryTree.Add(12, 10);
            //binaryTree.Add(10, 10);
            //binaryTree.Add(25, 10);
            //binaryTree.Add(21, 10);
            //binaryTree.Add(30, 10);
            //binaryTree.Add(15, 10);
            //binaryTree.Add(6, 10);

            //var v = new Visitor<int, int>();
            //var cv = new ConcreteVisitorDecorator<int, int>(v);
            //Console.Write("[");
            //binaryTree.InOrder(cv);
            //Console.WriteLine("]");

            //var node = binaryTree.Get(ref binaryTree.Root, 20);
            //Console.WriteLine($"{node.Key} {node.Left.Key} {node.Right.Key}");

            //binaryTree.Remove(1);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");
            //binaryTree.Remove(20);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");
            //binaryTree.Remove(14);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");
            //binaryTree.Remove(15);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");
            //binaryTree.Remove(11);
            //binaryTree.Remove(10);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");
            //binaryTree.Remove(11);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");
            //binaryTree.Remove(12);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");
            //binaryTree.Remove(11);
            //Console.Write("["); binaryTree.InOrder(cv); Console.WriteLine("]");

            //var binaryTree = new AVLTree<int, int>();

            //binaryTree.Add(5, 10);
            //binaryTree.Add(3, 10);
            //binaryTree.Add(1, 10);
            //binaryTree.Add(4, 10);
            //binaryTree.Add(20, 10);
            //binaryTree.Add(11, 10);
            //binaryTree.Add(14, 10);
            //binaryTree.Add(13, 10);
            //binaryTree.Add(12, 10);
            //binaryTree.Add(10, 10);
            //binaryTree.Add(25, 10);
            //binaryTree.Add(21, 10);
            //binaryTree.Add(30, 10);
            //binaryTree.Add(15, 10);
            //binaryTree.Add(6, 10);

            //var v = new AVLTreeVisitor<int, int>();
            //Console.Write("[");
            //binaryTree.InOrder(v);
            //Console.WriteLine("]");

            //var node = binaryTree.Get(binaryTree.Root, 20);
            //Console.WriteLine($"{node.Key} {node.Left?.Key} {node.Right?.Key}");

            //binaryTree.Remove(1);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");
            //binaryTree.Remove(20);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");
            //binaryTree.Remove(14);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");
            //binaryTree.Remove(15);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");
            //binaryTree.Remove(11);
            //binaryTree.Remove(10);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");
            //binaryTree.Remove(11);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");
            //binaryTree.Remove(12);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");
            //binaryTree.Remove(11);
            //Console.Write("["); binaryTree.InOrder(v); Console.WriteLine("]");

            //LinkedList<int> list = new LinkedList<int>();
            //list.Add(10);
            //list.Add(20);
            //list.Add(30);
            //list.Add(40);
            //PrintList(list);

            //var p = list.RecursiveReverse();
            //PrintList(p);
            // var res = DynamicProgramming.LCS("ABCDGH", "AEDFHR");
            //var res = DynamicProgramming.LRS("AABB");
            // Console.WriteLine($"{res.Item1} {res.Item2}");
            // var arr = new int[2, 3];
            //for (int i = 0; i < arr.GetLength(0); i++)
            //	for (int j = 0; j < arr.GetLength(1); j++)
            //		Console.WriteLine($"{arr[i,j]}");

            // var A = new int[] { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            // var lis = DynamicProgramming.LIS(A);
            // Console.WriteLine(lis);

            // var lps = DynamicProgramming.LPS("forgeeksskeegfor");
            // Console.WriteLine(lps);

            //var testGraph = new Graph.TestGraphMatrixBuilder();

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

            var topoGraphBuilder = new Graph.TopoGraphListBuilder();
            topoGraphBuilder.Build();
            var topS = new Graph.Algorithms.TopologicalSortBFS<int, int>();
            var sort = topS.Sort(topoGraphBuilder.Graph);
            foreach(var x in sort)
            {
                Console.WriteLine(x.ID);
            }

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

            // DynamicProramming.MatrixChainMultiplication.Test();

            //string line = "abcdef";
            //int[] freq = new int[] { 5, 9, 12, 13, 16, 45 };

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

            // bool result = DataStructurePractice.GoogleProblems.ValidWordAbbreviation.ValidAbbr("jnternationalization", "i12iz4n");
            // Console.WriteLine($"{result}");

            //var list = DataStructurePractice.GoogleProblems.ValidWordAbbreviation.GenerateAbbreviations2("word");
            //var ord = list.OrderBy(x => x.Length);
            //foreach(var abbr in ord)
            //Console.WriteLine($"{abbr.Word}:{abbr.Length}");

            //var str = DataStructurePractice.GoogleProblems.ValidWordAbbreviation.MinimumUniqueWordAbbreviation("apple", new []{"plain", "amber", "blade"});
            //Console.WriteLine(str);

            //var l1 = new DataStructurePractice.GoogleProblems.ListNode(2);
            //l1.next = new DataStructurePractice.GoogleProblems.ListNode(3);
            //l1.next.next = new DataStructurePractice.GoogleProblems.ListNode(7);
            //var l2 = new DataStructurePractice.GoogleProblems.ListNode(4);
            //l2.next = new DataStructurePractice.GoogleProblems.ListNode(8);
            //var r = DataStructurePractice.GoogleProblems.MergeKListsClass.MergeKLists(new []{l1, l2});
            //while(r != null) {
            //    Console.WriteLine(r.val);
            //    r = r.next;
            //}

            //var i = new DataStructurePractice.GoogleProblems.NestedIntegerT(3);
            //var j = new DataStructurePractice.GoogleProblems.NestedIntegerT(10);
            //var k = new DataStructurePractice.GoogleProblems.NestedIntegerT(5);
            //var x = new List<DataStructurePractice.GoogleProblems.NestedInteger>{i, j, k};
            //var a = new DataStructurePractice.GoogleProblems.NestedIntegerT(x);
            //var b = new DataStructurePractice.GoogleProblems.NestedIntegerT(15);
            //var y = new List<DataStructurePractice.GoogleProblems.NestedInteger> { b, a, b};

            //var p = new List<DataStructurePractice.GoogleProblems.NestedInteger> { };
            //var q = new DataStructurePractice.GoogleProblems.NestedIntegerT(p);
            //var r = new List<DataStructurePractice.GoogleProblems.NestedInteger> { q };

            //var ni = new DataStructurePractice.GoogleProblems.NestedIterator(y);
            //while (ni.HasNext())
            //Console.WriteLine(ni.Next());

            // var nums = new[] { 5, 2, 6, 1 };
            // var nums = new[] { 3, 1, 2, 3, 0 };
            //                  3   1  1 1, 0
            // var nums = new[] { 26, 78, 27, 100, 33, 67, 90, 23, 66, 5, 38, 7, 35, 23, 52, 22, 83, 51, 98, 69, 81, 32, 78, 28, 94, 13, 2, 97, 3, 76, 99, 51, 9, 21, 84, 66, 65, 36, 100, 41 };
            //var nums = new[] { 99, 51, 9, 21, 84, 66, 65, 36, 100, 41 };
            ////                  8   4  0   0   4   3   2   0    1   0
            ////                     9    21    36   36    36    36    41   41
            //// var nums = new[] { 65, 100, 41 };
            ////                 1    1    0

            //var r = DataStructurePractice.GoogleProblems.CountSmallerNumbers.CountSmaller(nums);
            //foreach(var x in r)
            //Console.Write($"{x}, ");

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

            //var bb = new DataStructurePractice.BurstBalloons();
            //var nums = new []{ 3, 1, 5, 8};
            //var val = bb.MaxCoins(nums);
            //Console.WriteLine(val);

            // var lip = new DataStructurePractice.GoogleProblems.LongestIncreasingPathMatrix();
            //var mat = new int[,] {
            //    {9,9,4},
            //    {6,6,8},
            //    {2,1,1}
            //};

            //var mat = new int[,] { { 3, 4, 5 }, { 3, 2, 6 }, { 2, 2, 1 } };
            //int p = lip.LongestIncreasingPath(mat);
            //Console.WriteLine(p);

            //var sp = new DataStructurePractice.GoogleProblems.SkylineProblem();
            //// var sk = sp.GetSkyline(new int[,] { { 2, 9, 10 }, { 3, 7, 15 }, { 5, 12, 12 }, { 15, 20, 10 }, { 19, 24, 8 } });
            //var sk = sp.GetSkyline(new int[,] { { 0, 2, 3 }, { 2, 5, 3 } });
            //foreach(var i in sk)
            //{
            //    foreach(var j in i)
            //    {
            //        Console.Write($"{j},");
            //    }
            //    Console.WriteLine();
            //}

            //var x = new DataStructurePractice.GoogleProblems.ExpressionAddOperators();
            //var y = x.AddOperators("1234", 24);
            //foreach (var p in y)
            //Console.WriteLine(p);

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
