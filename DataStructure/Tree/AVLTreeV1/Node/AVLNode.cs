using System;

namespace DataStructure.Tree.AVLTreeV1
{
    public class AVLNode<K, V> : IAVLNode<K, V>
        where K : IComparable<K>
    {
        public BalanceFactor Balance { get; set; }

        public K Key { get; set; }
        public V Value { get; set; }

        public AVLNode<K, V> ParentNode;
        public AVLNode<K, V> LeftNode;
        public AVLNode<K, V> RightNode;

        public IAVLNode<K, V> Parent
        {
            get
            {
                return ParentNode;
            }
            set
            {
                ParentNode = value as AVLNode<K, V>;
            }
        }


        public IAVLNode<K, V> Left
        {
            get
            {
                return LeftNode;
            }
            set
            {
                LeftNode = value as AVLNode<K, V>;
            }
        }

        public IAVLNode<K, V> Right
        {
            get
            {
                return RightNode;
            }
            set
            {
                RightNode = value as AVLNode<K, V>;
            }
        }

        public AVLNode(K Key, V Value)
        {
            this.Key = Key;
            this.Value = Value;
            this.Balance = BalanceFactor.EQUAL_HEIGHT;
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
