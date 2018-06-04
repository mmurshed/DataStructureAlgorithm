using System;
using DataStructure.Tree;
using System.Collections.Generic;

namespace Algorithm.MicrosoftProblems
{
    // https://www.geeksforgeeks.org/largest-rectangular-area-in-a-histogram-set-1/

    public class LargestAreaUnderHistogram
    {
        /*
We can use Divide and Conquer to solve this in O(nLogn) time. The idea is to find the minimum value in the given array. Once we have index of the minimum value, the max area is maximum of following three values.
a) Maximum area in left side of minimum value (Not including the min value)
b) Maximum area in right side of minimum value (Not including the min value)
c) Number of bars multiplied by minimum value.
The areas in left and right of minimum value bar can be calculated recursively. If we use linear search to find the minimum value, then the worst case time complexity of this algorithm becomes O(n^2). In worst case, we always have (n-1) elements in one side and 0 elements in other side and if the finding minimum takes O(n) time, we get the recurrence similar to worst case of Quick Sort.
How to find the minimum efficiently? Range Minimum Query using Segment Tree can be used for this. We build segment tree of the given histogram heights. Once the segment tree is built, all range minimum queries take O(Logn) time. So over all complexity of the algorithm becomes.

Overall Time = Time to build Segment Tree + Time to recursively find maximum area

Time to build segment tree is O(n). Let the time to recursively find max area be T(n). It can be written as following.
T(n) = O(Logn) + T(n-1)
The solution of above recurrence is O(nLogn). So overall time is O(n) + O(nLogn) which is O(nLogn).
        */

        private class Node
        {
            public int value;
            public int index;
            public Node(int v, int i)
            {
                value = v;
                index = i;
            }
        }

        public int FindLargestAreaUnderHistogram(int[] histogram)
        {
            var nodes = new Node[histogram.Length];
            for (int i = 0; i < histogram.Length; i++)
            {
                nodes[i] = new Node(histogram[i], i);
            }
            var tree = new SegmentTree<Node>(nodes, (x, y) =>
            {
                if (x == null)
                    return y;
                if (y == null)
                    return x;
                return x.value < y.value ? x : y;
            });
            return FindLargestAreaUnderHistogram(histogram, 0, histogram.Length - 1, tree);
        }

        private int FindLargestAreaUnderHistogram(int[] histogram, int start, int end, SegmentTree<Node> tree)
        {
            if (start > end)
            {
                return Int32.MinValue;
            }

            if(start == end)
            {
                return histogram[start];
            }

            var min = tree.Find(start, end);
            int mid = min.index;

            int area = (end - start + 1) * histogram[mid];
            int leftArea = FindLargestAreaUnderHistogram(histogram, start, mid - 1, tree);
            int rightArea = FindLargestAreaUnderHistogram(histogram, mid + 1, end, tree);
            area = Math.Max(area, leftArea);
            area = Math.Max(area, rightArea);
            return area;
        }

        /*
         * https://www.geeksforgeeks.org/largest-rectangle-under-histogram/
For every bar ‘x’, we calculate the area with ‘x’ as the smallest bar in the rectangle. If we calculate such area for every bar ‘x’ and find the maximum of all areas, our task is done. How to calculate area with ‘x’ as smallest bar? We need to know index of the first smaller (smaller than ‘x’) bar on left of ‘x’ and index of first smaller bar on right of ‘x’. Let us call these indexes as ‘left index’ and ‘right index’ respectively.
We traverse all bars from left to right, maintain a stack of bars. Every bar is pushed to stack once. A bar is popped from stack when a bar of smaller height is seen. When a bar is popped, we calculate the area with the popped bar as smallest bar. How do we get left and right indexes of the popped bar – the current index tells us the ‘right index’ and index of previous item in stack is the ‘left index’. Following is the complete algorithm.

1) Create an empty stack.

2) Start from first bar, and do following for every bar ‘hist[i]’ where ‘i’ varies from 0 to n-1.
   a) If stack is empty or hist[i] is higher than the bar at top of stack, then push ‘i’ to stack.
   b) If this bar is smaller than the top of stack, then keep removing the top of stack while top of the stack is greater.
   Let the removed bar be hist[tp]. 
   Calculate area of rectangle with hist[tp] as smallest bar. 
   For hist[tp], the ‘left index’ is previous (previous to tp) item in stack and ‘right index’ is ‘i’ (current index).

3) If the stack is not empty, then one by one remove all bars from stack and do step 2.b for every removed bar.
        */

        public int FindLargestAreaUnderHistogram2(int[] histogram)
        {
            var stack = new Stack<int>();

            int area = 0;
            int i = 0;

            while(i < histogram.Length)
            {
                // Current bar is higher than the bar on top of stack
                if (stack.Count == 0 || histogram[i] >= histogram[stack.Peek()])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    int top = stack.Pop();

                    // Calculate the area with histogram[top] stack as smallest bar
                    int minBar = (stack.Count == 0 ? i : i - stack.Peek() - 1);

                    var newArea = histogram[top] * minBar;

                    area = Math.Max(area, newArea);
                }
            }

            // Pop remaining bars
            while(stack.Count > 0)
            {
                int top = stack.Pop();
                // Calculate the area with histogram[top] stack as smallest bar
                int minBar = (stack.Count == 0 ? i : i - stack.Peek() - 1);

                var newArea = histogram[top] * minBar;

                area = Math.Max(area, newArea);
            }

            return area;
        }

        public int FindLargestAreaUnderHistogram3(int[,] histogram, int row)
        {
            var stack = new Stack<int>();

            int area = 0;
            int i = 0;

            int length = histogram.GetLength(1);

            while (i < length)
            {
                // Current bar is higher than the bar on top of stack
                if (stack.Count == 0 || histogram[row, i] >= histogram[row, stack.Peek()])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    int top = stack.Pop();

                    // Calculate the area with histogram[top] stack as smallest bar
                    int minBar = (stack.Count == 0 ? i : i - stack.Peek() - 1);

                    var newArea = histogram[row, top] * minBar;

                    area = Math.Max(area, newArea);
                }
            }

            // Pop remaining bars
            while (stack.Count > 0)
            {
                int top = stack.Pop();
                // Calculate the area with histogram[top] stack as smallest bar
                int minBar = (stack.Count == 0 ? i : i - stack.Peek() - 1);

                var newArea = histogram[row, top] * minBar;

                area = Math.Max(area, newArea);
            }

            return area;
        }

    }
}
