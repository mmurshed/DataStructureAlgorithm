using System;
using System.Collections.Generic;

namespace DataStructure.Queue
{
    /*
     * Data Structure: Sliding Window Minimum / Monotonic Queue
     * Given an array of elements a0,a1,a2,…,an, and queries Q(i,i+L) which 
     * means "find the minimum element in ai,ai+1,…,ai+L". How can we answer 
     * such queries efficiently?
     * 
     * We can have an O(nlgn) complexity by using a minimum priority queue, 
     * RB tree, or a binary tree representation of multiset, but there in this 
     * setting we can implement a data structure called monotonic queue which 
     * only requires O(n) in construction. The implementation of this data 
     * structure requires a dequeue.
     * 
     * Let D be the dequeue which maintain a pair of information (i, ai). An 
     * important property of D that we will maintain is that element in D will 
     * always be in sorted order (invariant). We will first start with an empty 
     * D, and will insert ai and remove elements from D accordingly as we 
     * iterate from the left to the right of array a (which is from 
     * i = 0, 1, 2, ..., n).
     * 
     * Suppose that we are now at index i and considering to add ai. Notice that
     * when ai is added, all elements in (j, aj) in D such that aj is bigger 
     * than ai can never be a minimum value as we go forward, hence they can be
     * removed from D.
     * 
     * Furthermore, if the element (i-L-1, ai−L−1) is in D (which will be 
     * located at the top of D if it exists), we remove that element as well.
     * 
     * Lastly, we append ai at the back of D. Then we will have Q(i-L, i) = the
     * top element in D when we reach index i. Since each element will enter and
     * leave D only once, we have a total of O(N) operations.
    */
    public class MonotonicQueue
    {
        public static List<int> MaxSlidingWindow(int[] nums, int k)
        {
            // Let D be the dequeue which maintain a pair of information (i, ai). An 
            // important property of D that we will maintain is that element in D will 
            // always be in sorted order (invariant). We will first start with an empty 
            // D, and will insert ai and remove elements from D accordingly as we 
            // iterate from the left to the right of array a (which is from 
            // i = 0, 1, 2, ..., n).            
            LinkedList<int> dq  = new LinkedList<int>();
            List<int> ans = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                // If the element (i-L-1, ai−L−1) is in D (which will be 
                // located at the top of D if it exists), we remove that element as well.
                if (dq.Count != 0 && dq.First.Value == i - k)
                    dq.RemoveFirst();

                // Suppose that we are now at index i and considering to add ai.
                // Notice that when ai is added, all elements in (j, aj) in D 
                // such that aj is smaller than ai can never be a maximum value 
                // as we go forward, hence they can be removed from D.
                while (dq.Count !=0 && nums[dq.Last.Value] < nums[i])
                    dq.RemoveLast();

                // Lastly, we append ai at the back of D. Then we will have Q(i - L, i) = the
                // top element in D when we reach index i.
                dq.AddLast(i);
                if (i >= k - 1)
                    ans.Add(nums[dq.First.Value]);
            }
            return ans;
        }

    }
}
