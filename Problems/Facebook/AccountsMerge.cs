using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Facebook
{
    public class AccountsMergeProblem
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var dict = new Dictionary<string, int>();
            var N = accounts.Count;
            var graph = new HashSet<int>[N];

            for (int i = 0; i < N; i++)
            {
                graph[i] = new HashSet<int>();
            }

            for (int i = 0; i < N; i++)
            {
                var a = accounts[i];
                for (int j = 1; j < a.Count; j++)
                {
                    var e = a[j];
                    if (!dict.ContainsKey(e))
                    {
                        dict.Add(e, i);
                        continue;
                    }

                    int to = dict[e];
                    if(!graph[i].Contains(to))
                        graph[i].Add(to);
                    if (!graph[to].Contains(i))
                        graph[to].Add(i);
                }
            }

            bool[] visited = new bool[N];
            var list = new HashSet<string>[N];
            for (int i = 0; i < N; i++)
            {
                DFS(graph, i, visited, accounts, list);
            }

            var ret = new List<IList<string>>();

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == null)
                    continue;

                var ll = new List<string>();
                ll.Add(accounts[i][0]);

                foreach (var s in list[i])
                    ll.Add(s);

                ll.Sort(1, ll.Count - 1, StringComparer.Ordinal);
                ret.Add(ll);
            }

            return ret;
        }

        private void DFS(HashSet<int>[] graph, int s, bool[] visited, IList<IList<string>> accounts, ICollection<string>[] list)
        {
            if (visited[s])
                return;
            var q = new Queue<int>();
            q.Enqueue(s);

            while (q.Count > 0)
            {
                int a = q.Dequeue();
                if (visited[a])
                    continue;

                visited[a] = true;

                AddAccount(accounts[a], list, s);
                foreach (var b in graph[a])
                {
                    q.Enqueue(b);
                }
            }
        }

        private void AddAccount(IList<string> account, ICollection<string>[] list, int s)
        {
            for (int j = 1; j < account.Count; j++)
            {
                if (list[s] == null)
                    list[s] = new HashSet<string>();
                if (!list[s].Contains(account[j]))
                    list[s].Add(account[j]);
            }
        }

        public IList<IList<string>> AccountsMergeDeprecated(IList<IList<string>> accounts)
        {
            var N = accounts.Count;
            var dict = new Dictionary<string, int>();
            var list = new Dictionary<int, HashSet<string>>();

            for (int i = 0; i < N; i++)
            {
                var a = accounts[i];
                int to = -1;
                for (int j = 1; j < a.Count; j++)
                {
                    var e = a[j];
                    if (dict.ContainsKey(e))
                    {
                        to = dict[e];
                        break;
                    }
                }

                if (to == -1)
                    to = i;

                if (!list.ContainsKey(to))
                    list[to] = new HashSet<string>();
                var set = list[to];

                for (int j = 1; j < a.Count; j++)
                {
                    var e = a[j];

                    if (!dict.ContainsKey(e))
                        dict.Add(e, to);

                    if (!set.Contains(e))
                        set.Add(e);
                }
            }

            var ret = new List<IList<string>>();

            foreach (var it in list)
            {
                var k = it.Key;

                var ll = new List<string>();
                ll.Add(accounts[k][0]);

                foreach (var s in it.Value)
                    ll.Add(s);

                ll.Sort(1, ll.Count - 1, StringComparer.Ordinal);
                ret.Add(ll);
            }

            return ret;
        }


    }
}