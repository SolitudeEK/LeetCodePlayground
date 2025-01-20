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
    }
}
