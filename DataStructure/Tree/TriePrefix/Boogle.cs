using System;
using System.Text;
using System.Collections.Generic;

namespace Tree
{
    // Source: https://www.geeksforgeeks.org/boggle-set-2-using-trie/
    /*
     * Given a dictionary, a method to do lookup in dictionary and a M x N board
     * where every cell has one character. Find all possible words that can be 
     * formed by a sequence of adjacent characters. Note that we can move to any
     * of 8 adjacent characters, but a word should not have multiple instances 
     * of same cell.
     * 
     * Example:
     * 
     * Input: dictionary[] = {"GEEKS", "FOR", "QUIZ", "GO"};
     * boggle[, ]   = {{'G','I','Z'},
     *                 {'U','E','K'},
     *                 {'Q','S','E'}};
     * isWord(str): returns true if str is present in dictionary else false.
     * 
     * Output:  Following words of dictionary are present
     *      GEEKS
     *      QUIZ
     * 
     * Boggle
     * 
     * Here we discus Trie based solution which is better then DFS base solution.
     * Given Dictionary dictionary[] = {“GEEKS”, “FOR”, “QUIZ”, “GO”}
     * 
     * 1. Create an Empty trie and insert all words of given dictionary into trie
     * 
     * After insertion Tre look like (leaf nodes are in RED )
     *                  root
     *                /       
     *              G   F     Q
     *           /  |   |     |
     *          O   E   O     U
     *              |   |     |
     *              E    R     I
     *              |         |  
     *              K         Z 
     *              |   
     *              S  
     * 
     * 2. After that we have pick only those character in boggle[, ] which are 
     * child of root of Trie
     * 
     * Let for above we pick ‘G’ boggle[0, 0] , ‘Q’ boggle[2, 0] (they both are
     * present in boggle matrix)
     * 
     * 3. search a word in a trie which start with character that we pick 
     * in step 2
     * 
     * 1) Create bool visited boolean matrix (Visited[M, N] = false )
     * 
     * 2) Call SearchWord() for every cell (i, j) which has one of the
     * the first characters of dictionary words. In above example,
     * 
     * we have 'G' and 'Q' as first characters.
     * 
     * SearchWord(Trie *root, i, j, visited[, N])
     *      if root->leaf == true 
     *          print word 
     * 
     *   if we seen this element first time then make it visited.
     *      visited[i, j] = true
     *      do
     *          traverse all child of current root 
     *          k goes (0 to 26 ) [there are only 26 Alphabet] 
     *          add current char and search for next character 
     *          
     *          find next character which is adjacent to boggle[i, j]
     *          they are 8 adjacent cells of boggle[i, j] (i+1, j+1), 
     *          (i+1, j) (i-1, j) and so on.
     * 
     *      make it unvisited visited[i, j] = false 
    */

    public class Boggle
    {
        private MahbubTrie tree;
        private char[,] boggle;
        private bool[,] visited;
        private List<string> results;

        private readonly int[,] locations = new int[,]
        {
                {-1, -1},
                {-1,  0},
                {-1,  1},
                { 0,  1},
                { 1,  1},
                { 1,  0},
                { 1, -1},
                { 0, -1}
        };

        public Boggle(string[] dictionary)
        {
            tree = new MahbubTrie();
            Build(dictionary);
        }

        private void Build(string[] dictionary)
        {
            // insert all words of dictionary into trie
            foreach (var word in dictionary)
            {
                tree.Insert(word);
            }
        }

        // function to check that current location
        // (i and j) is in matrix range
        private bool IsValid(int i, int j)
        {
            return (i >= 0 && i < visited.GetLength(0) &&
                    j >= 0 && j < visited.GetLength(1) &&
                    visited[i, j] == false);
        }
    
        // A recursive/backtracking function to print all words present on boggle
        private void SearchWord(MahbubTrie.Node subroot, int i, int j, StringBuilder str)
        {
            // If both I and j in  range and we visited
            // that element of matrix first time
            if (!IsValid(i, j))
                return;

            var node = subroot.Get(boggle[i, j]);
            if (node == null)
                return;

            // make it visited
            visited[i, j] = true;
            str.Append(boggle[i, j]);

            // if we found word in trie / dictionarys
            if (node.IsTerminal == true)
            {
                results.Add(str.ToString());
            }

            // Recursively search reaming character of word
            // in trie for all 8 adjacent cells of boggle[i, j]
            for (int l = 0; l < locations.GetLength(0); l++)
            {
                var r = i + locations[l, 0];
                var c = j + locations[l, 1];
                SearchWord(node, r, c, str);
            }

            // make current element unvisited (backtrack)
            visited[i, j] = false;
        }
        
        public List<string> FindWords(char[,] boggleToSearch)
        {
            boggle = boggleToSearch;
            // Mark all characters as not visited
            visited = new bool[boggle.GetLength(0), boggle.GetLength(1)];
            results = new List<string>();

            // traverse all matrix elements
            for (int i = 0; i < boggle.GetLength(0); i++)
            {
                for (int j = 0; j < boggle.GetLength(1); j++)
                {
                    // we start searching for word in dictionary
                    // if we found a character which is child
                    // of Trie root
                    var str = new StringBuilder();
                    SearchWord(tree.Root, i, j, str);
                }
            }
            return results;
        }
    }
}
