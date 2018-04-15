using System;

namespace SkipList
{
    public class Node<T> where T: IComparable<T>
    {
        public T Data;

        public Node<T>[] Forward;

        public Node(T d, int level)
        {
            Data = d;
            Forward = new Node<T>[level];
        }

    }

    public class SkipList<T> where T:IComparable<T>
    {
        public int Size { get; }

        // Fraction is the fraction of the nodes with level 
        // i pointers also having level i+1 pointers
        public double Fraction { get; }

        // Current level of skip list
        private int level;

        private Node<T> head;

        private static Random rand  = new Random();

        public SkipList(int size, double fraction)
        {
            Size = size;
            Fraction = fraction;

            level = 0;

            head = new Node<T>(default(T), Size);
        }

        // create random level for node
        private int RandomLevel()
        {
            double r = rand.NextDouble();
            int lvl = 0;
            while (r < Fraction && lvl < Size)
            {
                lvl++;
                r = rand.NextDouble();
            }
            return lvl;
        }

        public void Insert(T data)
        {
            var searchResult = SearchNode(data);
            var current = searchResult.Item1;
            var update = searchResult.Item2;

            // if current is NULL that means we have reached to end of the level
            // or current's key is not equal to key to insert
            // that means we have to insert node between update[0] and current node
            if (current == null || current.Data.CompareTo(data) != 0)
            {
                // Generate a random level for node
                int rlevel = RandomLevel();

                // If random level is greater than list's current
                // level (node with highest level inserted in 
                // list so far), initialize update value with pointer
                // to header for further use
                if (rlevel > level)
                {
                    for (int i = level + 1; i < rlevel + 1; i++)
                        update[i] = head;

                    // Update the list current level
                    level = rlevel;
                }

                // create new node with random level generated
                var n = new Node<T>(data, rlevel);

                // insert node by rearranging pointers 
                for (int i = 0; i <= rlevel; i++)
                {
                    n.Forward[i] = update[i].Forward[i];
                    update[i].Forward[i] = n;
                }
            }
        }

        // Delete element from skip list
        public void Delete(T data)
        {
            var searchResult = SearchNode(data);
            var current = searchResult.Item1;
            var update = searchResult.Item2;

            // If current node is target node
            if (current != null && current.Data.CompareTo(data) == 0)
            {
                // Start from lowest level and rearrange pointers just like we
                // do in singly linked list to remove target node
                for (int i = 0; i <= level; i++)
                {
                    // If at level i, next node is not target node, break the 
                    // loop, no need to move further level
                    if (update[i].Forward[i] != current)
                        break;

                    update[i].Forward[i] = current.Forward[i];
                }

                // Remove levels having no elements 
                while (level > 0 && head.Forward[level] == null)
                    level--;
            }
        }

        public bool Search(T data)
        {
            var current = SearchNode(data).Item1;
            // If current node have key equal to
            // search key, we have found our target node
            if (current != null && current.Data.CompareTo(data) == 0)
                return true;

            return false;
        }

        // Search for element in skip list
        private Tuple<Node<T>, Node<T>[]> SearchNode(T data)
        {
            var current = head;

            // create update array and initialize it
            var update = new Node<T>[Size + 1];

            // start from highest level of skip list
            for (int i = level; i >= 0; i--)
            {
                // Move the current pointer forward while key is greater than key of node next to current
                while (current.Forward[i] != null && current.Forward[i].Data.CompareTo(data) < 0)
                    current = current.Forward[i];
                // Insert current in update and move one level down and continue search
                update[i] = current;
            }

            // reached level 0 and forward pointer to right,
            // which is desired position to insert key.
            current = current.Forward[0];

            return new Tuple<Node<T>, Node<T>[]>(current, update);
        }
    }
}
