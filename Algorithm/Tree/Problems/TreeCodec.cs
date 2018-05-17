using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.Tree.Problems
{
    public class TreeCodec
    {
		private char seperator;
		private char nullid;
		private readonly string nullidstr;

		public TreeCodec(char sep = ',', char nullid = '$')
		{
			this.seperator = sep;
			this.nullid = nullid;
			this.nullidstr = nullid.ToString();
		}

		private int? GetInt(string val)
        {
            return string.Equals(val, nullidstr) ? null : (int?)Convert.ToInt32(val);
        }

        private string GetString(int? val)
        {
            return val == null ? nullidstr : val.ToString();
        }

		public string Serialize2(TreeNode root)
		{
			if (root == null)
				return string.Empty;

			var list = SerializeToList(root);
			return list.Select(x => GetString(x) ).Aggregate((x, y) => x + seperator + y);
		}

		// Run BFS
		public List<int?> SerializeToList(TreeNode root)
		{
			var list = new List<int?>();
			if (root == null)
				return list;
			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while(queue.Count > 0)
			{
				var node = queue.Dequeue();
				if(node != null)
				{
					queue.Enqueue(node.left);
					queue.Enqueue(node.right);
					list.Add(node.val);              
				}
				else
				{
					list.Add(null);
				}
			}

			// Trim last null values
			int i = list.Count - 1;
			while (list[i] == null)
				i--;
			if(i < list.Count - 1)
			    list.RemoveRange(i + 1, list.Count - i - 1);

			return list;
		}

		public string Serialize(TreeNode root)
        {
            if (root == null)
                return string.Empty;
            var strb = new StringBuilder();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                    strb.Append(node.val);
                }
                else
                {
                    strb.Append(nullid);
                }
				if (strb.Length > 0)
                    strb.Append(seperator);
            }

            // Trim last null values
			int i = strb.Length - 1;
			while (strb[i] == nullid || strb[i] == seperator)
                i--;
			if (i < strb.Length - 1)
				strb.Remove(i + 1, strb.Length - i - 1);

			return strb.ToString();
        }
	
		public TreeNode Deserialize2(string data)
		{
			if (string.IsNullOrEmpty(data))
				return null;
			var parts = data.Split(seperator);
			var vals = parts.Select(part => GetInt(part)).ToList<int?>();
			return Deserialize(vals);
		}

		// BFS
        public TreeNode Deserialize(List<int?> array)
        {
            if (array == null || array.Count == 0 || array[0] == null)
				return null;

            var root = new TreeNode(array[0] ?? 0);

			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			int i = 1;
			while(queue.Count > 0)
			{
				var node = queue.Dequeue();
				if (i < array.Count)
                {
					if (array[i] != null)
                    {
						node.left = new TreeNode(array[i] ?? 0);
						queue.Enqueue(node.left);
                    }
                    i++;
                }

				if (i < array.Count)
                {
					if (array[i] != null)
                    {
						node.right = new TreeNode(array[i] ?? 0);
						queue.Enqueue(node.right);
                    }
                    i++;
                }
			}

            return root;
        }


		// BFS
		public TreeNode Deserialize(string data)
        {
			if (string.IsNullOrEmpty(data))
                return null;

			var array = data.Split(seperator);

			if (array == null || array.Length == 0)
				return null;
			
			var root = new TreeNode(GetInt(array[0]) ?? 0);

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int i = 1;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
				if (i < array.Length)
                {
					var d = GetInt(array[i]);
                    if (d != null)
                    {
						node.left = new TreeNode(d ?? 0);
                        queue.Enqueue(node.left);
                    }
                    i++;
                }

				if (i < array.Length)
                {
					var d = GetInt(array[i]);
                    if (d != null)
                    {
						node.right = new TreeNode(d ?? 0);
                        queue.Enqueue(node.right);
                    }
                    i++;
                }
            }

            return root;
        }
	}
}
