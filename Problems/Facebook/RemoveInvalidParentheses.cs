using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithm.Facebook
{
    public class RemoveInvalidParenthesesProblem
    {
        HashSet<string> results;
        int minRemoved;
        public IList<string> RemoveInvalidParentheses(string s) {
            results = new HashSet<string>();
            minRemoved = s.Length + 1;

            RemoveInvalidParentheses(s, 0, 0, 0, 0, new StringBuilder());

            return new List<string>(results);
        }

        // Time Complexity: O(2^N)
        // since in the worst case we will have only left parentheses in the expression
        // and for every bracket we will have two options i.e. whether to remove it or
        // consider it.
        // Space Complexity: O(N)
        private void RemoveInvalidParentheses(string s, int i, int left, int right, int removed, StringBuilder solution)
        {
            if(i == s.Length)
            {
                if(left == right && removed <= minRemoved)
                {
                    if (removed < minRemoved)
                    {
                        minRemoved = removed;
                        results.Clear();
                    }
                    results.Add(solution.ToString());
                }

                return;
            }

            var ch = s[i];
            i++;


            if (ch == '(' || ch == ')')
            {
                // Remove and try
                RemoveInvalidParentheses(s, i, left, right, removed + 1, solution);
            }

            // Include and try
            solution.Append(ch);

            if (ch != '(' && ch != ')')
            {
                RemoveInvalidParentheses(s, i, left, right, removed, solution);
            }

            if (ch == '(') {
                RemoveInvalidParentheses(s, i, left + 1, right, removed, solution);
            }
            else if (ch == ')' && right < left)
            {
                RemoveInvalidParentheses(s, i, left, right + 1, removed, solution);
            }

            // Backtrack
            solution.Remove(solution.Length - 1, 1);

        }
    }
}
