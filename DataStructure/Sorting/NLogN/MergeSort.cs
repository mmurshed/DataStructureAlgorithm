using System;
namespace Sorting
{
    public class MergeSort<T> : SortBase<T>
        where T: IComparable<T>
    {
        public static void Merge(T[] data, int left, int mid, int right)
        {
            T[] leftData = new T[mid - left + 1];
            T[] rightData = new T[right - mid + 1];
            for (int i = left; i <= mid; i++)
                leftData[i - left] = data[i];
            for (int i = mid+1; i <= right; i++)
                rightData[i - mid - 1] = data[i];

            int j = left;
            int l = left;
            int r = mid;
            while(j <= right)
            {
                if (leftData[l].CompareTo(rightData[r]) < 0)
                {
                    data[j] = leftData[l];
                    l++;
                }
                else
                {
                    data[j] = rightData[r];
                    r++;
                }
                j++;
            }
        }

        private void Sort(T[] data, int left, int right)
        {
            if(left < right)
            {
                int mid = (left + right) / 2;
                Sort(data, left, mid);
                Sort(data, mid+1, right);
                Merge(data, left, mid, right);
            }
        }
        public override void Sort(T[] data)
        {
            Sort(data, 0, data.Length);
        }
    }
}
