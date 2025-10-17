namespace CustomLinkedStack
{
    public class MyLinkedStack
    {
        private readonly MyLinkedStackNode start;
        private int count;

        public int Count => count;

        public MyLinkedStack()
        {
            start = new MyLinkedStackNode(-1);
        }

        public void Push(int element)
        {
            MyLinkedStackNode previousTop = start.Next;
            MyLinkedStackNode newNode = new(element);

            newNode.Next = previousTop;
            start.Next = newNode;

            count++;
        }

        public int Pop()
        {
            int removed = this.Peek();

            MyLinkedStackNode currentTop = start.Next;
            MyLinkedStackNode newTop = start.Next.Next;

            currentTop.Next = null;
            start.Next = newTop;

            count--;

            return removed;
        }

        public int Peek()
        {
            ValidateNotEmpty();
            return start.Next.Value;
        }

        public int[] ToArray()
        {
            int[] arr = new int[count];

            MyLinkedStackNode currentNode = start.Next;

            for (int i = 0; i < count && currentNode is not null; i++, currentNode = currentNode.Next)
                arr[i] = currentNode.Value;

            return arr;
        }

        private void ValidateNotEmpty()
        {
            if (count == 0)
                throw new InvalidOperationException("Cannot execute this operation on an empty stack");
        }
    }
}
