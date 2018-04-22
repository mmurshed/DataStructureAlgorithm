using System;
namespace Tree
{
    public class AVLTreeVisitorV1<K, V>
        where K: IComparable<K>
    {
        public void PreVisit(IAVLNodeV1<K, V> node, int level)
        {
            Console.Write("(");
        }
        public void Visit(IAVLNodeV1<K, V> node, int level)
        {
            var n = node as IAVLNodeV1<K, V>;
            Console.Write($"{level}:{node.Key}");
        }
        public void PostVisit(IAVLNodeV1<K, V> node, int level)
        {
            Console.Write(")");
        }
    }
}
