using System;
namespace DataStructure.Tree
{
    public class CartesianNode<T>
    {
        public T Data { get; }
        public CartesianNode<T> Left;
        public CartesianNode<T> Right;

        public CartesianNode(T data)
        {
            Data = data;
        }
    }
}
