using System;
namespace DataStructure.Tree
{
    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public char Code;
        public int Value;
        public HuffmanNode Left;
        public HuffmanNode Right;
        public string HuffmanCode;

        public HuffmanNode(char code, int value)
        {
            this.Code = code;
            this.Value = value;
        }

        public int CompareTo(HuffmanNode other)
        {
            return Value - other.Value;
        }

        public override bool Equals(object obj)
        {
            var objn = obj as HuffmanNode;
            return Value.Equals(objn.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
