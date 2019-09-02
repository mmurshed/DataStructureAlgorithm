using System;
namespace Algorithm.Sort
{
    public class InsertionSortGeneralized<T>
        where T: IComparable<T>
    {
        public static void Sort(T[] data, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                T key = data[i];
                int j = i - 1;
                while(j >= left && data[j].CompareTo(key) > 0)
                {
                    data[j + 1] = data[j];
                    j--;
                }
                data[j + 1] = key;
            }
        }
    }
}
