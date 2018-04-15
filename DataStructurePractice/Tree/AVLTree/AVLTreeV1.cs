using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class AVLTreeV1<K, V> : IBinaryTree<K, V>
        where K: IComparable<K>
    {
        public AVLNodeV1<K, V> Root;

        public V Get(K Key)
        {
            return Get(Root, Key).Value;
        }

        public AVLNodeV1<K, V> Get(AVLNodeV1<K, V> Subroot, K Key)
        {
            if (Subroot == null)
                return null;

            int compare = Key.CompareTo(Subroot.Key);

            if (compare == 0)
                return Subroot;
            if (compare < 0)
                return Get(Subroot.LeftNode, Key);
            return Get(Subroot.RightNode, Key);
        }

        public bool Update(K Key, V Value)
        {
            var node = Get(Root, Key);
            if (node == null)
                return false;
            node.Value = Value;
            return true;
        }

        private bool RotateLeft(ref AVLNodeV1<K, V> subroot)
        {
            if (subroot == null || subroot.Right == null)
                return false;

            var rightTree = subroot.RightNode;
            subroot.RightNode = rightTree.LeftNode;
            rightTree.LeftNode = subroot;
            subroot = rightTree;

            return true;
        }

        private bool RotateRight(ref AVLNodeV1<K, V> subroot)
        {
            if (subroot == null || subroot.Left == null)
                return false;

            var leftTree = subroot.LeftNode;
            subroot.LeftNode = leftTree.RightNode;
            leftTree.RightNode = subroot;
            subroot = leftTree;

            return true;
        }

        private void RightBalance(ref AVLNodeV1<K, V> subroot)
        {
            var rightTree = subroot.RightNode;
            switch(rightTree.Balance)
            {
                case BalanceFactor.RIGHT_HIGHER:
                    subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                    rightTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                    RotateLeft(ref subroot);
                    break;
                case BalanceFactor.LEFT_HIGHER:
                    var leftTree = rightTree.LeftNode;
                    switch(leftTree.Balance)
                    {
                        case BalanceFactor.EQUAL_HEIGHT:
                            subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                            rightTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                            break;
                        case BalanceFactor.LEFT_HIGHER:
                            subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                            rightTree.Balance = BalanceFactor.RIGHT_HIGHER;
                            break;
                        case BalanceFactor.RIGHT_HIGHER:
                            subroot.Balance = BalanceFactor.LEFT_HIGHER;
                            rightTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                            break;
                    }
                    leftTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                    RotateRight(ref rightTree);
                    RotateLeft(ref subroot);
                    break;
            }
        }

        private void LeftBalance(ref AVLNodeV1<K, V> subroot)
        {
            var leftTree = subroot.LeftNode;
            switch (leftTree.Balance)
            {
                case BalanceFactor.LEFT_HIGHER:
                    subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                    leftTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                    RotateRight(ref subroot);
                    break;
                case BalanceFactor.RIGHT_HIGHER:
                    var rightTree = leftTree.RightNode;
                    switch (rightTree.Balance)
                    {
                        case BalanceFactor.EQUAL_HEIGHT:
                            subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                            leftTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                            break;
                        case BalanceFactor.RIGHT_HIGHER:
                            subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                            leftTree.Balance = BalanceFactor.LEFT_HIGHER;
                            break;
                        case BalanceFactor.LEFT_HIGHER:
                            subroot.Balance = BalanceFactor.RIGHT_HIGHER;
                            leftTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                            break;
                    }
                    rightTree.Balance = BalanceFactor.EQUAL_HEIGHT;
                    RotateLeft(ref leftTree);
                    RotateRight(ref subroot);
                    break;
            }
        }

        public bool Add(K Key, V Value)
		{
            bool inserted = true;
            try
            {
                Add(null, ref Root, Key, Value);
            }
            catch(Exception)
            {
                inserted = false;
            }
            return inserted;
		}

        protected bool Add(IAVLNodeV1<K, V> parent, ref AVLNodeV1<K, V> Subroot, K Key, V Value)
		{
            if(Subroot == null)
            {
                Subroot = new AVLNodeV1<K,  V>(Key, Value);
                return true;
            }

            int compare = Key.CompareTo(Subroot.Key);

            if (compare == 0)
            {
                // Key collision
                throw new Exception("Key collision");
            }

            if(compare < 0)
            {
                var taller = Add(Subroot, ref Subroot.LeftNode, Key, Value);
                if(taller)
                {
                    switch(Subroot.Balance)
                    {
                        case BalanceFactor.LEFT_HIGHER:
                            LeftBalance(ref Subroot);
                            taller = false;
                            break;
                        case BalanceFactor.EQUAL_HEIGHT:
                            Subroot.Balance = BalanceFactor.LEFT_HIGHER;
                            break;
                        case BalanceFactor.RIGHT_HIGHER:
                            Subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                            taller = false;
                            break;
                    }
                }
                return taller;
            }
            else
            {
                var taller = Add(Subroot, ref Subroot.RightNode, Key, Value);
                if(taller)
                {
                    switch(Subroot.Balance)
                    {
                        case BalanceFactor.LEFT_HIGHER:
                            Subroot.Balance = BalanceFactor.EQUAL_HEIGHT;
                            taller = false;
                            break;
                        case BalanceFactor.EQUAL_HEIGHT:
                            Subroot.Balance = BalanceFactor.RIGHT_HIGHER;
                            break;
                        case BalanceFactor.RIGHT_HIGHER:
                            RightBalance(ref Subroot);
                            taller = false;
                            break;
                    }
                }
                return taller;
            }
		}

        public bool Remove(K Key)
		{
   //         // 1. Find parent
			//var parent = GetParent(Root, Key);
			//if (parent == null)
			//	return false;

   //         // 2. find the node to remove
			//BinaryNode<T> nodeToRemove;
			//if (parent.Left != null && parent.Left.Key == Key)
			//	nodeToRemove = parent.Left;
			//else
			//	nodeToRemove = parent.Right;
			//if (nodeToRemove == null)
			//	return false;
			
   //         // 3. Left tree is empty. Attach the right tree to parent.
   //         if (nodeToRemove.Left == null)
			//{
   //             // a. Node to remove was on the left of the parent.
   //             // Attach the right subtree to parents left.
			//	if (parent.Left != null && parent.Left.Key == Key)
			//		parent.Left = nodeToRemove.Right;
   //             else
   //                 // b. Otherwise attach to the parent's right.
			//		parent.Right = nodeToRemove.Right;
			//}

   //         // 4. Right tree is empty. Attach the left tree to parent
			//else if (nodeToRemove.Right == null)
			//{
   //             // a. Node to remove was on the left of the parent.
   //             // Attach the left subtree to parent's left
			//	if (parent.Left != null && parent.Left.Key == Key)
			//		parent.Left = nodeToRemove.Left;
			//	else
   //                 // b. Otherwise attach to parent's right
			//		parent.Right = nodeToRemove.Left;
			//}

   //         // 5. Neither subtree is empty.
			//else
			//{
   //             // We will find the right most of node of the left subtree
   //             // and replace it with the node to delete.

   //             // In an inorder traversal, the right most node of the left
   //             // sub tree is the previous item in the sorted array.

   //             // a. Node to remove is going to be replaced by 
   //             // the right most node of the left subtree
			//	var parentReplace = nodeToRemove;

   //             // b. Start with the left subtree
			//	var toReplace = nodeToRemove.Left;
				
   //             // c. Find the right most node form the left subtree
   //             while (toReplace.Right != null)
			//	{
			//		parentReplace = toReplace;
			//		toReplace = toReplace.Right;
			//	}

   //             // d. Right most node is actually the left node. Right most node didn't exist.
   //             // Save the left subtree appropriately
			//	if (parentReplace == nodeToRemove)
			//		nodeToRemove.Left = toReplace.Left;
			//	else
			//		parentReplace.Right = toReplace.Left;

   //             // e. Swap with the nodes to remove
			//	toReplace.Left = nodeToRemove.Left;
			//	toReplace.Right = nodeToRemove.Right;

   //             // f. Set the correct parent
			//	if (parent.Left != null && parent.Left.Key == Key)
			//		parent.Left = toReplace;
			//	else
			//		parent.Right = toReplace;
			//}

   //         // 6. Delete the parent
			//nodeToRemove = null;
			return true;
		}

        public void InOrder(AVLTreeVisitorV1<K, V> v)
        {
            InOrder(Root, v, 0);
        }

        public void InOrder(IAVLNodeV1<K, V> Subroot, AVLTreeVisitorV1<K, V> v, int level)
        {
            if (Subroot == null)
                return;
            v.PreVisit(Subroot, level);
            InOrder(Subroot.Left, v, level+1);
            v.Visit(Subroot, level);
            InOrder(Subroot.Right, v, level+1);
            v.PostVisit(Subroot, level);
        }
    }
}
