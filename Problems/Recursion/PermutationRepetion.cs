using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Recursion
{
    // Contains repetition: 112
    public class PermutationRepetion
    {
		public List<string> Permutate(string str)
		{
			var strs = new List<string>();
			Permutate(new StringBuilder(str), 0, strs);
			return strs;
		}

		private void Swap(StringBuilder str, int i, int j)
		{
			if (i == j)
				return;
			char temp = str[i];
			str[i] = str[j];
			str[j] = temp;
		}

		// Returns true if str[cur] does not matches with any of the 
		// characters after str[start]
		private bool ShouldSwap(StringBuilder str, int s, int cur)
		{
			for (int j = s; j < cur; j++)
				if (str[j] == str[cur])
					return false;
			return true;
		}


		public void Permutate(StringBuilder str, int s, List<string> list)
        {
            if(s >= str.Length)
			{
				list.Add(str.ToString());
				return;
			}

            for (int i = s; i < str.Length; i++)
			{
				if (ShouldSwap(str, s, i))
				{
					Swap(str, s, i);
					Permutate(str, s + 1, list);
					// Backtrack
					Swap(str, s, i);
				}
			}
        }
	}
}
