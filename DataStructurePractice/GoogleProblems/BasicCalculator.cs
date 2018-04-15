using System;
using System.Collections.Generic;

namespace DataStructurePractice.GoogleProblems
{
    /*
     * Implement a basic calculator to evaluate a simple expression string.

The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .

You may assume that the given expression is always valid.

Some examples:
"1 + 1" = 2
" 2-1 + 2 " = 3
"(1+(4+5+2)-3)+(6+8)" = 23
Note: Do not use the eval built-in library function.
    */
    public class BasicCalculator
    {
        public int Calculate(string s)
        {
            return Calculate(s, 0).Item1;
        }

        private Tuple<int, int> Calculate(string s, int start)
        {
            int sum = 0;
            int sign = 1;
            for (int i = start; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == ' ')
                    continue;
                if(ch >= '0' && ch <= '9')
                {
                    int num = 0;
                    while(ch >= '0' && ch <= '9' && i < s.Length)
                    {
                        num = 10 * num + ch - '0';
                        i++;
                        if(i < s.Length)
                            ch = s[i];
                    }
                    sum += sign * num;
                    --i;
                }
                else if (ch == '+')
                {
                    sign = 1;
                }
                else if(ch == '-')
                {
                    sign = -1;
                }
                else if(ch == '(')
                {
                    var sub = Calculate(s, i + 1);
                    sum += sign * sub.Item1;
                    i = sub.Item2;
                }
                else if(ch == ')')
                {
                    return new Tuple<int, int>(sum, i);
                }
            }

            return new Tuple<int, int>(sum, s.Length);
        }
    }
}
