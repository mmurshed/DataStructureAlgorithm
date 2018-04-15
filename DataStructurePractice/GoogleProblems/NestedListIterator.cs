using System;
using System.Collections.Generic;

namespace DataStructurePractice.GoogleProblems
{
    /*
     * Key point is HasNext needs to do the actual recursion,
     * just like MoveNext does in .NET library
    */


     // This is the interface that allows for creating nested lists.
     // You should not implement it, or speculate about its implementation
     public interface NestedInteger {
          // @return true if this NestedInteger holds a single integer, rather than a nested list.
          bool IsInteger();
     
          // @return the single integer that this NestedInteger holds, if it holds a single integer
          // Return null if this NestedInteger holds a nested list
          int GetInteger();
     
          // @return the nested list that this NestedInteger holds, if it holds a nested list
          // Return null if this NestedInteger holds a single integer
          IList<NestedInteger> GetList();
     }

    public class NestedIntegerT : NestedInteger {
        int integer;
        IList<NestedInteger> nested;
        bool isInt;
        public NestedIntegerT(int i)
        {
            integer = i;
            isInt = true;
        }

        public NestedIntegerT(IList<NestedInteger> n)
        {
            nested = n;
            isInt = false;
        }

        public bool IsInteger()
        {
            return isInt;
        }
        public int GetInteger()
        {
            return integer;
        }
        public IList<NestedInteger> GetList()
        {
            return nested;
        }
    }

    public class NestedIterator
    {
        private int current;
        private Stack<IEnumerator<NestedInteger>> stack;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            stack = new Stack<IEnumerator<NestedInteger>>();
            stack.Push(nestedList.GetEnumerator());
        }

        private void Clear()
        {
            while (stack.Count > 0 && stack.Peek().MoveNext() == false)
            {
                stack.Pop();
            }
        }

        public int Next()
        {
            return current;
        }

        public bool HasNext()
        {
            Clear();

            if (stack.Count == 0)
                return false;

            NestedInteger currentInt = stack.Peek().Current;
            if(currentInt.IsInteger()) 
            {
                current = currentInt.GetInteger();
            }
            else
            {
                stack.Push(currentInt.GetList().GetEnumerator());
                return HasNext();
            }

            return true;
        }
    }

    public class NestedIterator2
    {
        private class ListIdx
        {
            public IList<NestedInteger> list;
            public int idx;
            public ListIdx(IList<NestedInteger> l, int i)
            {
                list = l;
                idx = i;
            }
        }
        private int current;
        private Stack<ListIdx> stack;

        public NestedIterator2(IList<NestedInteger> nestedList)
        {
            stack = new Stack<ListIdx>();
            stack.Push(new ListIdx(nestedList, 0));
        }

        private void Clear()
        {
            while (stack.Count > 0 && stack.Peek().idx >= stack.Peek().list.Count)
            {
                stack.Pop();
            }
        }

        public int Next()
        {
            return current;
        }

        public bool HasNext()
        {
            Clear();
            if (stack.Count == 0)
                return false;

            NestedInteger currentNi = stack.Peek().list[stack.Peek().idx];
            stack.Peek().idx++;
            if (currentNi.IsInteger())
            {
                current = currentNi.GetInteger();
                Clear();
            }
            else
            {
                stack.Push(new ListIdx(currentNi.GetList(), 0));
                return HasNext();
            }

            return true;
        }
    }


    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
