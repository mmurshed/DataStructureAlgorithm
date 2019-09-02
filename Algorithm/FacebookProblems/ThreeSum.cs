using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithm.FacebookProblems
{
    public class ThreeSumProblem
    {
        private class Pair : IEquatable<Pair>
        {
            public readonly int x;
            public readonly int y;
            public readonly int z;

            public Pair(int a, int b, int c)
            {
                x = a;
                y = b;
                z = c;
            }

            public bool Equals(Pair p)
            {
                return x == p.x && y == p.y && z == p.z;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as Pair);
            }

            public override int GetHashCode()
            {
                return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
            }
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
                return new List<IList<int>>();
            var list = new HashSet<Pair>();
            var poss = new List<int>();
            var possSet = new HashSet<int>();
            var negs = new List<int>();
            var negsSet = new HashSet<int>();
            int zeros = 0;

            var ordered = nums.OrderBy(x => x);

            foreach (var n in ordered)
            {
                if (n < 0)
                {
                    negs.Add(n);
                    negsSet.Add(n);
                }
                else
                {
                    poss.Add(n);
                    possSet.Add(n);
                }
                if (n == 0)
                    zeros++;
            }

            for (int i = 0; i < negs.Count; i++)
            {
                for (int j = i + 1; j < negs.Count; j++)
                {
                    var x = negs[i];
                    var y = negs[j];
                    var z = -1 * (x + y);
                    if (possSet.Contains(z))
                    {
                        list.Add(new Pair(x, y, z));
                    }
                }
            }

            if(zeros >= 3)
                list.Add(new Pair(0, 0, 0));

            for (int i = 0; i < poss.Count; i++)
            {
                for (int j = i + 1; j < poss.Count; j++)
                {
                    var x = poss[i];
                    var y = poss[j];
                    var z = -1 * (x + y);
                    if (negsSet.Contains(z))
                    {
                        list.Add(new Pair(z, x, y));
                    }
                }
            }


            return list.Select( p => new List<int> {p.x, p.y, p.z} as IList<int> ).ToList();
        }

        public IList<IList<int>> ThreeSum2(int[] num)
        {
            Array.Sort(num); // Sort

            var res = new List<IList<int>>();

            for (int i = 0; i < num.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && num[i] != num[i - 1]))
                {
                    int lo = i + 1;
                    int hi = num.Length - 1;
                    int sum = 0 - num[i];

                    while (lo < hi)
                    {
                        if (num[lo] + num[hi] == sum)
                        {
                            res.Add(new List<int> { num[i], num[lo], num[hi] });

                            // Skip same set
                            while (lo < hi && num[lo] == num[lo + 1])
                                lo++;
                            while (lo < hi && num[hi] == num[hi - 1])
                                hi--;

                            lo++;
                            hi--;
                        }
                        else if (num[lo] + num[hi] < sum)
                            lo++;
                        else
                            hi--;
                    }
                }
            }
            return res;
        }

    }
}
