using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DynamicProramming
{
    public class BoxStack
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-21-box-stacking-problem/

        /* 
         * You are given a set of n types of rectangular 3-D boxes, where the 
         * i^th box has height h(i), width w(i) and depth d(i) (all real 
         * numbers). You want to create a stack of boxes which is as tall as 
         * possible, but you can only stack a box on top of another box if the 
         * dimensions of the 2-D base of the lower box are each strictly larger 
         * than those of the 2-D base of the higher box. Of course, you can 
         * rotate a box so that any side functions as its base. It is also 
         * allowable to use multiple instances of the same type of box.
         * 
         * The Box Stacking problem is a variation of LIS problem. We need to 
         * build a maximum height stack.
         * 
         * Following are the key points to note in the problem statement:
         * 1) A box can be placed on top of another box only if both width and
         * depth of the upper placed box are smaller than width and depth of 
         * the lower box respectively.
         * 
         * 2) We can rotate boxes. For example, if there is a box with 
         * dimensions {1x2x3} where 1 is height, 2×3 is base, then there can 
         * be three possibilities, {1x2x3}, {2x1x3} and {3x1x2}.
         * 
         * 3) We can use multiple instances of boxes. What it means is, we can 
         * have two different rotations of a box as part of our maximum height 
         * stack.
         * 
         * Following is the solution based on DP solution of LIS problem.
         * 
         * 1) Generate all 3 rotations of all boxes. The size of rotation array
         * becomes 3 times the size of original array. For simplicity, we 
         * consider depth as always smaller than or equal to width.
         * 
         * 2) Sort the above generated 3n boxes in decreasing order of base area.
         * 
         * 3) After sorting the boxes, the problem is same as LIS with following 
         * optimal substructure property.
         * 
         * MSH(i) = Maximum possible Stack Height with box i at top of stack
         * 
         * MSH(i) = { Max ( MSH(j) ) + height(i) } where j < i and width(j) > width(i) and depth(j) > depth(i).
         * 
         * If there is no such j then MSH(i) = height(i)
         * 
         * 4) To get overall maximum height, we return max(MSH(i)) where 0 < i < n
         * 
         * Following is the implementation of the above solution.
        */

        // Representation of a box
        public class Box
        {
            // h --> height, w --> width, d --> depth
            public int h, w, d;  // for simplicity of solution, always keep w <= d
            public Box(int h, int w, int d)
            {
                this.h = h;
                this.d = d;
                this.w = w;
            }
        }

        // Returns the height of the tallest stack that can be
        // formed with give type of boxes
        public static int MaxStackHeight(Box[] arr)
        {
            // Create an array of all rotations of given boxes
            // For example, for a box {1, 2, 3}, we consider three
            // instances{{1, 2, 3}, {2, 1, 3}, {3, 1, 2}}
            var rotations = new Box[3 * arr.Length];
            int index = 0;

            // Copy three rotations of each box as a new box
            for (int i = 0; i < arr.Length; i++)
            {
                // Copy the original box
                rotations[index] = arr[i];
                index++;

                // First rotation of box
                rotations[index].h = arr[i].w;
                rotations[index].d = Math.Max(arr[i].h, arr[i].d);
                rotations[index].w = Math.Min(arr[i].h, arr[i].d);
                index++;

                // Second rotation of box
                rotations[index].h = arr[i].d;
                rotations[index].d = Math.Max(arr[i].h, arr[i].w);
                rotations[index].w = Math.Min(arr[i].h, arr[i].w);
                index++;
            }

            // Assuming d, w is always placed as the bottom,
            // sort the array 'rot[]' in decreasing order of are d * w
            Array.Sort(rotations, (x, y) => y.d * y.w - x.d * x.w);

            // Initialize msh values for all indexes 
            // msh[i] --> Maximum possible Stack Height with box i on top
            var msh = new int[rotations.Length];
            for (int i = 0; i < rotations.Length; i++)
            {
                msh[i] = rotations[i].h;
            }

            // Compute optimized msh values in bottom up manner
            // Standard Longest increasing subsequence
            // (Max Sum Increasing Subsequence)
            for (int i = 1; i < rotations.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (rotations[i].w < rotations[j].w &&
                         rotations[i].d < rotations[j].d &&
                         msh[i] < msh[j] + rotations[i].h
                       )
                    {
                        msh[i] = msh[j] + rotations[i].h;
                    }
                }
            }

            // Return maximum of all msh values

            return msh.Max();
        }

        // Driver program to test above function
        public static void Test()
        {
            var arr = new []
            {
                new Box (4, 6, 7),
                new Box (1, 2, 3),
                new Box (4, 5, 6),
                new Box (10, 12, 32)
            };

            Console.WriteLine($"The maximum possible height of stack is {MaxStackHeight(arr)}");
        }
    }
}
