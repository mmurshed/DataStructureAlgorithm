using System;

namespace DataStructure.Tree.AVLTreeV1
{
    public class AVLNodeV1<K, V> : IAVLNodeV1<K, V>
        where K : IComparable<K>
    {
        public BalanceFactor Balance { get; set; }

        public K Key { get; set; }
        public V Value { get; set; }

        public AVLNodeV1<K, V> ParentNode;
        public AVLNodeV1<K, V> LeftNode;
        public AVLNodeV1<K, V> RightNode;

        public IAVLNodeV1<K, V> Parent
        {
            get
            {
                return ParentNode;
            }
            set
            {
                ParentNode = value as AVLNodeV1<K, V>;
            }
        }


        public IAVLNodeV1<K, V> Left
        {
            get
            {
                return LeftNode;
            }
            set
            {
                LeftNode = value as AVLNodeV1<K, V>;
            }
        }

        public IAVLNodeV1<K, V> Right
        {
            get
            {
                return RightNode;
            }
            set
            {
                RightNode = value as AVLNodeV1<K, V>;
            }
        }

        public AVLNodeV1(K Key, V Value)
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
