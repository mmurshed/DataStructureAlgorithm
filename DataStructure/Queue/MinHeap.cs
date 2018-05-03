using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Queue
{
	public class MinHeap<T> where T : IComparable
	{
		private List<T> data = new List<T>();

		private void Swap(int i, int j)
		{
			T tmp = data[i];
			data[i] = data[j];
			data[j] = tmp;
		}

		private int Parent(int i)
		{
			return (i + 1) / 2 - 1;
		}

		private int Left(int i)
		{
			return 2 * (i + 1) - 1;
		}

		private int Right(int i)
		{
			return 2 * (i + 1);
		}

		public void Insert(T o)
		{
			data.Add(o);

			int i = data.Count - 1;
			while (i > 0)
			{
				int parent = Parent(i);
				T val = data[parent];
				if (val.CompareTo(data[i]) <= 0)
				{
					break;
				}
				Swap(i, parent);
				i = parent;
			}
		}

		public T Extract()
		{
			if (data.Count < 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			T min = data[0];
			data[0] = data[data.Count - 1];
			data.RemoveAt(data.Count - 1);
			this.Heapify(0);
			return min;
		}

		public T Peek()
		{
			return data[0];
		}

		public int Count => data.Count;

		private void Heapify(int i)
		{
			int smallest;
			int left = Left(i);
			int right = Right(i);

			if (left < data.Count && data[left].CompareTo(data[i]) < 0)
			{
				smallest = left;
			}
			else
			{
				smallest = i;
			}

			if (right < data.Count && data[right].CompareTo(data[smallest]) < 0)
			{
				smallest = right;
			}

			if (smallest != i)
			{
				Swap(i, smallest);
				this.Heapify(smallest);
			}
		}
	}
}
