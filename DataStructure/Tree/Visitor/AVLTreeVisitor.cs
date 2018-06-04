using System;
using System.Text;

namespace DataStructure.Tree
{
    public class AVLTreeVisitor<K, V>
        where K: IComparable<K>
    {
        StringBuilder stringBuilder;

        public string String => stringBuilder.ToString();

        public AVLTreeVisitor()
        {
            stringBuilder = new StringBuilder();
        }

        public void PreVisit(AVLNode<K, V> node, int level)
        {
            stringBuilder.Append('(');
        }

        public void Visit(AVLNode<K, V> node, int level)
        {
            var n = node as AVLNode<K, V>;
            stringBuilder.Append($"{level}:{node.Key}");
        }

        public void PostVisit(AVLNode<K, V> node, int level)
        {
            stringBuilder.Append(')');
        }
    }
}
