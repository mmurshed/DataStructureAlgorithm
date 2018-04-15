using System;
namespace Sorting
{
    public class BubbleSort<T> : SortBase<T>
        where T: IComparable<T>
    {
        public override void Sort(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j].CompareTo(data[j + 1]) > 0)
                        Swap(ref data[j], ref data[i]);
                }
            }
        }
    }
}
