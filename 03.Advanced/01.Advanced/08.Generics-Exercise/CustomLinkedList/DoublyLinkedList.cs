namespace CustomLinkedList
{
    internal class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            ListNode<T> newHead = new(element);

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

        public void AddLast(T element)
        {
            ListNode<T> newTail = new(element);

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

        public T RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            T removedElement = head.Value;
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

        public T RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            T removedElement = tail.Value;
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

        public void ForEach(Action<T> action)
        {
            ListNode<T> node = head;

            while (node != null)
            {
                action(node.Value);
                node = node.Next;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];

            ListNode<T> node = head;

            for (int i = 0; i < Count; i++)
            {
                arr[i] = node.Value;
                node = node.Next;
            }

            return arr;
        }
    }
}
