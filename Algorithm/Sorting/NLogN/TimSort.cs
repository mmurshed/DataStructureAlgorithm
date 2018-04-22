using System;
namespace DataStructure.Sort
{
    public class TimSort<T> : SortBase<T>
        where T: IComparable<T>
    {
        private const int RUN = 32;
        public override void Sort(T[] data)
        {
            for (int i = 0; i < data.Length; i+=RUN)
            {
                int right = Math.Min(i + RUN - 1, data.Length - 1);
                InsertionSortGeneralized<T>.Sort(data, i, right);
            }

            for (int s = RUN; s < data.Length; s = 2 * s)
            {
                for (int left = 0; left < data.Length; left += 2 * s)
                {
                    int mid = left + s - 1;
                    int right = Math.Min(left + 2 * s - 1, data.Length - 1);
                    MergeSort<T>.Merge(data, left, mid, right);
                }
            }
        }
    }
}
