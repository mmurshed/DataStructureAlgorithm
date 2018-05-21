using System;
namespace DataStructure.Tree.QuadTree
{
    public class QuadTree<T> : IQuadTree<T>
    {
        public QuadNode<T> Root { get; private set; }

        public int Resolution { get; private set; }

        public QuadTree(Point topLeft, Point botRight, int res = 1)
        {
            Resolution = res;
            Root = new QuadNode<T>(topLeft, botRight);
        }

        public bool Insert(QuadNode<T> subroot, Point point, T val)
        {
            if (subroot == null)
                return false;

            if (!subroot.WithinBoundary(point))
                return false;

            if(!subroot.CanSubdivide(Resolution))
            {
                // Add the node
                subroot.Value = val;
                return true;
            }

            return Insert(subroot.Insert(point), point, val);
        }

        public T Find(QuadNode<T> subroot, Point point)
        {
            if (subroot == null)
                return default(T);

            if (!subroot.WithinBoundary(point))
                return default(T);

            if (!subroot.CanSubdivide(Resolution))
            {
                return subroot.Value;
            }

            var child = subroot.GetChild(point);
            if(child == null)
                return default(T);

            return Find(child, point);
        }
    }
}
