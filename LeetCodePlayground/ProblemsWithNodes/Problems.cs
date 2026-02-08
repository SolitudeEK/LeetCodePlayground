using System.Net.Http.Headers;

namespace LeetCodePlayground.ProblemsWithNodes
{
    public class Problems
    {
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            HashSet<int> toDelete = new HashSet<int>(nums);

            var dummy = new ListNode(0, head);
            var traverse = dummy;
            while (traverse.next != null)
            {
                if (toDelete.Contains(traverse.next.val))
                    traverse.next = traverse.next.next;
                else
                    traverse = traverse.next;
            }
            return dummy.next;
        }

        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (root is null) return false;

            return DFSIsSubPath(head, root) || IsSubPath(head, root.right) || IsSubPath(head, root.left);
        }

        private bool DFSIsSubPath(ListNode head, TreeNode root)
        {
            if (head is null) return true;
            if (root is null) return false;

            if (root.val == head.val)
                return DFSIsSubPath(head.next, root.right) || DFSIsSubPath(head.next, root.left);
            else
                return false;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(0);
            var cur = dummy;
            int reminder = 0;

            while(l1 is not null || l2 is not null || reminder != 0)
            {
                int sum = reminder;

                if(l1 is not null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 is not null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                reminder = sum / 10;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
            }

            return dummy.next;
        }

        public bool IsBalanced(TreeNode root)
        {
            int GetHeight(TreeNode node)
            {
                if(node is null) return 0;

                var lHeight = GetHeight(node.left);
                if (lHeight == -1) return -1;

                int rHeight = GetHeight(node.right);
                if(rHeight == -1) return -1;

                if(Math.Abs(lHeight - rHeight) > 1) return -1;

                return Math.Max(lHeight, rHeight)+1;
            }

            return GetHeight(root) != -1;
        }
    }
}
