using System;
using System.Collections.Generic;

namespace DataStructure.Queue
{
    public class PriorityQueue<T>
    {
        private readonly List<T> data;
        private readonly Comparison<T> Compare;

        public PriorityQueue(int n, Comparison<T> compare)
        {
            Compare = compare;
            data = new List<T>(n + 1) { default };
        }

        public PriorityQueue(Comparison<T> compare) : this(0, compare) {}
        public PriorityQueue(int n, IComparer<T> comparer) : this(n, comparer.Compare) {}
        public PriorityQueue(IComparer<T> comparer) : this(4, comparer.Compare) {}
        public PriorityQueue() : this(4, Comparer<T>.Default.Compare) {}
        public PriorityQueue(int n) : this(n, Comparer<T>.Default.Compare) {}

        private void Swap(int i, int j)
        {
            T tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
        }

        public int Count => data.Count - 1;
        public bool Empty => Count == 0;

        private int Parent(int i) => i / 2;
        private int Left(int i) => 2 * i;
        private int Right(int i) => 2 * i + 1;

        private bool Less(int i, int j) => Compare(data[i], data[j]) <= 0;

        public void Enqueue(T obj)
        {
            data.Add(obj);
            Swim(Count);
        }

        public T Peek()
        {
            if (Count < 1)
                return data[0];
            return data[1];
        }

        public T Dequeue()
        {
            if (Count < 1)
                return data[0];
            T top = data[1];
            Swap(1, Count);
            data.RemoveAt(Count);
            Sink(1);
            return top;
        }

        private void SinkRecursive(int i)
        {
            int current = i;
            int left = Left(i);
            int right = Right(i);

            if (left < Count && Compare(data[left], data[current]) < 0)
                current = left;

            if (right < Count && Compare(data[right], data[current]) < 0)
                current = right;

            if (current != i)
            {
                Swap(i, current);
                SinkRecursive(current);
            }
        }

        private void Swim(int i)
        {
            while (i > 1)
            {
                int parent = Parent(i);

                if (Less(parent, i))
                    break;

                Swap(parent, i);

                i = parent;
            }
        }

        // Search for right place top down
        private void Sink(int i)
        {
            if (i > Count)
                return;

            while (true)
            {
                int j = Left(i);

                if (j > Count)
                    break;

                // If left is less that right, take right
                if (j < Count && Less(j + 1, j))
                    j++;

                // If current value is less target - stop
                if (!Less(j, i))
                    break;

                Swap(i, j);

                // Go down
                i = j;
            }
        }
    }

    public class MinComparer<T> : IComparer<T>
        where T : IComparable
    {
        public int Compare(T x, T y) => x.CompareTo(y);
    }

    public class MaxComparer<T> : IComparer<T>
        where T : IComparable
    {
        public int Compare(T x, T y) => y.CompareTo(x);
    }
}
