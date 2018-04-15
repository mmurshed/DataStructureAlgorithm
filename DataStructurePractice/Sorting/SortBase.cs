using System;
namespace Sorting
{
    public abstract class SortBase<T> : ISort<T>
    {
        protected void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public abstract void Sort(T[] data);
    }
}
