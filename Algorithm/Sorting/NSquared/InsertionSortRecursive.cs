using System;
namespace DataStructure.Sort
{
    public class InsertionSortRecursive<T> : SortBase<T>
        where T: IComparable<T>
    {
        private void SortRecursive(T[] data, int n)
        {
            if (n <= 1)
                return;
            SortRecursive(data, n - 1);
            T key = data[n-1];
            int j = n - 2;
            while (j >= 0 && data[j].CompareTo(key) > 0)
            {
                data[j + 1] = data[j];
                j--;
            }
            data[j - 1] = key;

        }

        public override void Sort(T[] data)
        {
            SortRecursive(data, data.Length);
        }
    }
}
