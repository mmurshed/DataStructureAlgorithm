using System;
namespace Tree
{
    public class AVLTreeVisitor<K, V>
        where K: IComparable<K>
    {
        public void PreVisit(AVLNode<K, V> node, int level)
        {
            Console.Write("(");
        }

        public void Visit(AVLNode<K, V> node, int level)
        {
            var n = node as AVLNode<K, V>;
            Console.Write($"{level}:{node.Key}");
        }

        public void PostVisit(AVLNode<K, V> node, int level)
        {
            Console.Write(")");
        }
    }
}
