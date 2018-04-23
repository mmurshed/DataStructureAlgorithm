using System;

namespace DataStructure.Tree
{
    public class AVLNode<K, V>: IComparable<ITreeNode<K, V>>, IEquatable<ITreeNode<K, V>>
        where K : IComparable<K>
    {
        public int Balance;
        public K Key;
        public V Value;
        public AVLNode<K, V> Parent;
        public AVLNode<K, V> Left;
        public AVLNode<K, V> Right;

        public AVLNode(K Key, V Value, AVLNode<K, V> Parent, int Balance)
        {
            this.Key = Key;
            this.Value = Value;
            this.Balance = Balance;
            this.Parent = Parent;
        }

        public AVLNode(K Key, V Value, AVLNode<K, V> Parent)
            : this(Key, Value, Parent, default(int))
        {}
        public AVLNode(K Key, V Value)
            : this(Key, Value, null, default(int))
        {}

        // IComparable
        public int CompareTo(ITreeNode<K, V> other)
        {
            return Key.CompareTo(other.Key);
        }

        // IEquatable
        public bool Equals(ITreeNode<K, V> other)
        {
            return CompareTo(other) == 0;
        }

        // Object override
        public override bool Equals(object obj)
        {
            return Equals(obj as ITreeNode<K, V>);
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return $"[BinaryNode: Key={Key}, Value={Value}]";
        }
    }
}
