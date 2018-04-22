using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class CartesianTree<T>
    {
        private CartesianNode<T> Root;
        private Comparison<T> Compare;

        public CartesianTree(Comparison<T> comparison)
        {
            this.Compare = comparison;
        }
        public CartesianTree(IComparer<T> comparer)
        {
            this.Compare = comparer.Compare;
        }

        public CartesianTree() : this(Comparer<T>.Default)
        {
        }

        public void Build(T[] data)
        {
            BuildNaive(ref Root, data, 0, data.Length - 1);
        }

        private int FindDesired(T[] data, int start, int end)
        {
            if (end < start || start < 0 || end >= data.Length)
                return -1;
            int desired = start;
            for (int i = start; i <= end; i++)
            {
                if(Compare(data[i], data[desired]) < 0 )
                {
                    desired = i;
                }
            }
            return desired;
        }

        // O(n^2)
        private void BuildNaive(ref CartesianNode<T> node, T[] data, int start, int end)
        {
            if (end < start || start < 0 || end >= data.Length)
                return;

            int desired = FindDesired(data, start, end);
            if (desired < 0)
                return;

            node = new CartesianNode<T>(data[desired]);

            BuildNaive(ref node.Left, data, start, desired - 1);
            BuildNaive(ref node.Right, data, desired + 1, end);
        }


        /*
         * Scan the given sequence from left to right adding new nodes as follows:
         * 
         * 1. Position the node as the right child of the rightmost node.
         * 
         * 2. Scan upward from the node’s parent up to the root of the tree until a node is found whose value is greater than the current value.
         * 
         * 3. If such a node is found, set its right child to be the new node, and set the new node’s left child to be the previous right child.
         * 
         * 4. If no such node is found, set the new child to be the root, and set the new node’s left child to be the previous tree.
         * 
        */

        // Recursively construct subtree under given root using leftChil[] and rightchild
        private CartesianNode<T> BuildLinear(int root, T[] arr, int[] parent, int[] leftchild, int[] rightchild)
        {
            if (root == -1)
                return null;

            // Create a new node with root's data
            var temp = new CartesianNode<T>(arr[root]);

            // Recursively construct left and right subtrees
            temp.Left = BuildLinear(leftchild[root], arr, parent, leftchild, rightchild);
            temp.Right = BuildLinear(rightchild[root], arr, parent, leftchild, rightchild);

            return temp;
        }

        // A function to create the Cartesian Tree in O(N) time
        public void BuildLinear(T[] arr)
        {
            int n = arr.Length;
            // Arrays to hold the index of parent, left-child,
            // right-child of each number in the input array
            var parent = new int[n];
            var leftchild = new int[n];
            var rightchild = new int[n];

            // Initialize all array values as -1
            for (int i = 0; i < n; i++)
            {
                parent[i] = -1;
                leftchild[i] = -1;
                rightchild[i] = -1;
            }

            // 'root' and 'last' stores the index of the root and the last 
            // processed of the Cartesian Tree. Initially we take root of the
            // Cartesian Tree as the first element of the input array. This can
            // change according to the algorithm
            int root = 0, last;

            // Starting from the second element of the input array to the last 
            // one, scan across the elements, adding them one at a time.
            for (int i = 1; i < n; i++)
            {
                last = i - 1;
                rightchild[i] = -1;

                // Scan upward from the node's parent up to the root of the tree
                // until a node is found whose value is greater than the current
                // one. This is the same as Step 2 mentioned in the algorithm
                while (Compare(arr[last], arr[i]) <= 0 && last != root)
                    last = parent[last];

                // arr[i] is the largest element yet; make it new root
                if (Compare(arr[last], arr[i]) <= 0)
                {
                    parent[root] = i;
                    leftchild[i] = root;
                    root = i;
                }

                // Just insert it
                else if (rightchild[last] == -1)
                {
                    rightchild[last] = i;
                    parent[i] = last;
                    leftchild[i] = -1;
                }

                // Reconfigure links
                else
                {
                    parent[rightchild[last]] = i;
                    leftchild[i] = rightchild[last];
                    rightchild[last] = i;
                    parent[i] = last;
                }

            }

            // Since the root of the Cartesian Tree has no parent, so we assign it -1
            parent[root] = -1;

            Root = BuildLinear(root, arr, parent, leftchild, rightchild);
        }

        public IEnumerable<T> GetInOrderEnumerator()
        {
            foreach(var d in GetInOrderEnumerator(Root))
            {
                yield return d;
            }
        }

        private IEnumerable<T> GetInOrderEnumerator(CartesianNode<T> node)
        {
            if (node.Left != null)
            {
                foreach (var d in GetInOrderEnumerator(node.Left))
                    yield return d;
            }
            yield return node.Data;

            if(node.Right != null)
            {
                foreach (var d in GetInOrderEnumerator(node.Right))
                    yield return d;
            }
        }
    }
}
