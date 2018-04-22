using System;

namespace DataStructure.Set
{
	public class HashSet<T> : ISet<T>
	{
		public HashSet()
		{
		}

		public void Add(T item)
		{
		}

		public void Remove(T item)
		{
		}

		public bool Exists(T item)
		{
			return true;
		}

		public ISet<T> Union(ISet<T> set)
		{
			var unionSet = new HashSet<T>();

			return unionSet;
		}

		public ISet<T> Intersect(ISet<T> set)
		{
			var intersectSet = new HashSet<T>();

			return intersectSet;
		}

		public ISet<T> Difference(ISet<T> set)
		{
			var differenceSet = new HashSet<T>();

			return differenceSet;
		}
	}
}
