using System;
namespace Algorithm.DynamicProgramming
{
    public class CatalanNumber
    {
        /*
         * Catalan numbers are a sequence of natural numbers that occurs in many interesting counting problems like following.

1) Count the number of expressions containing n pairs of parentheses which are correctly matched. For n = 3, possible expressions are ((())), ()(()), ()()(), (())(), (()()).

2) Count the number of possible Binary Search Trees with n keys (See this)

3) Count the number of full binary trees (A rooted binary tree is full if every vertex has either two children or no children) with n+1 leaves.


The first few Catalan numbers for n = 0, 1, 2, 3, … are 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, …
        */




        /*
Recursive Solution
Catalan numbers satisfy the following recursive formula.
C_0 = 1 and
C_n+1= SUM OF i = 0 to n (C_i * C_n-i) for n >= 0

Time complexity equivalent to nth catalan number.
T(n) = SUM OF i = 0 to n-1 (T(i)*T(n-i)) for n >= 0

The value of nth catalan number is exponential that makes the time complexity exponential.
        */
        public static ulong GenerateNaive(int n)
        {
            if (n == 0)
                return 1;

            ulong catalan = 1;
            for (int i = 0; i < n; i++)
                catalan += GenerateNaive(i) * GenerateNaive(n - i - 1);

            return catalan;
        }

        /*
         * Dynamic Programming Solution
         * We can observe that the above recursive implementation does a lot of repeated work (we can the same by drawing recursion tree). Since there are overlapping subproblems, we can use dynamic programming for this. Following is a Dynamic programming based implementation in C++.
         * 
         * Time Complexity: Time complexity of above implementation is O(n2)
        */
        // A dynamic programming based function to find nth Catalan number
        public ulong GenerateDP(int n)
        {
            // Table to store results of subproblems
            var catalan = new ulong[n + 1];

            // Initialize first two values in table
            catalan[0] = catalan[1] = 1;

            // Fill entries in catalan[] using recursive formula
            for (int i = 2; i <= n; i++)
            {
                catalan[i] = 0;
                for (int j = 0; j < i; j++)
                    catalan[i] += catalan[j] * catalan[i - j - 1];
            }

            // Return last entry
            return catalan[n];
        }

        /*
         * Using Binomial Coefficient 
We can also use the below formula to find nth catalan number in O(n) time.
C_n = 1/(n+1) * Binomial(2n, n) = 1/(n+1) * 2nCn
        */

        // Returns value of Binomial Coefficient C(n, k)
        ulong BinomialCoeff(ulong n, ulong k)
        {
            ulong res = 1;

            // Since C(n, k) = C(n, n-k)
            if (k > n - k)
                k = n - k;

            // Calculate value of [n*(n-1)*---*(n-k+1)] / [k*(k-1)*---*1]
            for (ulong i = 0; i < k; ++i)
            {
                res *= (n - i);
                res /= (i + 1);
            }

            return res;
        }

        // A Binomial coefficient based function to find nth catalan
        // number in O(n) time
        ulong GenerateBinomial(ulong n)
        {
            // Calculate value of 2nCn
            ulong c = BinomialCoeff(2 * n, n);

            // return 2nCn/(n+1)
            return c / (n + 1);
        }

        /*
         * 
         * https://www.geeksforgeeks.org/applications-of-catalan-numbers/
1. Number of possible Binary Search Trees with n keys.

2. Number of expressions containing n pairs of parentheses which are correctly matched. For n = 3, possible expressions are ((())), ()(()), ()()(), (())(), (()()).

3. Number of ways a convex polygon of n+2 sides can split into triangles by connecting vertices.

4. Number of full binary trees (A rooted binary tree is full if every vertex has either two children or no children) with n+1 leaves.

5. Number of different Unlabeled Binary Trees can be there with n nodes.

6. The number of paths with 2n steps on a rectangular grid from bottom left, i.e., (n-1, 0) to top right (0, n-1) that do not cross above the main diagonal.

7. Number of ways to insert n pairs of parentheses in a word of n+1 letters, e.g., for n=2 there are 2 ways: ((ab)c) or (a(bc)). For n=3 there are 5 ways, ((ab)(cd)), (((ab)c)d), ((a(bc))d), (a((bc)d)), (a(b(cd))).

8. Number of noncrossing partitions of the set {1, …, 2n} in which every block is of size 2. A partition is noncrossing if and only if in its planar diagram, the blocks are disjoint (i.e. don’t cross). For example, below two are crossing and non-crossing partitions of {1, 2, 3, 4, 5, 6, 7, 8, 9}.  The partition {{1, 5, 7},  {2, 3, 8}, {4, 6}, {9}} is crossing and partition {{1, 5, 7}, {2, 3}, {4}, {6}, {8, 9}} is non-crossing.

9. Number of Dyck words of length 2n. A Dyck word is a string consisting of n X’s and n Y’s such that no initial segment of the string has more Y’s than X’s.  For example, the following are the Dyck words of length 6: XXXYYY     XYXXYY     XYXYXY     XXYYXY     XXYXYY.

10. Number of ways to tile a stairstep shape of height n with n rectangles. The following figure illustrates the case n = 4:

11. Number of ways to connect the points on a circle disjoint chords.  This is similar to point 3 above.

12. Number of ways to form a “mountain ranges” with n upstrokes and n down-strokes that all stay above the original line.The mountain range interpretation is that the mountains will never go below the horizon.Mountain_Ranges

13. Number of stack-sortable permutations of {1, …, n}. A permutation w is called stack-sortable if S(w) = (1, …, n), where S(w) is defined recursively as follows: write w = unv where n is the largest element in w and u and v are shorter sequences, and set S(w) = S(u)S(v)n, with S being the identity for one-element sequences.

14. Number of permutations of {1, …, n} that avoid the pattern 123 (or any of the other patterns of length 3); that is, the number of permutations with no three-term increasing subsequence. For n = 3, these permutations are 132, 213, 231, 312 and 321. For n = 4, they are 1432, 2143, 2413, 2431, 3142, 3214, 3241, 3412, 3421, 4132, 4213, 4231, 4312 and 4321
        */
    }
}
