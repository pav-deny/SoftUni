namespace CustomLinkedStack
{
    public class MyLinkedStackNode
    {
        public MyLinkedStackNode Next { get; set; }
        public int Value { get; set; }

        public MyLinkedStackNode(int value)
        {
            Value = value;
        }
    }
}
