namespace CustomLinkedList
{
    public class ListNode<TNode>
    {
        public TNode Value { get; set; }
        public ListNode<TNode> Previous { get; set; }
        public ListNode<TNode> Next { get; set; }

        public ListNode(TNode value)
        {
            this.Value = value;
        }
    }
}
