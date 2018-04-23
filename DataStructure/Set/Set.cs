using System;

namespace DataStructure.Set
{
	/*
Bloom filters – We can emulate a bit vector in the absence of a fixed universal 
set by hashing each subset element to an integer from 0 to n and setting the
corresponding bit. Thus, bit H(e) will be 1 if e ∈ S. Collisons leave some
possibility for error under this scheme, however, because a different key might
have hashed to the same position.

Bloom filters use several (say k) different hash functions H1, . . . Hk, and set
all k bits Hi(e) upon insertion of key e. Now e is in S only if all k bits
are 1. The probability of false positives can be made arbitrarily low by increasing
the number of hash functions k and table size n. With the proper
constants, each subset element can be represented using a constant number
of bits independent of the size of the universal set.

This hashing-based data structure is much more space-efficient than dictionaries
for static subset applications that can tolerate a small probability of
error. Many can. For instance, a spelling checker that left a rare random
string undetected would prove no great tragedy.
	 */
	public class Set<T> : ISet<T>
	{
		private Vector.BitVector vector;
		private int HashCount;
		private Func<T, int, int> Hash;

		public Set(int capacity, int hashCount, Func<T, int, int> hash)
		{
			vector = new Vector.BitVector(capacity);
			HashCount = hashCount;
			Hash = hash;
		}

		public void Add(T item)
		{
			for (int i = 0; i < HashCount; i++)
			{
				int location = Hash(item, i) % vector.Size;
				if (!vector.Get(location))
				{
					vector.Set(location);
					break;
				}
			}
		}

		public void Remove(T item)
		{
			throw new NotSupportedException("Remove from this set is not supported");
		}

		public bool Exists(T item)
		{
			int location = Hash(item, 0) % vector.Size;
			return vector.Get(location);
		}

		public ISet<T> Union(ISet<T> set)
		{
			var bitSet = set as Set<T>;
			int minSize = Math.Min(vector.Size, bitSet.vector.Size);
			int maxSize = Math.Max(vector.Size, bitSet.vector.Size);
			var unionSet = new Set<T>(maxSize, HashCount, Hash);

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

		public ISet<T> Intersect(ISet<T> set)
		{
			var bitSet = set as Set<T>;
			int minSize = Math.Min(vector.Size, bitSet.vector.Size);
			var intersectSet = new Set<T>(minSize, HashCount, Hash);

			for (int i = 0; i < minSize; i++)
			{
				intersectSet.vector.Vector[i] = vector.Vector[i] & bitSet.vector.Vector[i];
			}

			return intersectSet;
		}

		public ISet<T> Difference(ISet<T> set)
		{
			var bitSet = set as Set<T>;
			int minSize = Math.Min(vector.Size, bitSet.vector.Size);
			var differenceSet = new Set<T>(vector.Size, HashCount, Hash);

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
