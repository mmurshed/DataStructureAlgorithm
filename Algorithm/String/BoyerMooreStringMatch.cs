using System;
using System.Collections.Generic;

namespace Algorithm.String
{
    /*
     * Boyer Moore is a combination of following two approaches.
     * 1) Bad Character Heuristic
     * 2) Good Suffix Heuristic
     * 
     * The Naive algorithm slides the pattern over the text one by one. KMP 
     * algorithm does preprocessing over the pattern so that the pattern can be
     * shifted by more than one. The Boyer Moore algorithm does preprocessing 
     * for the same reason. It preporcesses the pattern and creates different 
     * arrays for both heuristics. At every step, it slides the pattern by max
     * of the slides suggested by the two heuristics. So it uses best of the 
     * two heuristics at every step.
     * 
     * Unlike the previous pattern searching algorithms, Boyer Moore algorithm 
     * starts matching from the last character of the pattern.
     * 
     * Bad Character Heuristic
     * The idea of bad character heuristic is simple. The character of the text 
     * which doesn’t match with the current character of pattern is called the 
     * Bad Character. Upon mismatch we shift the pattern until -
     * 1) The mismatch become a match
     * 2) Pattern P move past the mismatch character.
     * 
     * Case 1 – Mismatch become match
     * We will lookup the position of last occurence of mismatching character 
     * in pattern and if mismatching character exist in pattern then we’ll shift
     * the pattern such that it get aligned to the mismatching character in 
     * text T.
     * 
     * 0  1  2  3  4 5 6 7 8 9 0 1 2 3 4 5 6
     * G  C  A [A] T G C C T A T G T G A C C
     * T [A] T [G] T G
     *    |_____^
     * 
     * 0  1  2  3  4 5 6 7 8 9 0 1 2 3 4 5 6
     * G  C  A [A] T G C C T A T G T G A C C
     *       T [A] T G T G
     * 
     * Explanation: In the above example, we got a mismatch at position 3. Here 
     * our mismatching character is "A". Now we will search for last occurence 
     * of "A" in pattern. We got "A" at position 1 in pattern (displayed in 
     * Blue) and this is the last occurence of it. Now we will shift pattern 2 
     * times so that "A" in pattern get aligned with "A" in text.
     * 
     * Case 2 – Pattern move past the mismatch character
     * We’ll lookup the position of last occurence of mismatching character in 
     * pattern and if character does not exist we will shift pattern past the 
     * mismatching character.
     * 
     * 
     * 0  1  2 3 4 5 6  7  8 9 0 1 2 3 4 5 6
     * G  C  A A T G C [C] T A T G T G A C C
     *   [ ] T A T G T [G]
     *    |____________^
     * 
     * 0  1  2 3 4 5 6  7  8 9 0 1 2 3 4 5 6
     * G  C  A A T G C  C  T A T G T G A C C
     *                 [ ] T A T G T G
     *   
     * Explanation: Here we have a mismatch at position 7. The mismatching
     * character "C" does not exist in pattern before position 7 so we’ll shift
     * pattern past to the position 7 and eventually in above example we have 
     * got a perfect match of pattern (displayed in Green). We are doing this 
     * because, "C" do not exist in pattern so at every shift before position 7
     * we will get mismatch and our search will be fruitless.
     * 
     * In following implementation, we preprocess the pattern and store the last 
     * occurrence of every possible character in an array of size equal to 
     * alphabet size. If the character is not present at all, then it may result
     * in a shift by m (length of pattern). Therefore, the bad character 
     * heuristic takes O(n/m) time in the best case.
     * 
     * Good Suffix Heuristic
     * Let t be substring of text T which is matched with substring of pattern P.
     * Now we shift pattern until :
     * 1) Another occurrence of t in P matched with t in T.
     * 2) A prefix of P, which matches with suffix of t
     * 3) P moves past t
     * 
     * Case 1: Another occurrence of t in P matched with t in T
     * Pattern P might contain few more occurrences of t. In such case, we will
     * try to shift the pattern to align that occurrence with t in text T.
     * For example -
     * 
     * 
     * Explanation: In the above example, we have got a substring t of text T 
     * matched with pattern P (in green) before mismatch at index 2. Now we will
     * search for occurrence of t (“AB”) in P. We have found an occurrence 
     * starting at position 1 (in yellow background) so we will right shift the 
     * pattern 2 times to align t in P with t in T. This is weak rule of 
     * original Boyer Moore and not much effective, we will discuss a Strong 
     * Good Suffix rule shortly.
     * 
     * Case 2: A prefix of P, which matches with suffix of t in T
     * It is not always likely that we will find the occurrence of t in P. 
     * Sometimes there is no occurrence at all, in such cases sometimes we can 
     * search for some suffix of t matching with some prefix of P and try to 
     * align them by shifting P. For example -
     * 
     * Explanation: In above example, we have got t (“BAB”) matched with P 
     * (in green) at index 2-4 before mismatch . But because there exists no 
     * occurrence of t in P we will search for some prefix of P which matches 
     * with some suffix of t. We have found prefix “AB” (in the yellow 
     * background) starting at index 0 which matches not with whole t but the 
     * suffix of t “AB” starting at index 3. So now we will shift pattern 3 
     * times to align prefix with the suffix.
     * 
     * Case 3: P moves past t
     * If the above two cases are not satisfied, we will shift the pattern past
     * the t. For example –
     * 
     * Explanation: If above example, there exist no occurrence of t (“AB”) in 
     * P and also there is no prefix in P which matches with the suffix of t. 
     * So, in that case, we can never find any perfect match before index 4, 
     * so we will shift the P past the t ie. to index 5.
    */
    public class BoyerMooreStringMatch : IStringMatch
    {
        private const int SIZE = 256;

        private int[] ComputeLastOccurrences(string text)
        {
            var lastOccurrences = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
                lastOccurrences[i] = -1;
            for (int i = 0; i < text.Length; i++)
                lastOccurrences[text[i]] = i;
            return lastOccurrences;
        }

        public IEnumerable<int> Search(string text, string pattern)
        {
            var lastOccurences = ComputeLastOccurrences(text);

            int i = 0;
            int n = text.Length;
            int m = pattern.Length;

            while(i <= n - m)
            {
                int j = m - 1;
                while (j >= 0 && pattern[j] == text[i + j])
                    j--;
                
                if(j < 0) // Found
                    yield return i;

                if (j == m - 1)
                    i += lastOccurences[text[i + j]];
                else // taking shift = last matched letter
                    i += lastOccurences[text[i + j + 1]];
            }
        }
    }
}
