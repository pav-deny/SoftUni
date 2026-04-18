namespace CustomLinkedList
{
    public class MyLinkedListNode
    {
        public MyLinkedListNode Previous {  get; set; }
        public MyLinkedListNode Next { get; set; }
        public int Value { get; set; }

        public MyLinkedListNode(int value)
        {
            Value = value;
        }
    }
}
