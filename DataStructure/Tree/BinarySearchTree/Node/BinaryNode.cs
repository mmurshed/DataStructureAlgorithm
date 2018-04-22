using System;

namespace DataStructure.Tree
{
    public class BinaryNode<K, V> : IBinaryNode<K, V>
        where K: IComparable<K>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public BinaryNode<K, V> LeftNode;
        public BinaryNode<K, V> RightNode;

        public IBinaryNode<K, V> Left
        {
            get
            {
                return LeftNode;
            }
            set
            {
                LeftNode = value as BinaryNode<K, V>;
            }
        }

        public IBinaryNode<K, V> Right
        {
            get
            {
                return RightNode;
            }
            set
            {
                RightNode = value as BinaryNode<K, V>;
            }
        }

        public BinaryNode()
            : this(default(K), default(V))
        {
            
        }

        public BinaryNode(K Key, V Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

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
