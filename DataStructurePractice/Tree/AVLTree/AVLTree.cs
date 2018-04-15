using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    // Source: https://bitlush.com/blog/efficient-avl-tree-in-c-sharp

    /*
     * The AVL tree is a rigorously balance binary search tree with very fast 
     * and stable insert, delete and search times. I like the various .NET 
     * dictionaries but have been unimpressed by their performance. So, after 
     * researching efficient dictionary algorithms, I stumbled upon AVL trees 
     * and decided to code a really efficient implementation (performance being 
     * my main concern). In this post I will discuss the techniques I used to 
     * create a highly optimised AVL tree that can be used like a dictionary 
     * (although I don't implement IDictionary for brevity) with very fast and 
     * reliable performance under varied usage scenarios.
     * 
     * There are roughly two ways to code this algorithm: with or without 
     * recursion. The non-recursive way is more efficient as the CLR does not 
     * have to keep pushing and popping its call stack (which is quite slow). 
     * The non-recursive way is unfortunately harder to code. So the challenge 
     * was on!
     * 
     * There are also two ways to keep track of the balance of each tree node, 
     * indirectly by storing the height, or directly by storing the balance. 
     * Again, storing the balance directly is harder to code as a full 
     * understanding of how rotations affect the balance of each node in the 
     * rotation is needed (useful and reliable information on the internet is 
     * hard to find on how to keep track of balances directly for deletion). 
     * Challenge number two!
     * 
     * Node Height
     * Although I don’t use height in my AVL tree, it is useful to understand 
     * the definition of height for the AVL algorithm. The height of a node is 
     * measured by how many generations of descendents it has. The root node 
     * will therefore increase in height as descendants are added to it:
     *     R
     *    / \
    *   A   B
    *  /
    * C
    * 
    * The root node R has a height of 2; nodes A and B have a height of 1; 
    * node C has a height of 0.
    * 
    * Node Balance
    * I keep track of each node’s balance in my AVL tree. The balance of a node
    * is the difference in height between its left and right sub-tree.
    *     R
    *    / \
    *   A   B
    *    \
    *     C
    * The root node R has a balance of 1; node A has a balance of -1; nodes B 
    * and C have a balance of 0.
    *                                                                                                        
    * 
    * Node Ordering
    * The nodes in an AVL tree are ordered so that a left child is always 
    * smaller than its parent and a right child is always greater than its parent.
    */

    public class AVLTree<K, V> : IBinaryTree<K, V>
        where K: IComparable<K>
    {
        public AVLNode<K, V> Root;

        public V Get(K Key)
        {
            return Get(Root, Key).Value;
        }

        public AVLNode<K, V> Get(AVLNode<K, V> Subroot, K Key)
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

        public bool Update(K Key, V Value)
        {
            var node = Get(Root, Key);
            if (node == null)
                return false;
            node.Value = Value;
            return true;
        }

        /*
         * Node Insertion
         * When a new node is added to an AVL tree, it must be added in the 
         * right place to make sure the tree remains ordered. The sequence at 
         * which nodes are added to an AVL tree will affect the structure (i.e. 
         * two trees with the same nodes might have different structures).
         * 
         * Consider these two trees:
         *     5
         *    / \
         *   3   6
         *    \
         *     4
         * 
         *     4
         *    / \
         *   3   6
         *      /
         *     5
         * 
         * These AVL trees are valid, they both have the same node values, and
         * they are both in order. Due to the order in which the nodes were
         * added, however, their structures are slightly different.
        */

        public bool Add(K key, V value)
        {
            if (Root == null)
            {
                Root = new AVLNode<K, V> (key, value);
                return true;
            }

            var node = Root;

            while (node != null)
            {
                int compare = key.CompareTo(node.Key);

                if (compare < 0)
                {
                    var left = node.Left;

                    if (left == null)
                    {
                        node.Left = new AVLNode<K, V> (key, value, node);
                        InsertBalance(node, 1);
                        return true;
                    }
                    else
                    {
                        node = left;
                    }
                }
                else if (compare > 0)
                {
                    var right = node.Right;

                    if (right == null)
                    {
                        node.Right = new AVLNode<K, V>(key, value, node);;
                        InsertBalance(node, -1);
                        return true;
                    }
                    else
                    {
                        node = right;
                    }
                }
                else
                {
                    // node.Value = value;
                    return false; // Duplicate key
                }
            }
            return false;
        }

        /*
         * Balancing after Insertion
         * The method InsertBalance is necessary for rebalancing the tree after
         * an insertion. If the balance of a node becomes 2 or -2 it must be 
         * rotated. There are four types of rotation: left, right, left-right 
         * and right-left:
         * 
         * Left Rotation
         * 
         *        (5)                   (4)
         *       /   \                 /   \
         *      (4)   S               /     \
         *     /   \        ==>     (3)     (5)
         *    (3)   R               / \     / \
         *   /   \                 /   \   /   \
         *  P     Q               P     Q R     S
         * 
         * Left Right Rotation
         * This involves a left rotation with 3 and 4 followed by a right rotation with 4 and 5.
         *        (5)                  (5)                 (4)
         *       /   \                /   \               /   \
         *      (3)   S              (4)   S             /     \
         *     /   \        ==>     /   \       ==>    (3)     (5)
         *    P    (4)             (3)   R             / \     / \
         *        /   \           /   \               /   \   /   \
         *       Q     R         P     Q             P     Q R     S
         * 
         * Right Rotation
         * 
         *      (3)                     (4)
         *     /   \                   /   \
         *    P   (4)                 /     \
         *       /   \      ==>     (3)     (5)
         *      Q   (5)             / \     / \
         *         /   \           /   \   /   \
         *        R     S         P     Q R     S
         * 
         * Right Left Rotation
         * This involves a right rotation with 4 and 5 followed by a left rotation with 3 and 4.
         * 
         *      (3)                 (3)                     (4)
         *     /   \               /   \                   /   \
         *    P   (5)             P   (4)                 /     \
         *       /   \      ==>      /   \      ==>     (3)     (5)
         *     (4)    D             Q   (5)             / \     / \
         *    /   \                    /   \           /   \   /   \
         *   B     C                  R     S         P     Q R     S
         * 
         * There are two rules that allow the balancing for insertions to be optimised
         * After a rotation, the node will have a balance of 0 (this is not 
         * obvious from the rotation code for the left and right case and 
         * doesn't hold true for deletion)
         * 
         * If a node’s balance is 0 you can stop traversing back up the tree
         * It also follows that you can stop traversing back up the tree if you 
         * perform a rotation. These rules do not hold true for deletion.
        */
        private void InsertBalance(AVLNode<K, V> node, int balance)
        {
            while (node != null)
            {
                balance = (node.Balance += balance);

                if (balance == 0)
                {
                    return;
                }
                else if (balance == 2)
                {
                    if (node.Left.Balance == 1)
                    {
                        RotateRight(node);
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }

                    return;
                }
                else if (balance == -2)
                {
                    if (node.Right.Balance == -1)
                    {
                        RotateLeft(node);
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }

                    return;
                }

                var parent = node.Parent;

                if (parent != null)
                {
                    balance = parent.Left == node ? 1 : -1;
                }

                node = parent;
            }
        }

        private AVLNode<K, V> RotateLeft(AVLNode<K, V> node)
        {
            AVLNode<K, V> right = node.Right;
            AVLNode<K, V> rightLeft = right.Left;
            AVLNode<K, V> parent = node.Parent;

            right.Parent = parent;
            right.Left = node;
            node.Right = rightLeft;
            node.Parent = right;

            if (rightLeft != null)
            {
                rightLeft.Parent = node;
            }

            if (node == Root)
            {
                Root = right;
            }
            else if (parent.Right == node)
            {
                parent.Right = right;
            }
            else
            {
                parent.Left = right;
            }

            right.Balance++;
            node.Balance = -right.Balance;

            return right;
        }

        private AVLNode<K, V> RotateRight(AVLNode<K, V> node)
        {
            AVLNode<K, V> left = node.Left;
            AVLNode<K, V> leftRight = left.Right;
            AVLNode<K, V> parent = node.Parent;

            left.Parent = parent;
            left.Right = node;
            node.Left = leftRight;
            node.Parent = left;

            if (leftRight != null)
            {
                leftRight.Parent = node;
            }

            if (node == Root)
            {
                Root = left;
            }
            else if (parent.Left == node)
            {
                parent.Left = left;
            }
            else
            {
                parent.Right = left;
            }

            left.Balance--;
            node.Balance = -left.Balance;

            return left;
        }

        private AVLNode<K, V> RotateLeftRight(AVLNode<K, V> node)
        {
            AVLNode<K, V> left = node.Left;
            AVLNode<K, V> leftRight = left.Right;
            AVLNode<K, V> parent = node.Parent;
            AVLNode<K, V> leftRightRight = leftRight.Right;
            AVLNode<K, V> leftRightLeft = leftRight.Left;

            leftRight.Parent = parent;
            node.Left = leftRightRight;
            left.Right = leftRightLeft;
            leftRight.Left = left;
            leftRight.Right = node;
            left.Parent = leftRight;
            node.Parent = leftRight;

            if (leftRightRight != null)
            {
                leftRightRight.Parent = node;
            }

            if (leftRightLeft != null)
            {
                leftRightLeft.Parent = left;
            }

            if (node == Root)
            {
                Root = leftRight;
            }
            else if (parent.Left == node)
            {
                parent.Left = leftRight;
            }
            else
            {
                parent.Right = leftRight;
            }

            if (leftRight.Balance == -1)
            {
                node.Balance = 0;
                left.Balance = 1;
            }
            else if (leftRight.Balance == 0)
            {
                node.Balance = 0;
                left.Balance = 0;
            }
            else
            {
                node.Balance = -1;
                left.Balance = 0;
            }

            leftRight.Balance = 0;

            return leftRight;
        }

        private AVLNode<K, V> RotateRightLeft(AVLNode<K, V> node)
        {
            AVLNode<K, V> right = node.Right;
            AVLNode<K, V> rightLeft = right.Left;
            AVLNode<K, V> parent = node.Parent;
            AVLNode<K, V> rightLeftLeft = rightLeft.Left;
            AVLNode<K, V> rightLeftRight = rightLeft.Right;

            rightLeft.Parent = parent;
            node.Right = rightLeftLeft;
            right.Left = rightLeftRight;
            rightLeft.Right = right;
            rightLeft.Left = node;
            right.Parent = rightLeft;
            node.Parent = rightLeft;

            if (rightLeftLeft != null)
            {
                rightLeftLeft.Parent = node;
            }

            if (rightLeftRight != null)
            {
                rightLeftRight.Parent = right;
            }

            if (node == Root)
            {
                Root = rightLeft;
            }
            else if (parent.Right == node)
            {
                parent.Right = rightLeft;
            }
            else
            {
                parent.Left = rightLeft;
            }

            if (rightLeft.Balance == 1)
            {
                node.Balance = 0;
                right.Balance = -1;
            }
            else if (rightLeft.Balance == 0)
            {
                node.Balance = 0;
                right.Balance = 0;
            }
            else
            {
                node.Balance = 1;
                right.Balance = 0;
            }

            rightLeft.Balance = 0;

            return rightLeft;
        }
        /*
         * Deletion
         * When a node is deleted from an AVL tree, it must be removed correctly
         * to make sure the tree remains ordered. The logic to delete a node is
         * somewhat harder to implement than the code for insertion and I 
         * struggled for a while to understand the AVL algorithm sufficiently 
         * so that I could not only code the delete portion of the tree, but 
         * also ensure it was optimal.
         * 
         * My implementation of delete considers each edge case separately so 
         * that no unnecessary operations are performed.
         */
        public bool Remove(K key)
        {
            AVLNode<K, V> node = Root;

            while (node != null)
            {
                int compare = key.CompareTo(node.Key);
                if (compare < 0)
                {
                    node = node.Left;
                }
                else if (compare > 0)
                {
                    node = node.Right;
                }
                else
                {
                    var left = node.Left;
                    var right = node.Right;

                    if (left == null)
                    {
                        if (right == null)
                        {
                            if (node == Root)
                            {
                                Root = null;
                            }
                            else
                            {
                                var parent = node.Parent;

                                if (parent.Left == node)
                                {
                                    parent.Left = null;
                                    DeleteBalance(parent, -1);
                                }
                                else
                                {
                                    parent.Right = null;
                                    DeleteBalance(parent, 1);
                                }
                            }
                        }
                        else
                        {
                            Replace(node, right);
                            DeleteBalance(node, 0);
                        }
                    }
                    else if (right == null)
                    {
                        Replace(node, left);
                        DeleteBalance(node, 0);
                    }
                    else
                    {
                        AVLNode<K, V> successor = right;

                        if (successor.Left == null)
                        {
                            AVLNode<K, V> parent = node.Parent;

                            successor.Parent = parent;
                            successor.Left = left;
                            successor.Balance = node.Balance;

                            if (left != null)
                            {
                                left.Parent = successor;
                            }

                            if (node == Root)
                            {
                                Root = successor;
                            }
                            else
                            {
                                if (parent.Left == node)
                                {
                                    parent.Left = successor;
                                }
                                else
                                {
                                    parent.Right = successor;
                                }
                            }

                            DeleteBalance(successor, 1);
                        }
                        else
                        {
                            while (successor.Left != null)
                            {
                                successor = successor.Left;
                            }

                            AVLNode<K, V> parent = node.Parent;
                            AVLNode<K, V> successorParent = successor.Parent;
                            AVLNode<K, V> successorRight = successor.Right;

                            if (successorParent.Left == successor)
                            {
                                successorParent.Left = successorRight;
                            }
                            else
                            {
                                successorParent.Right = successorRight;
                            }

                            if (successorRight != null)
                            {
                                successorRight.Parent = successorParent;
                            }

                            successor.Parent = parent;
                            successor.Left = left;
                            successor.Balance = node.Balance;
                            successor.Right = right;
                            right.Parent = successor;

                            if (left != null)
                            {
                                left.Parent = successor;
                            }

                            if (node == Root)
                            {
                                Root = successor;
                            }
                            else
                            {
                                if (parent.Left == node)
                                {
                                    parent.Left = successor;
                                }
                                else
                                {
                                    parent.Right = successor;
                                }
                            }

                            DeleteBalance(successorParent, -1);
                        }
                    }

                    return true;
                }
            }

            return false;
        }
        /*
         * Balancing after Deletion
         * The added complexity of rebalancing a deletion is the possibility of
         * more than a single rotation to restore the tree to balance.
         * 
         * There are several rules that allow the balancing for deletions to be optimised:
         *      - After a right rotation, the node will have a balance of 0 or -1
         *      - After a left rotation, the node will have a balance of 0 or 1
         *      - After a left-right or right-left rotation, the node will have a balance of 0
         *      - If a node’s balance is 1 or -1 you can stop traversing back up the tree
         * 
         * It follows that you must continue traversing and rebalancing up the 
         * tree even after a rotation unless the last rule is met which is why 
         * we can end up with more than one rotation during a deletion.
         * 
         * Although deletion has many edge cases, the balancing portion of the 
         * code is similar in complexity to insertion, however it is different 
         * (note that I have heavily optimised the code so that no unnecessary 
         * operations are performed, for instance after a rotate right, I only 
         * need to check for a balance of -1 to quit rebalancing as the 1 case 
         * cannot occur due to the rules above):
         */
        private void DeleteBalance(AVLNode<K, V> node, int balance)
        {
            while (node != null)
            {
                balance = (node.Balance += balance);

                if (balance == 2)
                {
                    if (node.Left.Balance >= 0)
                    {
                        node = RotateRight(node);
                        if (node.Balance == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        node = RotateLeftRight(node);
                    }
                }
                else if (balance == -2)
                {
                    if (node.Right.Balance <= 0)
                    {
                        node = RotateLeft(node);
                        if (node.Balance == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        node = RotateRightLeft(node);
                    }
                }
                else if (balance != 0)
                {
                    return;
                }

                var parent = node.Parent;

                if (parent != null)
                {
                    balance = parent.Left == node ? -1 : 1;
                }

                node = parent;
            }
        }

        private static void Replace(AVLNode<K, V> target, AVLNode<K, V> source)
        {
            var left = source.Left;
            var right = source.Right;

            target.Balance = source.Balance;
            target.Key = source.Key;
            target.Value = source.Value;
            target.Left = left;
            target.Right = right;

            if (left != null)
            {
                left.Parent = target;
            }

            if (right != null)
            {
                right.Parent = target;
            }
        }

        public void InOrder(AVLTreeVisitor<K, V> v)
        {
            InOrder(Root, v, 0);
        }

        public void InOrder(AVLNode<K, V> Subroot, AVLTreeVisitor<K, V> v, int level)
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
