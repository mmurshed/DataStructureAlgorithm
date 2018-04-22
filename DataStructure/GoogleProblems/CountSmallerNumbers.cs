using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructurePractice.GoogleProblems
{
    // Use binary search tree and add up the smaller ones when going right while adding.

    /*
     * You are given an integer array nums and you have to return a new counts array. The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].

Example:

Given nums = [5, 2, 6, 1]

To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
Return the array [2, 1, 1, 0].

    */
    public class CountSmallerNumbers
    {
        public class BinaryNode
        {
            public int Key;
            public int Count;
            public int Repeat;

            public BinaryNode Left;
            public BinaryNode Right;

            public BinaryNode(int Key, int Count, int Repeat)
            {
                this.Key = Key;
                this.Count = Count;
                this.Repeat = Repeat;
            }
        }

        public class BinarySearchTree
        {
            public BinaryNode Root;

            public virtual int Add(int Key)
            {
                return Add(ref Root, Key, 0);
            }

            protected virtual int Add(ref BinaryNode Subroot, int Key, int Count)
            {
                if (Subroot == null)
                {
                    Subroot = new BinaryNode(Key, 0, 1);
                    return Count;
                }

                if (Key == Subroot.Key)
                {
                    Subroot.Repeat++;
                    return Subroot.Count + Count;
                }

                if (Key < Subroot.Key)
                {
                    Subroot.Count++;
                    return Add(ref Subroot.Left, Key, Count);
                }
                else
                {
                    return Add(ref Subroot.Right, Key, Count + Subroot.Count + Subroot.Repeat);
                }
            }
        }

        public static IList<int> CountSmaller(int[] nums)
        {
            if (nums.Length == 0)
                return new int[0];
            var tr = new BinarySearchTree();
            var list = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                list[i] = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                list[i] = tr.Add(nums[i]);
            }
            return list;
        }    }
}
