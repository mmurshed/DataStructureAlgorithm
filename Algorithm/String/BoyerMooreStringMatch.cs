using System;
using System.Collections.Generic;

namespace Algorithm.String
{
    /*
Boyer Moore is a combination of following two approaches.
1) Bad Character Heuristic
2) Good Suffix Heuristic

Both of the above heuristics can also be used independently to search a pattern
in a text. Let us first understand how two independent approaches work together
in the Boyer Moore algorithm. If we take a look at the Naive algorithm, it 
slides the pattern over the text one by one. KMP algorithm does preprocessing 
over the pattern so that the pattern can be shifted by more than one. The Boyer
Moore algorithm does preprocessing for the same reason. It preporcesses the 
pattern and creates different arrays for both heuristics. At every step, it 
slides the pattern by max of the slides suggested by the two heuristics. 
So it uses best of the two heuristics at every step.

Unlike the previous pattern searching algorithms, Boyer Moore algorithm starts 
matching from the last character of the pattern.

In this post, we will discuss bad character heuristic, and discuss Good Suffix 
heuristic in the next post.

Bad Character Heuristic

The idea of bad character heuristic is simple. The character of the text which 
doesn’t match with the current character of pattern is called the Bad Character.
Upon mismatch we shift the pattern until –
1) The mismatch become a match
2) Pattern P move past the mismatch character.

Case 1 – Mismatch become match
We will lookup the position of last occurence of mismatching character in 
pattern and if mismatching character exist in pattern then we’ll shift the 
pattern such that it get aligned to the mismatching character in text T.
case 1
case 1


Explanation: In the above example, we got a mismatch at position 3. Here our 
mismatching character is “A”. Now we will search for last occurence of “A” in 
pattern. We got “A” at position 1 in pattern (displayed in Blue) and this is 
the last occurence of it. Now we will shift pattern 2 times so that “A” in 
pattern get aligned with “A” in text.

Case 2 – Pattern move past the mismatch character
We’ll lookup the position of last occurence of mismatching character in pattern 
and if character does not exist we will shift pattern past the mismatching 
character.
case2
case2


Explanation: Here we have a mismatch at position 7. The mismatching character 
“C” does not exist in pattern before position 7 so we’ll shift pattern past 
to the position 7 and eventually in above example we have got a perfect match
of pattern (displayed in Green). We are doing this because, “C” do not exist 
in pattern so at every shift before position 7 we will get mismatch and our 
search will be fruitless.

In following implementation, we preprocess the pattern and store the last 
occurrence of every possible character in an array of size equal to alphabet 
size. If the character is not present at all, then it may result in a shift 
by m (length of pattern). Therefore, the bad character heuristic takes O(n/m) 
time in the best case.
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
