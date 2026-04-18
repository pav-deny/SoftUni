namespace CustomDoublyLinkedList
{
    internal class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int num)
        {
            ListNode newHead = new(num);

            if (head == null)
            {
                head = newHead;
                tail = newHead;

                Count++;
                return;
            }

            head.Previous = newHead;
            newHead.Next = head;
            head = newHead;

            Count++;
        }

        public void AddLast(int num)
        {
            ListNode newTail = new(num);

            if (tail == null)
            {
                head = newTail;
                tail = newTail;

                Count++;
                return;
            }

            tail.Next = newTail;
            newTail.Previous = tail;
            tail = newTail;

            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            int removedElement = head.Value;
            head = head.Next;

            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }

            Count--;
            return removedElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            int removedElement = tail.Value;
            tail = tail.Previous;

            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return removedElement;
        }

        public void ForEach(Action<int> action)
        {
            ListNode node = head;

            while (node != null)
            {
                action(node.Value);
                node = node.Next;
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[Count];

            ListNode node = head;

            for (int i = 0; i < Count; i++)
            {
                arr[i] = node.Value;
                node = node.Next;
            }

            return arr;
        }
    }
}
