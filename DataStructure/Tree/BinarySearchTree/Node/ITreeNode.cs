using System;
namespace DataStructure.Tree
{
    public interface ITreeNode<K, V>: IComparable<ITreeNode<K, V>>, IEquatable<ITreeNode<K, V>>
        where K: IComparable<K>
    {
        K Key { get; set; }
        V Value { get; set; }
    }
}
