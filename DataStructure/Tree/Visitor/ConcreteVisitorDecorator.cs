using System;

namespace DataStructure.Tree
{
    public class ConcreteVisitorDecorator<K, V> : VisitorDecorator<K, V>
        where K : IComparable<K>
    {
        public ConcreteVisitorDecorator(ITreeVisitor<K, V> component) : base(component) { }

        public override void Visit(ITreeNode<K, V> node)
        {
            Console.Write($"(");
            base.Visit(node);
            Console.Write($")");
        }
    }
}
