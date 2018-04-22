using System;

namespace DataStructure.Tree
{
    public class Visitor<K, V> : ITreeVisitor<K, V>
        where K : IComparable<K>
    {
        public void Visit(ITreeNode<K, V> node)
        {
            Console.Write($"{node.Key}");
        }
    }
}
