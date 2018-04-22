using System;
namespace Tree
{
    public enum BalanceFactor { RIGHT_HIGHER, EQUAL_HEIGHT, LEFT_HIGHER };

    public interface IAVLNodeV1<K, V>: ITreeNode<K, V>
        where K : IComparable<K>
    {
        BalanceFactor Balance { get; set; }

        IAVLNodeV1<K, V> Parent { get; set; }
        IAVLNodeV1<K, V> Left { get; set; }
        IAVLNodeV1<K, V> Right { get; set; }
    }
}
