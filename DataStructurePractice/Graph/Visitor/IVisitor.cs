using System;

namespace Graph
{
    public interface IVisitor<T>
    {
        void PreVisit(T value);
        void Visit(T value);
        void PostVisit(T value);
    }
}
