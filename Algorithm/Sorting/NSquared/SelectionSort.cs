using System;
namespace Algorithm.Sort
{
    public class SelectionSort<T> : SortBase<T>
        where T: IComparable<T>
    {
        private int FindMin(T[] data, int start)
        {
            int min_idx = start;

            for (int i = start + 1; i < data.Length; i++)
            {
                if (data[i].CompareTo(data[min_idx]) < 0)
                    min_idx = i;
            }
            return min_idx;
        }

        public override void Sort(T[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                int min_idx = FindMin(data, i);
                Swap(ref data[min_idx], ref data[i]);
            }
        }
    }
}
