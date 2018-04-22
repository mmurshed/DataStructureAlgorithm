using System;

namespace DataStructure.Set
{
	public class BitSet : ISet<int>
	{
		private Vector.BitVector vector;

		public BitSet(int capacity)
		{
			vector = new Vector.BitVector(capacity);
		}

		public void Add(int item)
		{
			vector.Set(item);
		}

		public void Remove(int item)
		{
			vector.Unset(item);
		}

		public bool Exists(int item)
		{
			return vector.Get(item);
		}

		public ISet<int> Union(ISet<int> set)
		{
			var bitSet = set as BitSet;
			int minSize = Math.Min(vector.Size, bitSet.vector.Size);
			int maxSize = Math.Max(vector.Size, bitSet.vector.Size);
			var unionSet = new BitSet(maxSize);

			for (int i = 0; i < minSize; i++)
			{
				unionSet.vector.Vector[i] = vector.Vector[i] | bitSet.vector.Vector[i];
			}

			var largerSet = vector.Size > bitSet.vector.Size ? this : bitSet;

			for (int i = minSize; i < maxSize; i++)
			{
				unionSet.vector.Vector[i] = largerSet.vector.Vector[i];
			}
			return unionSet;
		}

		public ISet<int> Intersect(ISet<int> set)
		{
			var bitSet = set as BitSet;
			int minSize = Math.Min(vector.Size, bitSet.vector.Size);
			var intersectSet = new BitSet(minSize);

			for (int i = 0; i < minSize; i++)
			{
				intersectSet.vector.Vector[i] = vector.Vector[i] & bitSet.vector.Vector[i];
			}

			return intersectSet;
		}

		public ISet<int> Difference(ISet<int> set)
		{
			var bitSet = set as BitSet;
			int minSize = Math.Min(vector.Size, bitSet.vector.Size);
			var differenceSet = new BitSet(vector.Size);

			for (int i = 0; i < minSize; i++)
			{
				differenceSet.vector.Vector[i] = vector.Vector[i] & ~bitSet.vector.Vector[i];
			}

			if (vector.Size > bitSet.vector.Size)
			{
				for (int i = minSize; i < vector.Size; i++)
				{
					differenceSet.vector.Vector[i] = vector.Vector[i];
				}
			}
			return differenceSet;
		}
	}
}
