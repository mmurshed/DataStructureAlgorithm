using System;
using System.Text;

namespace DataStructure.Tree
{
    public class StringVisitor<K, V> : ITreeVisitor<K, V>
        where K : IComparable<K>
    {
        StringBuilder stringBuilder;

        public string String => stringBuilder.ToString();

        public StringVisitor()
        {
            stringBuilder = new StringBuilder();
        }

        public void Visit(ITreeNode<K, V> node)
        {
            if (stringBuilder.Length > 0)
                stringBuilder.Append(',');
            stringBuilder.Append($"{node.Key}");
        }
    }
}
