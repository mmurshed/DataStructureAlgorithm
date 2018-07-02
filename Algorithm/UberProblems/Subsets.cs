using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.UberProblems
{
    public class SubsetsSolution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            var lists = new List<IList<int>>();
            lists.Add(new List<int>());
            Subsets(nums, 0, new LinkedList<int>(), lists);
            return lists;
        }
            
        public void Subsets(int[] nums, int s, LinkedList<int> list, List<IList<int>> lists)
        {
			if(s >= nums.Length)
			{
                return;
			}

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
