using System;
namespace DataStructure.Tree.AVLTreeV1
{
    public class AVLTreeVisitor<K, V>
        where K: IComparable<K>
    {
        public void PreVisit(IAVLNode<K, V> node, int level)
        {
            Console.Write("(");
        }
        public void Visit(IAVLNode<K, V> node, int level)
        {
            var n = node as IAVLNode<K, V>;
            Console.Write($"{level}:{node.Key}");
        }
        public void PostVisit(IAVLNode<K, V> node, int level)
        {
            Console.Write(")");
        }
    }
}
