using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePractice.GoogleProblems
{
    public class ExpressionAddOperators
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
}
