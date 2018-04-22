using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    public class MinComparer<T> : IComparer<T>
        where T: IComparable
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }

    public class MaxComparer<T> : IComparer<T>
        where T : IComparable
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }

	public class PriorityQueue<T>
	{
		private List<T> data = new List<T>();

        private readonly Comparison<T> Compare;

        public PriorityQueue(Comparison<T> compare)
        {
            this.Compare = compare;
        }

        public PriorityQueue(IComparer<T> comparer) : this(comparer.Compare)
        {
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

        public bool Empty => data.Count == 0;
	}
}
