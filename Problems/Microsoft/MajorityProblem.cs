using System;
namespace Algorithm.MicrosoftProblems
{
    // https://www.geeksforgeeks.org/majority-element/
    /*
The algorithm for first phase that works in O(n) is known as Moore’s Voting 
Algorithm. Basic idea of the algorithm is that if we cancel out each occurrence 
of an element e with all the other elements that are different from e then e 
will exist till end if it is a majority element.

findCandidate(a[], size)
1.  Initialize index and count of majority element
     maj_index = 0, count = 1
2.  Loop for i = 1 to size – 1
    (a) If a[maj_index] == a[i]
          count++
    (b) Else
        count--;
    (c) If count == 0
          maj_index = i;
          count = 1
3.  Return a[maj_index]
    */
    public class MajorityProblem
    {

        bool FindCandidate(int[] a)
        {
            int maj = 0;
            int count = 1;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[maj] == a[i])
                    count++;
                else count--;
                if(count == 0)
                {
                    maj = i;
                    count = 1;
                }
            }
            return IsMajority(a, a[maj]);
        }

        bool IsMajority(int[] a, int maj)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == maj)
                    count++;
            }

            return count >= a.Length / 2;
        }
        
    }
}
