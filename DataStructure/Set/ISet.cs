namespace DataStructure.Set
{
	public interface ISet<T>
	{
		void Add(T item);
		void Remove(T item);
		bool Exists(T item);

		ISet<T> Union(ISet<T> set);
		ISet<T> Intersect(ISet<T> set);
		ISet<T> Difference(ISet<T> set);
	}
}
