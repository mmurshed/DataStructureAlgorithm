using System;
namespace DataStructurePractice.GoogleProblems
{
   public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }

    public class MergeKListsClass
    {
        public static int FindMin(ListNode[] lists)
        {
            int min = 0;
            for (int i = 1; i < lists.Length; i++)
            {
                if ( lists[min] == null || (lists[i] != null && lists[i].val < lists[min].val) )
                {
                    min = i;
                }
            }
            return min;
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;

            ListNode head = null;
            ListNode cur = null;

            while (true)
            {
                int min = FindMin(lists);

                if (lists[min] == null)
                    break;

                ListNode newNode = new ListNode(lists[min].val);
                if (cur == null)
                {
                    cur = newNode;
                    head = cur;
                }
                else
                {
                    cur.next = newNode;
                    cur = cur.next;
                }

                lists[min] = lists[min].next;
            }
            return head;
        }
    }
}
