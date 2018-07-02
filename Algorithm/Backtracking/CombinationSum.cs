using System;
using System.Collections.Generic;

namespace Algorithm.Backtracking
{
    public class CombinationSumClass
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var current = new LinkedList<int>();

            // Sort O(nlgn)
            Array.Sort(candidates);

            CombinationSum(candidates, target, 0, current, result);
            return result;
        }

        public void CombinationSum(int[] candidates, int target, int index, LinkedList<int> current, IList<IList<int>> result)
        {
            // No solution
            if(target < 0)
            {
                return;
            }
            // Solution!
            if (target == 0 && current.Count > 0)
            {
                var lst = new List<int>(current.Count);
                foreach (var n in current)
                    lst.Add(n);
                result.Add(lst);
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                int n = candidates[i];

                if(target < n)
                {
                    return;
                }

                // Construct
                current.AddLast(n);

                // Recurse
                CombinationSum(candidates, target - n, i, current, result);

                // Backtrack
                current.RemoveLast();
            }
        }
    }
}
