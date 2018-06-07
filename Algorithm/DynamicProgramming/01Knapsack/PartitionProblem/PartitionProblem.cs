using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class PartitionProblem
    {
        /*
         * Source: https://www.geeksforgeeks.org/dynamic-programming-set-18-partition-problem/
         * 
         * Partition problem is to determine whether a given set can be 
         * partitioned into two subsets such that the sum of elements in both 
         * subsets is same.
         * 
         * Examples
         * arr[] = {1, 5, 11, 5}
         * Output: true 
         * The array can be partitioned as {1, 5, 5} and {11}
         * 
         * arr[] = {1, 5, 3}
         * Output: false 
         * The array cannot be partitioned into equal sum sets.
         * 
         * Following are the two main steps to solve this problem:
         * 1) Calculate sum of the array. If sum is odd, there can not be 
         * two subsets with equal sum, so return false.
         * 
         * 2) If sum of array elements is even, calculate sum/2 and find a 
         * subset of array with sum equal to sum/2.
         * 
         * The first step is simple. The second step is crucial, it can be 
         * solved either using recursion or Dynamic Programming.
         * 
         * Recursive Solution
         * Following is the recursive property of the second step mentioned above.
         * 
         * Let isSubsetSum(arr, n, sum/2) be the function that returns true if
         * there is a subset of arr[0..n-1] with sum equal to sum/2
         * 
         * The isSubsetSum problem can be divided into two subproblems
         * a) isSubsetSum() without considering last element
         *  (reducing n to n-1)
         * 
         * b) isSubsetSum considering the last element 
         *      (reducing sum/2 by arr[n-1] and n to n-1)
         * 
         * If any of the above the above subproblems return true, then return true. 
         * isSubsetSum (arr, n, sum/2) = isSubsetSum (arr, n-1, sum/2) ||
         *                      isSubsetSum (arr, n-1, sum/2 - arr[n-1])
       */

        // A utility function that returns true if there is 
        // a subset of arr[] with sum equal to given sum
        public static bool IsSubsetSum(int[] arr, int n, int sum)
        {
            // Base Cases
            if (sum == 0)
                return true;
            if (n == 0 && sum != 0)
                return false;

            // If last element is greater than sum, then 
            // ignore it
            if (arr[n - 1] > sum)
                return IsSubsetSum(arr, n - 1, sum);

            /* else, check if sum can be obtained by any of 
               the following
               (a) including the last element
               (b) excluding the last element
            */
            return IsSubsetSum(arr, n - 1, sum) ||
                   IsSubsetSum(arr, n - 1, sum - arr[n - 1]);
        }

        // Returns true if arr[] can be partitioned in two
        //  subsets of equal sum, otherwise false
        // O(2^n)
        public static bool FindPartitionNaive(int[] arr, int n)
        {
            // Calculate sum of the elements in array
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            // If sum is odd, there cannot be two subsets 
            // with equal sum
            if (sum % 2 != 0)
                return false;

            // Find if there is subset with sum equal to
            // half of total sum
            return IsSubsetSum(arr, n, sum / 2);
        }

        // Driver program to test above function
        public static void Test()
        {
            var arr = new int[] { 3, 1, 5, 9, 12 };
            int n = arr.Length;
            if (FindPartitionNaive(arr, n) == true)
                Console.WriteLine("Can be divided into two subsets of equal sum");
            else
                Console.WriteLine("Can not be divided into two subsets of equal sum");
        } 

        /*
         * Dynamic Programming Solution
         * The problem can be solved using dynamic programming when the sum of 
         * the elements is not too big. We can create a 2D array part[][] of 
         * size (sum/2)*(n+1). And we can construct the solution in bottom up 
         * manner such that every filled entry has following property
         * 
         * part[i][j] = true if a subset of {arr[0], arr[1], ..arr[j-1]} has 
         * sum equal to i, otherwise false
        */

        // Returns true if arr[] can be partitioned in two subsets of
        // equal sum, otherwise false
        // O(sum*n)
        public static bool FindPartition(int[] arr)
        {
            int n = arr.Length;
            int sum = 0;

            // Caculcate sum of all elements
            for (int i = 0; i < n; i++)
                sum += arr[i];

            if (sum % 2 != 0)
                return false;

            int halfSum = sum / 2;

            var part = new bool[halfSum + 1, n + 1];
     
            // initialize top row as true
            for (int i = 0; i <= n; i++)
              part[0, i] = true;

            // initialize leftmost column, except part[0, 0], as false
            for (int i = 1; i <= halfSum; i++)
              part[i, 0] = false;

            // Fill the partition table in bottom up manner 
            for (int i = 1; i <= halfSum; i++)  
             {
                for (int j = 1; j <= n; j++)  
                {
                    part[i, j] = part[i, j - 1];
                    if (i >= arr[j - 1])
                    {
                        part[i, j] = part[i, j] || part[i - arr[j - 1], j - 1];
                    }
                }
            }  
            return part[halfSum, n];
        }  

        // Driver program to test above funtion
        public static void TestDynamic()
        {
            var arr = new int[]{ 3, 1, 1, 2, 2, 1 };
            if (FindPartition(arr) == true)
                Console.WriteLine("Can be divided into two subsets of equal sum");
            else
                Console.WriteLine("Can not be divided into two subsets of equal sum");
        }
    }
}
