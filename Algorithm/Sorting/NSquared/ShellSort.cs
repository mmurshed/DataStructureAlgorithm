using System;
namespace DataStructure.Sort
{
    public class ShellSort<T> : SortBase<T>
        where T: IComparable<T>
    {
        public override void Sort(T[] data)
        {
            for (int gap = data.Length / 2; gap > 0; gap /= 2)
            {
                // Modified insertion sort
                for (int i = gap; i < data.Length; i++)
                {
                    T key = data[i];
                    int j = i;
                    while (j >= gap && data[j].CompareTo(key) > 0)
                    {
                        data[j] = data[j - gap];
                        j -= gap;
                    }
                    data[j] = key;
                }
            }
        }
    }
}
