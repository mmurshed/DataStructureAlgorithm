using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.UberProblems
{
    public class Subsets2Solution
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

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            var lists = new HashSet<List<int>>(new ListComparer());
            lists.Add(new List<int>());
            Subsets(nums, 0, new LinkedList<int>(), lists);
            return lists.Select(x => (IList<int>)x).ToList();
        }
            
        public void Subsets(int[] nums, int s, LinkedList<int> list, HashSet<List<int>> lists)
        {
			if(s >= nums.Length)
			{
                return;
			}

            //if (list.Count > 0 && s > 0 && list.Last.Value == nums[s-1])
                //return;

			for (int i = s; i < nums.Length; i++)
			{
                list.AddLast(nums[i]);

                lists.Add(list.ToList());

                // Recurse
                Subsets(nums, i + 1, list, lists);

				// Backtrack
                list.RemoveLast();                
            }
        }
	}
}
