using System;
namespace Algorithm.Sort
{
    public class BubbleSortRecursive<T> : SortBase<T>
        where T: IComparable<T>
    {
        private void SortRecursive(T[] data, int n)
        {
            if (n <= 1)
                return;
            for (int j = 0; j < data.Length - 1; j++)
            {
                if (data[j].CompareTo(data[j + 1]) > 0)
                    Swap(ref data[j], ref data[j+1]);
            }
            SortRecursive(data, n - 1);
        }

        public override void Sort(T[] data)
        {
            SortRecursive(data, data.Length);
        }
    }
}
