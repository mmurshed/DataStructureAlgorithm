using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Queue
{
	public class MaxHeapSimple
	{
		private List<int> data = new List<int>();

		public int Top => data[0];
		public int Count => data.Count;

		private void Swap(int i, int j)
		{
			int tmp = data[i];
			data[i] = data[j];
			data[j] = tmp;
		}

		private int Parent(int i) => (i + 1) / 2 - 1;
		private int Left(int i) => 2 * (i + 1) - 1;
		private int Right(int i) => 2 * (i + 1);

		public void Insert(int o)
		{
			data.Add(o);
			int i = data.Count - 1;
			while (i > 0)
			{
				int parent = Parent(i);
				if (data[parent] >= data[i])
				{
					break;
				}
				Swap(i, parent);
				i = parent;
			}
		}

		public int Extract()
		{
			if (data.Count < 0)
			{
				throw new ArgumentOutOfRangeException();
			}

			int top = data[0];
			data[0] = data[data.Count - 1];
			data.RemoveAt(data.Count - 1);
			Heapify(0);
			return top;
		}

		public int Extract(int val, int i)
		{
			if (data.Count < i)
			{
				return Int32.MinValue;
			}

			int top = data[i];
			if (top == val)
			{
				data[i] = data[data.Count - 1];
				data.RemoveAt(data.Count - 1);
				Heapify(i);
			}
			else
			{
				int retValue = Extract(val, Left(i));
				if(retValue == Int32.MinValue)
					retValue = Extract(val, Right(i));
				return retValue;
			}
			return top;
		}

		private void Heapify(int i)
		{
			int largest;
			int left = Left(i);
			int right = Right(i);

			largest = left < data.Count && data[left] > data[i] ? left : i;
			largest = right < data.Count && data[right] > data[largest] ? right : largest;

			if (largest != i)
			{
				Swap(i, largest);
				this.Heapify(largest);
			}
		}
	}
}
