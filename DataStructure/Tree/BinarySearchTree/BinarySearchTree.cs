using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    public class BinarySearchTree<K, V> : IBinaryTree<K, V>
        where K : IComparable<K>
    {
        public BinaryNode<K, V> Empty = new BinaryNode<K, V>();
		public BinaryNode<K, V> Root;

		public V Get(K Key)
		{
			return Get(ref Root, Key).Value;
		}

        public ref BinaryNode<K, V> Get(ref BinaryNode<K, V> Subroot, K Key)
		{
			if (Subroot == null)
                return ref Empty;

            int compare = Key.CompareTo(Subroot.Key);
            if (compare == 0)
				return ref Subroot;
            if (compare < 0)
				return ref Get(ref Subroot.LeftNode, Key);
			return ref Get(ref Subroot.RightNode, Key);
		}

		public virtual bool Add(K Key, V Value)
		{
            return Add(ref Root, Key, Value);
		}

        protected virtual bool Add(ref BinaryNode<K, V> Subroot, K Key, V Value)
		{
			if (Subroot == null)
			{
                Subroot = new BinaryNode<K, V>(Key, Value);
                return true;
			}

            int compare = Key.CompareTo(Subroot.Key);

            if (compare == 0)
				return false; // Key collision
            else if (compare < 0)
			{
                return Add(ref Subroot.LeftNode, Key, Value);
			}
            else
            {
                return Add(ref Subroot.RightNode, Key, Value);
            }
		}

        public bool Update(K Key, V Value)
        {
            var node = Get(ref Root, Key);
            if (node == null || node == Empty)
                return false;
            node.Value = Value;
            return true;
        }

		public virtual bool Remove(K Key)
		{
            // 1. find the node to remove
            ref var nodeToRemove = ref Get(ref Root, Key);
            if (nodeToRemove == null || nodeToRemove == Empty)
                return false;
						
            // 2. Left tree is empty. Replace with right tree.
            if (nodeToRemove.Left == null)
			{
                nodeToRemove = nodeToRemove.RightNode;
			}
            // 3. Right tree is empty. Attach the left tree to parent
			else if (nodeToRemove.Right == null)
			{
                nodeToRemove = nodeToRemove.LeftNode;
			}
            // 4. Neither subtree is empty.
			else
			{
                // We will find the right most of node of the left subtree
                // and replace it with the node to delete.

                // In an inorder traversal, the right most node of the left
                // sub tree is the previous item in the sorted array.

                // a. Start with the left subtree
                var toReplace = nodeToRemove.LeftNode;
                var parentOfReplace = nodeToRemove;
				
                // b. Find the right most node form the left subtree
                while (toReplace.Right != null)
				{
                    parentOfReplace = toReplace;
                    toReplace = toReplace.RightNode;
				}

                // c. Fix the pointers
                if (parentOfReplace.Key.Equals(nodeToRemove.Key))
                    nodeToRemove.LeftNode = toReplace.LeftNode;
                else
                    parentOfReplace.RightNode = toReplace.LeftNode;

                // d. Swap with the nodes to remove
                nodeToRemove.Key = toReplace.Key;
                nodeToRemove.Value = toReplace.Value;

                toReplace = null;
			}

			return true;
		}

		public void InOrder(ITreeVisitor<K, V> v)
		{
			InOrder(Root, v);
		}

		public void InOrder(IBinaryNode<K, V> Subroot, ITreeVisitor<K, V> v)
		{
			if (Subroot == null)
				return;
			InOrder(Subroot.Left, v);
			v.Visit(Subroot);
			InOrder(Subroot.Right, v);
		}
	}
}
