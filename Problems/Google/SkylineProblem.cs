using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.GoogleProblems
{
    /*
     * https://briangordon.github.io/2014/08/the-skyline-problem.html
     * 
     * Critical Point: The X-cordinate of the beginning or end of a rectangle
     * 
A city's skyline is the outer contour of the silhouette formed by all the buildings in that city when viewed from a distance. Now suppose you are given the locations and height of all the buildings as shown on a cityscape photo (Figure A), write a program to output the skyline formed by these buildings collectively (Figure B).

 Buildings  Skyline Contour
The geometric information of each building is represented by a triplet of integers [Li, Ri, Hi], where Li and Ri are the x coordinates of the left and right edge of the ith building, respectively, and Hi is its height. It is guaranteed that 0 ≤ Li, Ri ≤ INT_MAX, 0 < Hi ≤ INT_MAX, and Ri - Li > 0. You may assume all buildings are perfect rectangles grounded on an absolutely flat surface at height 0.

For instance, the dimensions of all buildings in Figure A are recorded as: [ [2 9 10], [3 7 15], [5 12 12], [15 20 10], [19 24 8] ] .

The output is a list of "key points" (red dots in Figure B) in the format of [ [x1,y1], [x2, y2], [x3, y3], ... ] that uniquely defines a skyline. A key point is the left endpoint of a horizontal line segment. Note that the last key point, where the rightmost building ends, is merely used to mark the termination of the skyline, and always has zero height. Also, the ground in between any two adjacent buildings should be considered part of the skyline contour.

For instance, the skyline in Figure B should be represented as:[ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].

Notes:

The number of buildings in any input list is guaranteed to be in the range [0, 10000].
The input list is already sorted in ascending order by the left x position Li.
The output list must be sorted by the x position.
There must be no consecutive horizontal lines of equal height in the output skyline. For instance, [...[2 3], [4 5], [7 5], [11 5], [12 7]...] is not acceptable; the three lines of height 5 should be merged into one in the final output as such: [...[2 3], [4 5], [12 7], ...]
    */
    public class SkylineProblem
    {
        public class PriorityQueue<T>
        {
            private List<T> data = new List<T>();

            private readonly Comparison<T> Compare;

            public PriorityQueue(Comparison<T> compare)
            {
                this.Compare = compare;
            }

            public PriorityQueue() : this(Comparer<T>.Default.Compare)
            {
            }

            private void Swap(int i, int j)
            {
                T tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;
            }

            public T Top => data[0];
            public int Count => data.Count;

            private int Parent(int i) => (i + 1) / 2 - 1;
            private int Left(int i) => 2 * (i + 1) - 1;
            private int Right(int i) => 2 * (i + 1);

            public void Enqueue(T obj)
            {
                data.Add(obj);

                int i = Count - 1;
                while (i > 0)
                {
                    int parent = Parent(i);
                    T val = data[parent];

                    if (Compare(val, data[i]) <= 0)
                    {
                        break;
                    }
                    Swap(i, parent);
                    i = parent;
                }
            }

            public T Dequeue()
            {
                if (Count < 0)
                {
                    return default(T);
                    // throw new ArgumentOutOfRangeException();
                }

                T min = data[0];
                data[0] = data[data.Count - 1];
                data.RemoveAt(data.Count - 1);
                this.Heapify(0);
                return min;
            }

            private void Heapify(int i)
            {
                int current = i;
                int left = Left(i);
                int right = Right(i);

                if (left < data.Count && Compare(data[left], data[current]) < 0)
                {
                    current = left;
                }

                if (right < data.Count && Compare(data[right], data[current]) < 0)
                {
                    current = right;
                }

                if (current != i)
                {
                    Swap(i, current);
                    this.Heapify(current);
                }
            }
        }

        private class Rectangle
        {
            public int start;
            public int end;
            public int height;
            public bool active;

            public Rectangle(int s, int e, int h, bool a)
            {
                start = s;
                end = e;
                height = h;
                active = a;
            }
        }

        private class CriticalPoint : IComparable<CriticalPoint>
        {
            public int point;
            public Rectangle rectangle;
            public bool start;
            public CriticalPoint(int p, Rectangle r, bool s)
            {
                point = p;
                rectangle = r;
                start = s;
            }

            public int CompareTo(CriticalPoint y)
            {
                int comp = point - y.point;
                if (comp == 0 && start != y.start)
                    comp = y.start ? 1 : -1;
                return comp;           
            }
        }

        public IList<int[]> GetSkyline(int[,] buildings)
        {
            int n = buildings.GetLength(0);
            var rec = new Rectangle[n];
            var cp = new CriticalPoint[2 * n];

            for (int i = 0, j = 0; i < n; i++, j+=2)
            {
                rec[i] = new Rectangle(buildings[i, 0], buildings[i, 1], buildings[i, 2], false);
                cp[j] = new CriticalPoint(buildings[i, 0], rec[i], true);
                cp[j+1] = new CriticalPoint(buildings[i, 1], rec[i], false);
            }

            Array.Sort(cp);

            List<int[]> skyline = new List<int[]>();
            var pq = new PriorityQueue<Rectangle>((x, y) => y.height - x.height);
            for (int i = 0; i < cp.Length; i++)
            {
                do
                {
                    cp[i].rectangle.active = cp[i].start;

                    if (cp[i].start)
                    {
                        pq.Enqueue(cp[i].rectangle);
                    }

                    if (i < cp.Length - 1 && cp[i].point == cp[i + 1].point)
                        i++;
                } while (i < cp.Length - 1 && cp[i].point == cp[i + 1].point);

                while (pq.Count > 0 && !pq.Top.active)
                    pq.Dequeue();

                if (pq.Count > 0)
                {
                    if (cp[i].rectangle.end == pq.Top.start)
                    {
                        if (cp[i].rectangle.height != cp[i + 1].rectangle.height)
                        {

                        }
                    }

                    if (cp[i].rectangle.height >= pq.Top.height)
                        skyline.Add(new int[] { cp[i].point, pq.Top.height });
                }
                else
                {
                    skyline.Add(new int[] { cp[i].point, 0 });
                }
            }

            return skyline;
        }
    }
}
