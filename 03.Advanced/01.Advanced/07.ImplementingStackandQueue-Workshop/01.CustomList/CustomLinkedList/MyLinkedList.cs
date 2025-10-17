namespace CustomLinkedList
{
    public class MyLinkedList
    {
        public MyLinkedListNode Start { get; private set; }
        public MyLinkedListNode End { get; private set; }
        public int Count { get; private set; }

        public MyLinkedList()
        {
            Start = new MyLinkedListNode(-1);
            End = new MyLinkedListNode(-1);

            Start.Next = End;
            End.Previous = Start;
        }

        public void AddFirst(int value)
        {
            InsertBetween(Start, Start.Next, value);
        }

        public void AddLast(int value)
        {
           InsertBetween(End.Previous, End, value);
        }

        public void RemoveFirst()
        {
            ValidateNotEmpty();
            RemoveBetween(Start, Start.Next.Next);
        }

        public void RemoveLast()
        {
            ValidateNotEmpty();
            RemoveBetween(End.Previous.Previous, End);
        }

        public int GetFirst()
        {
            ValidateNotEmpty();
            return Start.Next.Value;
        }

        public int GetLast()
        {
            ValidateNotEmpty();
            return End.Previous.Value;
        }

        private void ValidateNotEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException("Cannot execute this operation on an empty linked list");
        }

        private void InsertBetween(MyLinkedListNode a, MyLinkedListNode b, int value)
        {
            MyLinkedListNode node = new(value);

            node.Previous = a;
            a.Next = node;

            node.Next = b;
            b.Previous = node;

            Count++;
        }

        private void RemoveBetween(MyLinkedListNode a, MyLinkedListNode b)
        {
            a.Next.Previous = null;
            a.Next = b;

            b.Previous.Next = null;
            b.Previous = a;

            Count--;
        }
    }
}
