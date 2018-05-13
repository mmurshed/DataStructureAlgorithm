using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Recursion
{
    public class Combination
    {
		public List<string> ProduceCombination(string str)
		{
			var strs = new List<string>();
			ProduceCombination(new StringBuilder(str), 0, new StringBuilder(), strs);
			return strs;
		}
            
		public void ProduceCombination(StringBuilder str, int s, StringBuilder newstr, List<string> list)
        {
			if(s >= str.Length)
			{
                return;
			}

			for (int i = s; i < str.Length; i++)
			{
				newstr.Append(str[i]);

				list.Add(newstr.ToString());

                // Recurse
				ProduceCombination(str, i + 1, newstr, list);

				// Backtrack
				newstr.Length--;                
            }
        }
	}
}
