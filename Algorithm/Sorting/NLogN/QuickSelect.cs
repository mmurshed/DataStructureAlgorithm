using System;
namespace Algorithm.Sort
{
    /*
     * https://en.wikipedia.org/wiki/Quickselect
     *
     * This textbook algorthm has O(N) average time complexity. Like quicksort,
     * it was developed by Tony Hoare, and is also known as Hoare's selection algorithm.
     *
     * The approach is basically the same as for quicksort. For simplicity let's notice that
     * kth largest element is the same as N - kth smallest element, hence one could implement
     * kth smallest algorithm for this problem.
     *
     * First one chooses a pivot, and defines its position in a sorted array in a linear time.
     * This could be done with the help of partition algorithm.
     *
     * To implement partition one moves along an array, compares each element with a pivot,
     * and moves all elements smaller than pivot to the left of the pivot.
     * As an output we have an array where pivot is on its perfect position in the ascending
     * sorted array, all elements on the left of the pivot are smaller than pivot, and all
     * elements on the right of the pivot are larger or equal to pivot.
     *
     * Hence the array is now split into two parts. If that would be a quicksort algorithm,
     * one would proceed recursively to use quicksort for the both parts that would result in
     * O(NlogN) time complexity. Here there is no need to deal with both parts since now one
     * knows in which part to search for N - kth smallest element, and that reduces average time complexity to O(N).
     *
     * Finally the overall algorithm is quite straightforward :
     *
     * 1. Choose a random pivot.
     *
     * 2. Use a partition algorithm to place the pivot into its perfect position pos
     * in the sorted array, move smaller elements to the left of pivot, and
     * larger or equal ones - to the right.
     *
     * 3. Compare pos and N - k to choose the side of array to proceed recursively.
     *
     * Time complexity : O(N) in the average case, O(N^2) in the worst case.
     * Space complexity : O(1).
    */

    public class QuickSelect<T>
        where T: IComparable<T>
    {
        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private int Partition(T[] data, int left, int right)
        {
            int pi = left;
            T pivot = data[right];

            for (int j = left; j < right; j++)
            {
                // If data is less than pivot
                if (data[j].CompareTo(pivot) <= 0)
                {
                    Swap(ref data[j], ref data[pi]);
                    pi++;
                }
            }
            Swap(ref data[right], ref data[pi]);
            return pi;
        }

        // Returns the k-th smallest element of list within left..right.
        private T Select(T[] data, int left, int right, int k)
        {

            if (left == right) // If the list contains only one element,
                return data[left];  // return that element

            var pivot = Partition(data, left, right);

            // the pivot is on (N - k)th smallest position
            if (k == pivot)
                return data[k];            
            else if (k < pivot) // Search left
                return Select(data, left, pivot - 1, k);

            // Search right
            return Select(data, pivot + 1, right, k);
        }

        public T Select(T[] data, int k)
        {
            return Select(data, 0, data.Length - 1, k);
        }
    }
}
