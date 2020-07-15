using System.Collections.Generic;
using DataStructure.Graph;

namespace Algorithm.Graph
{
    /* 
     * In the previous post, we introduced union find algorithm and used it to 
     * detect cycle in a graph. We used following union() and find() 
     * operations for subsets.
     * 
     * class UnionFind
     * {
     *     int parent[];
     *     public int Find(int i)
     *     {
     *         if (parent[i] == -1)
     *             return i;
     *         return Find(parent[i]);
     *     }
     *     
     *     public void Union(int x, int y)
     *     {
     *         int xset = Find(parent, x);
     *         int yset = Find(parent, y);
     *         parent[xset] = yset;
     *     }
     * }
     * 
     * The above union() and find() are naive and the worst case time 
     * complexity is linear. The trees created to represent subsets can be 
     * skewed and can become like a linked list. Following is an example
     * worst case scenario.
     * 
     * Let there be 4 elements 0, 1, 2, 3
     * 
     * Initially all elements are single element subsets.
     * 0 1 2 3 
     * 
     * Do Union(0, 1)
     *   1   2   3  
     *  /
     * 0
     * 
     * Do Union(1, 2)
     *     2   3   
     *    /
     *   1
     *  /
     * 0
     * 
     * Do Union(2, 3)
     *       3
     *      /
     *     2
     *    /
     *   1
     *  /
     * 0
     * 
     * The above operations can be optimized to O(Log n) in worst case.
     * The idea is to always attach smaller depth tree under the root of the 
     * deeper tree. This technique is called union by rank. The term rank is
     * preferred instead of height because if path compression technique 
     * (we have discussed it below) is used, then rank is not always equal 
     * to height. Also, size (in place of height) of trees can also be used 
     * as rank. Using size as rank also yields worst case time complexity 
     * as O(Logn)
     * 
     * Let us see the above example with union by rank
     * Initially all elements are single element subsets.
     * 
     * 0 1 2 3 
     * 
     * Do Union(0, 1)
     *   1   2   3  
     *  /
     * 0
     * 
     * Do Union(1, 2)
     *    1    3
     *   --
     *  /  \
     * 0    2
     * Do Union(2, 3)
     *     1
     *   -----
     *  /  |  \
     * 0   2   3
     * 
     * The second optimization to naive method is Path Compression.
     * The idea is to flatten the tree when find() is called. When find() is
     * called for an element x, root of the tree is returned. The find() 
     * operation traverses up from x to find root. The idea of path 
     * compression is to make the found root as parent of x so that we don’t 
     * have to traverse all intermediate nodes again. If x is root of a subtree, 
     * then path (to root) from all nodes under x also compresses.
     * 
     * Let the subset {0, 1, .. 9} be represented as below and find() is 
     * called for element 3.
     *         9
     *         |
     *     ---------
     *    /    |    \  
     *   4     5     6
     *  / \         /  \
     * 0   3       7    8
     *    /  \
     *   1    2  
     * 
     * When find() is called for 3, we traverse up and find 9 as 
     * representative of this subset. With path compression, we also make 3 
     * as child of 9 so  that when find() is called next time for 1, 2 or 3, 
     * the path to root is reduced.
     *         9
     *         |
     *     ------------
     *    /    /  \    \
     *   4    5    6    3 
     *  /         / \  /  \
     * 0         7   8 1   2           
     *   
     * The two techniques complement each other. The time complexity of each 
     * operations becomes even smaller than O(Logn). In fact, amortized time 
     * complexity effectively becomes small constant.
    */

    // A disjoint-set data structure is a data structure that keeps track of a 
    // set of elements partitioned into a number of disjoint (non-overlapping) 
    // subsets. A union-find algorithm is an algorithm that performs two useful 
    // operations on such a data structure:
    public class UnionFind<V,T>
    {
        private readonly int[] parent;
        private readonly int[] rank;

        public UnionFind(int n)
        {
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = -1;
                rank[i] = 0;
            }
        }

        // Determine which subset a particular element is in.
        // This can be used for determining if two elements
        // are in the same subset.
        private int Find(int i)
        {
            if (parent[i] == -1)
                return i;
            parent[i] = Find(parent[i]); // Path compression
            return parent[i];
        }

        // Join two subsets into a single subset.
        private void Union(int x, int y)
        {
            int xp = Find(x);
            int yp = Find(y);

            // Parent with higher rank
            // becomes the parent of the
            // lower rank
            if (rank[xp] < rank[yp])
                parent[xp] = yp;
            else if (rank[xp] > rank[yp])
                parent[yp] = xp;
            else
            {
                // xp is randomly selected as the parent
                parent[yp] = xp;
                rank[xp]++;
            }
        }

        public bool IsCycle(int start, int end)
        {
            int x = Find(start);
            int y = Find(end);
            if (x == y)
                return true;
            Union(x, y);
            return false;
        }

        public bool IsCycle(IEnumerable<IEdge<V,T>> edges)
        {
            foreach(var edge in edges)
            {
                int x = Find((int)edge.Start.ID);
                int y = Find((int)edge.End.ID);
                if (x == y)
                    return true;
                Union(x, y);
            }
            return false;
        }
    }
}
