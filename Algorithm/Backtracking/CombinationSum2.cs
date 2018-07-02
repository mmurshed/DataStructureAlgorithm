using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Backtracking
{
    public class CombinationSum2Class
    {
        private class ListComparer : EqualityComparer<List<int>>
        {
            public override bool Equals(List<int> x, List<int> y)
            {
                if (x == null && y == null)
                    return true;
                else if (x == null || y == null)
                    return false;

                if (x.Count == y.Count)
                {
                    return x.SequenceEqual(y);
                }
                return false;
            }

            public override int GetHashCode(List<int> obj)
            {
                int hash = 19;
                foreach (var o in obj)
                {
                    hash = hash * 31 + o.GetHashCode();
                }
                return hash;
            }

        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new HashSet<List<int>>(new ListComparer());
            var current = new LinkedList<int>();

            // Sort O(nlgn)
            Array.Sort(candidates);

            CombinationSum(candidates, target, 0, current, result);

            var listResult = new List<IList<int>>(result.Count);
            foreach (var lst in result)
                listResult.Add(lst);
            return listResult;
        }

        public void CombinationSum(int[] candidates, int target, int index, LinkedList<int> current, HashSet<List<int>> result)
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
                if(!result.Contains(lst))
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
                CombinationSum(candidates, target - n, i + 1, current, result);

                // Backtrack
                current.RemoveLast();
            }
        }
    }
}
