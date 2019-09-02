using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.GoogleProblems
{
    public class ExpressionAddOperatorsDepricated
    {

        private int[,] multTable;
        private int[,] sumTable;
        private int[,] subTable;
        public IList<string> AddOperators(string num, int target)
        {
            if (num == null || num.Length == 0)
                return new List<string>();

            multTable = new int[num.Length, num.Length];
            sumTable = new int[num.Length, num.Length];
            subTable = new int[num.Length, num.Length];

            for (int i = 0; i < num.Length; i++)
            {
                multTable[i, i] = num[i] - '0';
                for (int j = i + 1; j < num.Length; j++)
                {
                    int cur = (num[j] - '0');
                    multTable[i, j] = multTable[i, j - 1] * cur;
                    sumTable[i, j] = multTable[i, j - 1] + cur;
                    subTable[i, j] = multTable[i, j - 1] - cur;
                }
            }

            IList<string> list = new List<string>();
            var strB = new StringBuilder();
            strB.Append(num[0]);
            AddOperators(ref list, num, 1, num.Length - 1, target - (num[0] - '0'), strB);
            return list;
        }

        public void AddOperators(ref IList<string> list, string num, int start1, int start2, int target, StringBuilder currentString)
        {
            if (start1 == num.Length && target == 0)
            {
                list.Add(currentString.ToString());
                return;
            }

            if (start1 == num.Length)
                return;

            int lastLen = currentString.Length;

            // Try +
            currentString.Append($"+{num[start1]}");

            AddOperators(ref list, num, start1 + 1, start2 + 1, target - multTable[start1, start2], currentString);

            // Backtrack
            currentString.Remove(lastLen, currentString.Length - lastLen);

            // Try -
            currentString.Append($"-{num[start1]}");

            // AddOperators(ref list, num, start1 + 1, target + multTable[start1, start2], currentString);

            // Backtrack
            currentString.Remove(lastLen, currentString.Length - lastLen);

            // Try *
            for (int i = start1; i <= start2; i++)
            {
                currentString.Append($"*{num[i]}");
                // AddOperators(ref list, num, i + 1, target * multTable[start1 -1, i], currentString);
            }

            // Backtrack
            currentString.Remove(lastLen, currentString.Length - lastLen);
        }
    }

    public class ExpressionAddOperators
    {
        private readonly char[] ops = "+-*".ToCharArray();
        private long target;
        private string num;
        private List<string> list;
        private StringBuilder currentString;

        public IList<string> AddOperators(string num, long target)
        {
            if (string.IsNullOrEmpty(num))
                return new List<string>();

            this.list = new List<string>();
            this.num = num;
            this.target = target;

            this.currentString = new StringBuilder();

            AddOperators(0, 0, 0);
            return list;
        }

        public void AddOperators(int start, long prev, long value)
        {
            if (start == num.Length && value == target)
            {
                list.Add(currentString.ToString());
                return;
            }

            if (start == num.Length)
                return;

            int currenStringLength = currentString.Length;

            long curNum = 0;
            var curNumStr = new StringBuilder();
            for (int i = start; i < num.Length; i++)
            {
                curNum = curNum * 10 + (int)(num[i] - '0');

                // First number
                if (start == 0)
                {
                    // Insert number
                    currentString.Append(num[i]);
                    AddOperators(i + 1, curNum, curNum);
                }
                else
                {
                    curNumStr.Append(num[i]);

                    // Insert operator placeholder
                    currentString.Append(' ');
                    // Insert number
                    currentString.Append(curNumStr);

                    foreach (char op in ops)
                    {
                        // Insert operator
                        currentString[currenStringLength] = op;
                        switch (op)
                        {
                            case '+':
                                AddOperators(i + 1, curNum, value + curNum);
                                break;
                            case '-':
                                AddOperators(i + 1, -curNum, value - curNum);
                                break;
                            case '*':
                                var diff = value - prev;
                                var newPrev = prev * curNum;
                                AddOperators(i + 1, newPrev, diff + newPrev);
                                break;
                        }
                    }
                    // Backtrack
                    currentString.Length = currenStringLength;
                }

                // Avoid 05
                if (num[start] == '0')
                    break;
            }
        }
    }
}
