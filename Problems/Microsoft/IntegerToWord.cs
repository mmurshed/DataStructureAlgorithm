using System;
using System.Text;

namespace Algorithm.MicrosoftProblems
{
    public class IntegerToWord
    {
        private string[] digitsStr = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private string[] tensStr = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private string[] hundredsStr = new string[] { "Hundred", "Thousand", "Million", "Billion"};
        private int[] hundredsNum = new int[] { 1, 1000, 1000000, 1000000000 };

        public string Convert(int n)
        {
            if (n == 0)
                return digitsStr[0];

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = hundredsNum.Length - 1; i >= 0; i--)
            {
                int h = n / hundredsNum[i];
                if (h > 0 && stringBuilder.Length > 0)
                    stringBuilder.Append(" ");
                if (h > 0)
                    stringBuilder.Append(ConvertHundreds(h));
                if(h > 0 && i > 0 && stringBuilder.Length > 0)
                    stringBuilder.Append(" " + hundredsStr[i]);

                n %= hundredsNum[i];
            }

            return stringBuilder.ToString();
        }

        public string ConvertHundreds(int n)
        {
            if (n == 0)
                return digitsStr[0];
            StringBuilder stringBuilder = new StringBuilder();
            int hundred = n / 100;
            if (hundred > 0)
                stringBuilder.Append(digitsStr[hundred] + " " + hundredsStr[0]);
            int tens = n % 100;
            if(tens < 20 && tens > 0)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(" ");
                stringBuilder.Append(digitsStr[tens]);
            }
            else if(tens >= 20)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(" ");

                int twenties = tens / 10 - 2; // Ofset for string position
                stringBuilder.Append(tensStr[twenties]);
                int digit = tens % 10;
                if(digit > 0)
                {
                    if (stringBuilder.Length > 0)
                        stringBuilder.Append(" ");
                    stringBuilder.Append(digitsStr[digit]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
