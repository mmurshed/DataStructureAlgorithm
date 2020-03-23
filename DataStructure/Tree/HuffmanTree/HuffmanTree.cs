using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.Tree
{
    public class HuffmanTree
    {
        public HuffmanNode Root;

        public HuffmanTree(string line)
        {
            Build(line);
        }

        private Dictionary<char, int> BuildFrequencyTable(string line)
        {
            // 1. Build frequencey table
            var frequencyTable = new Dictionary<char, int>();
            foreach (var c in line)
            {
                if (frequencyTable.ContainsKey(c))
                    frequencyTable[c]++;
                else
                    frequencyTable.Add(c, 1);
            }
            return frequencyTable;
        }

        public void Build(string line)
        {
            if (line == null || line == string.Empty)
            {
                return;
            }

            // 1. Build frequencey table
            var frequencyTable = BuildFrequencyTable(line);

            Build(frequencyTable.Keys.ToArray(), frequencyTable.Values.ToArray());
        }
       
        public void Build(char[] line, int[]freq)
        {
            if(line.Length != freq.Length)
            {
                throw new ArgumentException("The input length must match.");
            }

            // 2. Build PiorityQueue
            var priorityQueue = new Queue.PriorityQueue<HuffmanNode>(line.Length);

            for (int i = 0; i < line.Length; i++)
            {
                var node = new HuffmanNode(line[i], freq[i]);
                priorityQueue.Enqueue(node);
            }

            // 3. Build tree
            while (!priorityQueue.Empty)
            {
                var nodeA = priorityQueue.Dequeue();
                var nodeB = priorityQueue.Dequeue();

                if (nodeA != null && nodeB == null)
                {
                    // end
                    Root = nodeA;
                    break;
                }
                else if (nodeA != null && nodeB != null)
                {
                    var nodec = new HuffmanNode('$', nodeA.Value + nodeB.Value);
                    nodec.Left = nodeA;
                    nodec.Right = nodeB;
                    priorityQueue.Enqueue(nodec);
                }
                else if (nodeA == null && nodeB == null)
                {
                    throw new Exception("Invalid priority queue configuration.");
                }
            }
        }

        public List<HuffmanNode> GetCode()
        {
            var strBuilder = new StringBuilder();
            var list = new List<HuffmanNode>();
            list = GetCode(Root, strBuilder, list);
            return list;
        }

        private List<HuffmanNode> GetCode(HuffmanNode node, StringBuilder strBuilder, List<HuffmanNode> list)
        {
            if (node == null)
                return list;
            if(node.Left == null && node.Right == null)
            {
                node.HuffmanCode = strBuilder.ToString();
                list.Add(node);
                return list;
            }

            if (node.Left != null)
            {
                strBuilder.Append('0');
                list = GetCode(node.Left, strBuilder, list);
                strBuilder.Remove(strBuilder.Length - 1, 1);
            }

            if (node.Right != null)
            {
                strBuilder.Append('1');
                list = GetCode(node.Right, strBuilder, list);
                strBuilder.Remove(strBuilder.Length - 1, 1);
            }
            return list;
        }
    }
}