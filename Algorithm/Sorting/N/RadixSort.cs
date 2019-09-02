using System;
namespace Algorithm.Sort
{
    /*
     * The lower bound for Comparison based sorting algorithm (Merge Sort, Heap
     * Sort, Quick-Sort .. etc) is Ω(nLogn), i.e., they cannot do better than 
     * nLogn.
     * 
     * Counting sort is a linear time sorting algorithm that sort in O(n+k) 
     * time when elements are in range from 1 to k.
     * 
     * What if the elements are in range from 1 to n2? 
     * 
     * We can’t use counting sort because counting sort will take O(n2) which 
     * is worse than comparison based sorting algorithms. Can we sort such an 
     * array in linear time?
     * 
     * Radix Sort is the answer. The idea of Radix Sort is to do digit by digit
     * sort starting from least significant digit to most significant digit. 
     * Radix sort uses counting sort as a subroutine to sort.
     * 
     * The Radix Sort Algorithm
     * 1) Do following for each digit i where i varies from least significant 
     * digit to the most significant digit.
     *      a) Sort input array using counting sort (or any stable sort) 
     * according to the i’th digit.
     * 
     * Example:
     * Original, unsorted list:
     * 170, 45, 75, 90, 802, 24, 2, 66
     * 
     * Sorting by least significant digit (1s place) gives: [*Notice that we 
     * keep 802 before 2, because 802 occurred before 2 in the original list,
     * and similarly for pairs 170 & 90 and 45 & 75.]
     * 
     * 170, 90, 802, 2, 24, 45, 75, 66
     *   -   -    -  -   -   -   -   -
     * 
     * Sorting by next digit (10s place) gives: [*Notice that 802 again comes 
     * before 2 as 802 comes before 2 in the previous list.]
     * 
     * 802, 2, 24, 45, 66, 170, 75, 90
     *  -      -   -   -    -   -   -
     * 
     * Sorting by most significant digit (100s place) gives:
     * 
     * 2, 24, 45, 66, 75, 90, 170, 802
     *                        -    -
     * 
     * What is the running time of Radix Sort?
     * Let there be d digits in input integers. Radix Sort takes O(d*(n+b)) 
     * time where b is the base for representing numbers, for example, for 
     * decimal system, b is 10. What is the value of d? If k is the maximum 
     * possible value, then d would be O(logb(k)). So overall time complexity 
     * is O((n+b) * logb(k)). Which looks more than the time complexity of 
     * comparison based sorting algorithms for a large k. Let us first limit 
     * k. Let k <= nc where c is a constant. In that case, the complexity 
     * becomes O(nLogb(n)). But it still doesn’t beat comparison based sorting 
     * algorithms.
     * 
     * What if we make value of b larger?. What should be the value of b to 
     * make the time complexity linear? If we set b as n, we get the time 
     * complexity as O(n). In other words, we can sort an array of integers 
     * with range from 1 to nc if the numbers are represented in base n (or 
     * every digit takes log2(n) bits).
     * 
     * Is Radix Sort preferable to Comparison based sorting algorithms like
     * Quick-Sort?
     * If we have log2n bits for every digit, the running time of Radix appears 
     * to be better than Quick Sort for a wide range of input numbers. The 
     * constant factors hidden in asymptotic notation are higher for Radix 
     * Sort and Quick-Sort uses hardware caches more effectively. Also, Radix 
     * sort uses counting sort as a subroutine and counting sort takes extra 
     * space to sort numbers.
     * 
     * Implementation of Radix Sort
     * Following is a simple C++ implementation of Radix Sort. For simplicity, 
     * the value of d is assumed to be 10. We recommend you to see Counting 
     * Sort for details of countSort() function in below code.
    */
    public class RadixSort : SortBase<int>
    {
        private const int width = 10;

        private int ToIndex(int n, int e)
        {
            return (n / e) % width;
        }

        private void Sort(int[] data, int exp)
        {
            var sortedData = new int[data.Length];
            var count = new int[width];

            // 1. Init count to zero
            for (int i = 0; i < width; i++)
                count[i] = 0;

            // 2. Count the occurrences of each char
            foreach (int d in data)
                ++count[ToIndex(d, exp)];

            // 3. Sum up the locations
            for (int i = 1; i < width; i++)
                count[i] += count[i - 1];

            // 4. Use the count to put the char in place
            for (int i = data.Length - 1; i >= 0; i--)
            {
                var index = ToIndex(data[i], exp);
                count[index]--;
                sortedData[count[index]] = data[i];
            }

            // 5. Copy the sorted data back
            for (int i = 0; i < data.Length; i++)
                data[i] = sortedData[i];
        }

        private int Max(int[] data)
        {
            int max = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > max)
                    max = data[i];
            }
            return max;
        }

        public override void Sort(int[] data)
        {
            int max = Max(data);
            for (int exp = 1; max / exp > 0; exp *= width)
                Sort(data, exp);
        }
    }
}
