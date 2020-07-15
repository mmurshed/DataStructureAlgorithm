using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class MaximumProductContiguousSubarray
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-27-max-sum-rectangle-in-a-2d-matrix/

        /*
         * Given an array that contains both positive and negative integers, 
         * find the product of the maximum product subarray. Expected Time 
         * complexity is O(n) and only O(1) extra space can be used.
         * 
         * Examples:
         * 
         * Input: arr[] = {6, -3, -10, 0, 2}
         * Output:   180  // The subarray is {6, -3, -10}
         * 
         * Input: arr[] = {-1, -3, -10, 0, 60}
         * Output:   60  // The subarray is {60}
         * 
         * Input: arr[] = {-2, -3, 0, -2, -40}
         * Output:   80  // The subarray is {-2, -40}
         * 
         * The following solution assumes that the given input array always has 
         * a positive output. The solution works for all cases mentioned above. 
         * It doesn’t work for arrays like {0, 0, -20, 0}, {0, 0, 0}.. etc. The 
         * solution can be easily modified to handle this case.
         * 
         * It is similar to Largest Sum Contiguous Subarray problem. The only 
         * thing to note here is, maximum product can also be obtained by 
         * minimum (negative) product ending with the previous element 
         * multiplied by this element. For example, in array 
         * {12, 2, -3, -5, -6, -2}, when we are at element -2, the maximum 
         * product is multiplication of, minimum product ending with -6 and -2.
        */

        /* Returns the product of max product subarray. 
           Assumes that the given array always has a subarray
           with product more than 1 */
        public static int MaxSubarrayProduct(int[] a)
        {
            // max positive product ending at the current position
            int current_max = 1;
         
            // min negative product ending at the current position
            int current_min = 1;
         
            // Initialize overall max product
            int max = 1;
         
            // Following values are maintained after the i'th iteration.
            // current_max is always 1 or some positive product ending with a[i]
            // current_min is always 1 or some negative product ending with a[i]
            foreach(var n in a)
            {
                // CASE 1: Positive
                // If n is positive, update current_max. 
                // Update current_min only if it is negative.
                if (n > 0)
                {
                    current_max *= n;
                    current_min = Math.Min(current_min * n, 1);
                }
         
                // CASE 2: Negative
                // If n is negative,
                // current_max can either be 1 or positive. 
                // current_min can either be 1 or negative.
                // 
                // current_min will be previous current_max * n
                //
                // current_max will be 1 if previous current_min is 1.
                // Otherwise it will be previous current_min * n
                else if(n < 0)
                {
                    int prev_current_min = current_min;
                    current_min = current_max * n;
                    current_max = Math.Max(prev_current_min * n, 1);
                }

                // CASE 3: Zero
                // If n is 0, then the maximum product cannot end here.
                // Set both current_max and current_min to 1
                // Assumption: Output is alway greater than or equal to 1.
                else
                {
                    current_max = 1;
                    current_min = 1;
                }

                // update overall max
                max =  Math.Max(max, current_max);
            }
         
            return max;
        }

        /*
         * imax and imin actually are the products results of their subarray
         * 
         * for example at position A[2]=3:
         * imax list is {2, 3}, then imax =6
         * 
         * imin list is {-1, 2, 3}, then imin=-6
         * 
         * imax is currectly the max subarray's product at currectly position.
         * 
         * at the begining, res, imax, imin are all A[0].
         * loop: i =1 to n-1
         * 
         * when A[i] < 0   ==> swap imax and imin list, 
         * because imax* neg_val==> imin, imin * neg_val ==> imax
         * 
         * 1.  imax: check A[i] is bigger than imax*A[i], 
         * 
         * a1.  A[i] > imax*A[i], for example :imax=0, A[i] = 10, 
         * we should re-fresh the imax list and abandon the original list ==> imax = {A[i]}  
         * 
         * a2.  A[i] < imax*A[i],   for example: imax = 2, A[i] =10.  
         * we should add A[i] to the list==> imax = {........., A[i]}
         * 
         * 2. imin: similar with imax, but we should hold a  min list.
         * 
         * 3. res: check  max(res, imax)
         * 
         * return res.
         */
        public int MaxProduct(int[] nums)
        {
            // max positive product ending at the current position
            int imax = nums[0];

            // min negative product ending at the current position
            int imin = nums[0];

            // Initialize overall max product
            int max = nums[0];

            // Following values are maintained after the i'th iteration.
            // imax is always some positive product ending with a[i]
            // imin is always some negative product ending with a[i]
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                    Swap(ref imax, ref imin);

                imax = Math.Max(nums[i], imax * nums[i]);
                imin = Math.Min(nums[i], imin * nums[i]);

                // update overall max
                max = Math.Max(max, imax);
            }

            return max;
        }

        private void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        // Driver program to test above functions
        public static void Test()
        {
            var arr = new int[] { 1, -2, -3, 0, 7, -8, -2 };
            var result = MaxSubarrayProduct(arr);
            Console.WriteLine($"{result}");
        }
    }
}
