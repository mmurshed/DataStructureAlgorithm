using System;
using System.Linq;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main1(string[] args)
        {
            // var A = new int[] { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            // var lis = DynamicProgramming.LIS(A);
            // Console.WriteLine(lis);

            // var lps = DynamicProgramming.LPS("forgeeksskeegfor");
            // Console.WriteLine(lps);


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


            // DynamicProramming.MatrixChainMultiplication.Test();


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
    }
}
