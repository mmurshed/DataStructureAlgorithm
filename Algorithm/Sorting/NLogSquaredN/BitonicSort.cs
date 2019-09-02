using System;
namespace Algorithm.Sort
{
    /*
     * Bitonic Sort is a classic parallel algorithm for sorting.
     * 
     * Bitonic sort does O(n Log 2n) comparisons.
     * The number of comparisons done by Bitonic sort are more than popular 
     * sorting algorithms like Merge Sort [ does O(nLogn) comparisons], but 
     * Bitonice sort is better for parallel implementation because we always 
     * compare elements in predefined sequence and the sequence of comparison
     * doesn’t depend on data. Therefore it is suitable for implementation in 
     * hardware and parallel processor array.
     * 
     * To understand Bitonic Sort, we must first understand what is Bitonic 
     * Sequence and how to make a given sequence Bitonic.
     * 
     * Bitonic Sequence
     * 
     * A sequence is called Bitonic if it is first increasing, then decreasing. 
     * In other words, an array arr[0..n-i] is Bitonic if there exists an index
     * i where 0<=i<=n-1 such that
     * 
     * x0 <= x1 ... <= xi  and  xi >= xi+1 ... >= xn-1 
     * 
     * A sequence, sorted in increasing order is considered Bitonic with the 
     * decreasing part as empty. Similarly, decreasing order sequence is 
     * considered Bitonic with the increasing part as empty.
     * 
     * A rotation of Bitonic Sequence is also bitonic.
     * 
     * How to form a Bitonic Sequence from a random input?
     * We start by forming 4-element bitonic sequences from consecutive 
     * 2-element sequence. Consider 4-element in sequence x0, x1, x2, x3. We 
     * sort x0 and x1 in ascending order and x2 and x3 in descending order. 
     * We then concatenate the two pairs to form a 4 element bitonic sequence.
     * 
     * Next, we take two 4 element bitonic sequences, sorting one in ascending
     * order, the other in descending order (using the Bitonic Sort which we 
     * will discuss below), and so on, until we obtain the bitonic sequence.
     * 
     * Example:
     * Convert the following sequence to bitonic sequence: 3, 7, 4, 8, 6, 2, 1, 5
     * 
     * Step 1: Consider each 2-consecutive elements as bitonic sequence and 
     * apply bitonic sort on each 2- pair elements. In next step, take two 4 
     * element bitonic sequences and so on.
     * 
     * a─┐   Min(a,b)       a<┐   Max(a,b)
     * │=                   │=
     * b<┘   Max(a,b)       b─┘   Min(a,b)
     * 
     * 3<┐                  3
     * 7─┘                  7
     * 4─┐                  8
     * 8<┘       ▬▬▬▬>      4
     * 6<┐                  2
     * 2─┘                  6
     * 1─┐                  5
     * 5<┘                  1
     * 
     * Note: x0 and x1 are sorted in ascending order and x2 and x3 in descending
     * order and so on
     * 
     * Step 2: Two 4 element bitonic sequences : A(3,7,8,4) and B(2,6,5,1) with
     * comparator length as 2
     * 
     * 3─┐          3─┐         3
     * 7─┤┐         4<┘         4
     * 8<┘│         8─┐         7
     * 4<─┘  ▬▬▬▬>  7<┘  ▬▬▬▬>  8
     * 2<─┐         5<┐         6
     * 6<┐│         6─┘         5
     * 5─┤┘         2<┐         2
     * 1─┘          1─┘         1
     * 
     * After this step, we’ll get Bitonic sequence of length 8.
     * 
     * 3, 4, 7, 8, 6, 5, 2, 1
     * Bitonic Sorting
     * 
     * It mainly involves two steps.
     * 
     * 1. Forming a bitonic sequence (discussed above in detail). After this 
     * step we reach the fourth stage in below diagram, i.e., the array 
     * becomes {3, 4, 7, 8, 6, 5, 2, 1}
     * 
     * 2. Creating one sorted sequence from bitonic sequence : After first 
     * step, first half is sorted in increasing order and second half in 
     * decreasing order.
     * 
     * We compare first element of first half with first element of second 
     * half, then second element of first half with second element of second
     * and so on. We exchange elements if an element of first half is smaller.
     * 
     * After above compare and exchange steps, we get two bitonic sequences in 
     * array. See fifth stage in below diagram. In the fifth stage, we have 
     * {3, 4, 2, 1, 6, 5, 7, 8}. If we take a closer look at the elements, we 
     * can notice that there are two bitonic sequences of length n/2 such that
     * all elements in first bitnic sequence {3, 4, 2, 1} are smaller than all
     * elements of second bitonic sequence {6, 5, 7, 8}.
     * 
     * We repeat the same process within two bitonic sequences and we get four
     * bitonic sequences of length n/4 such that all elements of leftmost 
     * bitonic sequence are smaller and all elements of rightmost. See sixth
     * stage in below diagram, arrays is {2, 1, 3, 4, 6, 5, 7, 8}.
     * 
     * If we repeat this process one more time we get 8 bitonic sequences of 
     * size n/8 which is 1. Since all these bitonic sequence are sorted and 
     * every bitonic sequence has one element, we get the sorted array.
     * 
     *        3<┐    3─┐     3─┐    3─┐       3─┐     2─┐    1
     *        7─┘    7─┤┐    4<┘    4─┤┐      4─┤┐    1<┘    2
     *        4─┐    8<┘│    8─┐    7─┤┤┐     2<┘│    3─┐    3
     *        8<┘ ▬> 4<─┘ ▬> 7<┘ ▬> 8─┤┤┤┐ ▬> 1<─┘ ▬> 4<┘ ▬> 4
     *        6<┐    2<─┐    5<┐    6<┘│││    6─┐     6─┐    5
     *        2─┘    6<┐│    6─┘    5<─┘││    5─┤┐    5<┘    6
     *        1─┐    5─┤┘     2<┐   2<──┘│    7<┘│    7─┐    7
     *        5<┘    1─┘      1─┘   1<───┘    8<─┘    8<┘    8
     * 
     * Stages: 1      2        1     3         2       1
     *        │   │  │           │  │                     │
     * Steps: └─1─┘  └─────2─────┘  └──────────3──────────┘
    */
    public class BitonicSort<T> : SortBase<T>
        where T: IComparable<T>
    {
        private void CompareSwap(T[] data, int i, int j, bool increasing)
        {
            if ((data[i].CompareTo(data[j]) > 0) == increasing)
                Swap(ref data[i], ref data[j]);
        }

        private void Merge(T[] data, int l, int count, bool increasing)
        {
            if(count > 1)
            {
                int k = count / 2;
                for (int i = l; i < l + k; i++)
                {
                    CompareSwap(data, i, i+k, increasing);
                }
                Merge(data, l, k, increasing);
                Merge(data, l+k, k, increasing);
            }
        }

        private void Sort(T[] data, int l, int count, bool increasing)
        {
            if(count > 1)
            {
                int k = count / 2;
                Sort(data, l, k, true);
                Sort(data, l+k, k, true);
                Merge(data, l, count, increasing);
            }
        }

        public override void Sort(T[] data)
        {
            Sort(data, 0, data.Length, true);
        }
    }
}
