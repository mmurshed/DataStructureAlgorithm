using System;
namespace DataStructure.Tree.AVLTreeV1
{
    public enum BalanceFactor { RIGHT_HIGHER, EQUAL_HEIGHT, LEFT_HIGHER };

    public interface IAVLNode<K, V>: ITreeNode<K, V>
        where K : IComparable<K>
    {
        BalanceFactor Balance { get; set; }

        IAVLNode<K, V> Parent { get; set; }
        IAVLNode<K, V> Left { get; set; }
        IAVLNode<K, V> Right { get; set; }
    }
}
