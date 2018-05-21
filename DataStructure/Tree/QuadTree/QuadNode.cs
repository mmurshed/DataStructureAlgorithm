using System;
namespace DataStructure.Tree.QuadTree
{
    public class QuadNode<T>
    {
        public T Value;

        public Point[] Boundary { get; private set; }

        public QuadNode<T>[,] Children { get; set; }

        public QuadNode(Point topLeft, Point botRight) 
        {
            Children = new QuadNode<T>[2, 2];

            Boundary = new Point[2];
            Boundary[0] = topLeft;
            Boundary[1] = botRight;
        }

        public QuadNode(Point topLeft, Point botRight, T val) : this (topLeft, botRight)
        {
            this.Value = val;
        }

        public bool WithinBoundary(Point point)
        {
            return
               point.X >= Boundary[0].X &&
               point.X <= Boundary[1].X &&
               point.Y >= Boundary[0].Y &&
               point.Y <= Boundary[1].Y;
        }

        public bool CanSubdivide(int resolution)
        {
            return
                Math.Abs(Boundary[0].X - Boundary[1].X) > resolution &&
                Math.Abs(Boundary[0].Y - Boundary[1].Y) > resolution;
        }

        private bool LeftX(Point point)
        {
            return (Boundary[0].X + Boundary[1].X) / 2 >= point.X;
        }

        private bool TopY(Point point)
        {
            return (Boundary[0].Y + Boundary[1].Y) / 2 >= point.Y;
        }


        private Point GetMiddle()
        {
            return new Point(
                (Boundary[0].X + Boundary[1].X) / 2,
                (Boundary[0].Y + Boundary[1].Y) / 2);
        }

        //private Tuple<int, int> GetChildrenLocation(Point point)
        //{
        //    bool leftx = LeftX(point);
        //    bool topy = TopY(point);

        //    int ix = leftx ? 0 : 1;
        //    int iy = topy ? 0 : 1;

        //    return new Tuple<int, int>(ix, iy);
        //}

        public QuadNode<T> Insert(Point point)
        {
            bool leftx = LeftX(point);
            bool topy = TopY(point);

            int ix = leftx ? 0 : 1;
            int iy = topy ? 0 : 1;

            if (Children[ix, iy] != null)
                return Children[ix, iy];

            Point p1;
            Point p2;

            var middle = GetMiddle();

            if (leftx && topy)
            {
                p1 = Boundary[0];
                p2 = middle;
            }
            else if (leftx && !topy)
            {
                p1 = new Point(Boundary[0].X, middle.Y);
                p2 = new Point(middle.X, Boundary[1].Y);
            }
            else if (!leftx && topy)
            {
                p1 = new Point(middle.X, Boundary[0].Y);
                p2 = new Point(Boundary[1].X, middle.Y);
            }
            else
            {
                p1 = middle;
                p2 = Boundary[1];
            }

            Children[ix, iy] = new QuadNode<T>(p1, p2);

            return Children[ix, iy];
        }

        public QuadNode<T> GetChild(Point point)
        {
            bool leftx = LeftX(point);
            bool topy = TopY(point);

            int ix = leftx ? 0 : 1;
            int iy = topy ? 0 : 1;
            return Children[ix, iy];
        }
    }
}
