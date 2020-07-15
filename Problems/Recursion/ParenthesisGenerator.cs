using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithm.Recursion
{
    public class ParenthesisGenerator
    {
        public List<string> GenerateParenthesis(int n)
        {
            var list = new List<string>();
            if (n <= 0)
                return list;
            GenerateParenthesis(0, n, 0, 0, new StringBuilder(n*2), list);
            return list;
        }

        // https://www.geeksforgeeks.org/print-all-combinations-of-balanced-parentheses/
        /*
         * Keep track of counts of open and close brackets.
         * 
         * 1. Initialize these counts as 0.
         * 2. Recursively call the GenerateParenthesis function until open 
         *    bracket count is less than the given n.
         * 3. If open bracket count becomes more than the close bracket count, 
         *    then put a closing bracket and recursively call for the 
         *    remaining brackets.
         * 4. If open bracket count is less than n, then put an opening 
         *    bracket and call GenerateParenthesis for the remaining brackets.
        */
        private void GenerateParenthesis(int pos, int n, int open, int close, StringBuilder strb, List<string> list)
        {
            if (close == n)
            {
                list.Add(strb.ToString());
                return;
            }

            if (open > close)
            {
                strb[pos] = ')';
                GenerateParenthesis(pos + 1, n, open, close + 1, strb, list);
            }

            if (open < n)
            {
                strb[pos] = '(';
                GenerateParenthesis(pos + 1, n, open + 1, close, strb, list);
            }
        }
    }
}
