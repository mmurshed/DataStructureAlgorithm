using System;
using System.Collections.Generic;

namespace Sorting
{
    /// <summary>
    /// For floating point numbers between 0.0 to 1.0
    /// </summary>
    public class BucketSort : SortBase<float>
    {
        public override void Sort(float[] data)
        {
            var bucket = new List<float>[data.Length];

            // 1. put into bucket
            for (int i = 0; i < data.Length; i++)
            {
                int idx = (int)(data.Length * data[i]);
                bucket[idx].Add(data[i]);
            }

            // 2. Sort each bucket
            for (int i = 0; i < data.Length; i++)
            {
                bucket[i].Sort();
            }

            // 3. Concat
            int j = 0;
            for (int i = 0; i < data.Length; i++)
            {
                foreach (var d in bucket[i])
                {
                    data[j++] = d;
                }
            }
        }
    }
}
