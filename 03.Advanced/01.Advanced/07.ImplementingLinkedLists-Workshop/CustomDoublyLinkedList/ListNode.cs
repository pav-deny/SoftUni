namespace CustomDoublyLinkedList
{
    public class ListNode
    {
        public int Value { get; set; }
        public ListNode Previous { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int value)
        {
            this.Value = value;
        }
    }
}
