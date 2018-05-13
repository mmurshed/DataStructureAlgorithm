using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.Recursion
{
	public class TelephoneWords
	{
		private readonly List<string> DigitWords = new List<string> { "0", "1", "ABC", "DEF", "GHI", "JKL", "MNO", "PRS", "TUV", "WXYZ" };
		private char Char(int digit, int place)
		{
            return DigitWords[digit][place - 1];
		}

        public List<string> GenerateTelephoneWords(int telephone)
		{
			var list = new List<string>();
			GenerateTelephoneWords(telephone.ToString(), 0, new StringBuilder(), list);
			return list;
		}

		// O(3^n)
		private void GenerateTelephoneWords(string telephone, int start, StringBuilder telString, List<string> list)
		{
			if (start >= telephone.Length)
			{
				list.Add(telString.ToString());
				return;
			}

			string digW = DigitWords[telephone[start] - '0'];
			for (int i = 0; i < digW.Length; i++)
			{
				telString.Append(digW[i]);
				GenerateTelephoneWords(telephone, start + 1, telString, list);
                // Backtrack
				telString.Length--;
			}
		}

		//public List<string> GenerateTelephoneWordsNoRecursion(int telnumber)
   //     {
			//string telephone = telnumber.ToString();
			//List<string> list = new List<string>();
			//StringBuilder telString = new StringBuilder();

			//for (int i = 0; i < telephone.Length; i++)
			//{          
			//	string digW = DigitWords[telephone[i] - '0'];
			//	for (int j = 0; j < digW.Length; j++)
			//	{
			//		telString.Append(digW[j]);
			//		if (telString.Length == telephone.Length)
			//			list.Add(telString.ToString());

			//		// Backtrack
			//		telString.Length--;
			//	}
			//}

			//return list;
        //}
	
	}
}
