using System.ComponentModel;

namespace CustomQueue
{
    public class MyQueue
    {
        private const int InitialCapacity = 4;

        private int[] arr;
        private int count;
        private int startPos;

        public int Count => count;

        public MyQueue() : this(InitialCapacity) { }

        public MyQueue(int capacity)
        {
            arr = new int[capacity];
        }

        public void Enqueue(int element)
        {
            GrowIfNecessary();

            arr[GetBufferIndex(count)] = element;
            count++;
        }

        public int Dequeue()
        {
            int removedNum = Peek();

            arr[startPos] = default;
            startPos = GetBufferIndex(1);

            count--;
            return removedNum;
        }

        public int Peek()
        {
            ValidateNotEmpty();
            return arr[startPos];
        }

        public int[] ToArray()
        {
            int[] result = new int[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = arr[GetBufferIndex(i)];
            }

            return result;
        }

        private int GetBufferIndex(int offset) => (startPos + offset) % arr.Length;

        private void ValidateNotEmpty()
        {
            if (count == 0)
                throw new InvalidOperationException("Cannot execute this operation on an empty queue");
        }

        private void GrowIfNecessary()
        {
            if (count == arr.Length)
            {
                int[] newArr = new int[arr.Length * 2];

                Array.Copy(arr, startPos, newArr, startPos, count - startPos);
                Array.Copy(arr, 0, newArr, count, startPos);

                arr = newArr;
            } 
        }
    }
}
