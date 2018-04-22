using System;

namespace DataStructure.Tree
{
    public abstract class VisitorDecorator<K, V> : ITreeVisitor<K, V>
        where K : IComparable<K>
    {
        private ITreeVisitor<K, V> _component;

        public VisitorDecorator(ITreeVisitor<K, V> component)
        {
            _component = component;
        }

        public virtual void Visit(ITreeNode<K, V> node)
        {
            _component.Visit(node);
        }
    }
}
