
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using DataStructure.Queue;

namespace Algorithm.Facebook
{
    public class LeastIntervalProblem
    {
        public int LeastInterval(char[] tasks, int n)
        {
            int unique = 0;
            var map = new int[26];
            foreach (var c in tasks)
            {
                if (map[c - 'A'] == 0)
                    unique++;
                map[c - 'A']++;
            }

            var pq = new PriorityQueueSimple(unique);
            for(int i = 0; i < 26; i++)
            {
                if(map[i] != 0)
                    pq.Enqueue(map[i]);
            }

            int time = 0;

            while (pq.count > 0)
            {
                int i = 0;
                var temp = new List<int>();
                while (i <= n && pq.count > 0)
                {
                    int d = pq.Dequeue() - 1;
                    if (d > 0)
                        temp.Add(d);
                    time++;
                    i++;
                }

                if (pq.count == 0 && temp.Count == 0)
                    break;
                // idle
                time += (n - i + 1);

                foreach (var m in temp)
                    pq.Enqueue(m);
            }

            return time;
        }


        public int LeastInterval2(char[] tasks, int n)
        {
            int unique = 0;
            var map = new int[26];
            foreach (var c in tasks)
            {
                if (map[c - 'A'] == 0)
                    unique++;
                map[c - 'A']++;
            }

            var sl = new SortedList<int, int>(unique);
            for (int i = 0; i < 26; i++)
            {
                if (map[i] != 0)
                    sl.Add(map[i], map[i]);
            }

            int time = 0;

            while (sl.Count > 0)
            {
                int i = 0;
                var temp = new List<int>();
                while (i <= n && sl.Count > 0)
                {
                    int d = sl.First().Key - 1;
                    sl.RemoveAt(0);
                    if (d > 0)
                        temp.Add(d);
                    time++;
                    i++;
                }

                if (sl.Count == 0 && temp.Count == 0)
                    break;
                // idle
                time += (n - i + 1);

                foreach (var m in temp)
                    sl.Add(m, m);
            }

            return time;
        }

    }
}
