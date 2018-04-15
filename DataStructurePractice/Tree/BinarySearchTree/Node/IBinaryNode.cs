using System;
namespace Tree
{
    public interface IBinaryNode<K, V>: ITreeNode<K, V>
        where K : IComparable<K>
    {
        IBinaryNode<K, V> Left { get; set; }
        IBinaryNode<K, V> Right { get; set; }
    }
}
