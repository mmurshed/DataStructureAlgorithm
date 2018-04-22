using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    public class BinarySearchTreeV1<K, V> : IBinaryTree<K, V>
        where K : IComparable<K>
    {
		public IBinaryNode<K, V> Root;

		public V Get(K Key)
		{
			return Get(Root, Key).Value;
		}

        public IBinaryNode<K, V> Get(IBinaryNode<K, V> Subroot, K Key)
		{
			if (Subroot == null)
				return null;

            int compare = Key.CompareTo(Subroot.Key);
            if (compare == 0)
				return Subroot;
            if (compare < 0)
				return Get(Subroot.Left, Key);
			return Get(Subroot.Right, Key);
		}

		public virtual bool Add(K Key, V Value)
		{
            if (Root == null)
            {
                Root = new BinaryNode<K, V>(Key, Value);
                return true;
            }

            return Add(Root, Key, Value);
		}

        protected virtual bool Add(IBinaryNode<K, V> Subroot, K Key, V Value)
		{
			if (Subroot == null)
			{
                Subroot = new BinaryNode<K, V>(Key, Value);
                return true;
			}

            int compare = Key.CompareTo(Subroot.Key);

            if (compare == 0)
				return false; // Key collision
			
            if (compare < 0)
			{
                if (Subroot.Left == null)
                {
                    Subroot.Left = new BinaryNode<K, V>(Key, Value);
                    return true;
                }
                else
                {
                    return Add(Subroot.Left, Key, Value);
                }
			}
            else
            {
                if (Subroot.Right == null)
                {
                    Subroot.Right = new BinaryNode<K, V>(Key, Value);
                    return true;
                }
                else
                {
                    return Add(Subroot.Right, Key, Value);
                }
            }
		}

        public bool Update(K Key, V Value)
        {
            var node = Get(Root, Key);
            if (node == null)
                return false;
            node.Value = Value;
            return true;
        }

        protected IBinaryNode<K, V> GetParent(IBinaryNode<K, V> Subroot, K Key)
		{
			if (Subroot == null)
				return null; // Not found;
			
            int compare = Key.CompareTo(Subroot.Key);
            if (compare == 0)
				return Subroot;
			
            if (Subroot.Left != null && Key.CompareTo(Subroot.Left.Key) == 0)
				return Subroot;
			
            else if (Subroot.Right != null && Key.CompareTo(Subroot.Right.Key) == 0)
				return Subroot;
			
            if (compare < 0)
				return GetParent(Subroot.Left, Key);
			return GetParent(Subroot.Right, Key);
		}

		public virtual bool Remove(K Key)
		{
            // 1. Find parent
			var parent = GetParent(Root, Key);
			if (parent == null)
				return false;

            // 2. find the node to remove
			IBinaryNode<K, V> nodeToRemove;
            if (parent.Left != null && parent.Left.Key.CompareTo(Key) == 0)
				nodeToRemove = parent.Left;
			else
				nodeToRemove = parent.Right;
			if (nodeToRemove == null)
				return false;
			
            // 3. Left tree is empty. Attach the right tree to parent.
            if (nodeToRemove.Left == null)
			{
                // a. Node to remove was on the left of the parent.
                // Attach the right subtree to parents left.
                if (parent.Left != null && parent.Left.Key.CompareTo(Key) == 0)
					parent.Left = nodeToRemove.Right;
                else
                    // b. Otherwise attach to the parent's right.
					parent.Right = nodeToRemove.Right;
			}

            // 4. Right tree is empty. Attach the left tree to parent
			else if (nodeToRemove.Right == null)
			{
                // a. Node to remove was on the left of the parent.
                // Attach the left subtree to parent's left
                if (parent.Left != null && parent.Left.Key.CompareTo(Key) == 0)
					parent.Left = nodeToRemove.Left;
				else
                    // b. Otherwise attach to parent's right
					parent.Right = nodeToRemove.Left;
			}

            // 5. Neither subtree is empty.
			else
			{
                // We will find the right most of node of the left subtree
                // and replace it with the node to delete.

                // In an inorder traversal, the right most node of the left
                // sub tree is the previous item in the sorted array.

                // a. Node to remove is going to be replaced by 
                // the right most node of the left subtree
				var parentReplace = nodeToRemove;

                // b. Start with the left subtree
				var toReplace = nodeToRemove.Left;
				
                // c. Find the right most node form the left subtree
                while (toReplace.Right != null)
				{
					parentReplace = toReplace;
					toReplace = toReplace.Right;
				}

                // d. Right most node is actually the left node. Right most node didn't exist.
                // Save the left subtree appropriately
				if (parentReplace == nodeToRemove)
					nodeToRemove.Left = toReplace.Left;
				else
					parentReplace.Right = toReplace.Left;

                // e. Swap with the nodes to remove
				toReplace.Left = nodeToRemove.Left;
				toReplace.Right = nodeToRemove.Right;

                // f. Set the correct parent
                if (parent.Left != null && parent.Left.Key.CompareTo(Key) == 0)
					parent.Left = toReplace;
				else
					parent.Right = toReplace;
			}

            // 6. Delete the parent
			nodeToRemove = null;
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
