namespace CustomStack
{
    public class MyStack
    {
        private const int DefaultCapacity = 4;
        private int[] arr;
        private int count;

        public int Count => count;

        public MyStack() : this(DefaultCapacity) { }
        public MyStack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Capacity must be a positive integer");

            arr = new int[capacity];
        }

        public void Push(int element)
        {
            GrowIfNecessary();
            arr[count] = element;
            count++;
        }

        public int Pop()
        {
            int returnVal = Peek();

            arr[count - 1] = default;
            count--;

            return returnVal;
        }

        public int Peek()
        {
            ValidateNotEmpty();
            return arr[count - 1];
        }

        public int[] ToArray()
        {
            int[] result = new int[count];
            Array.Copy(arr, result, count);
            Array.Reverse(result);
            return result;
        }

        private void ValidateNotEmpty()
        {
            if (count == 0)
                throw new InvalidOperationException("Cannot execute this operation on an empty stack");
        }

        private void GrowIfNecessary()
        {
            if (this.count == this.arr.Length)
            {
                int[] resizedArr = new int[this.count * 2];
                Array.Copy(this.arr, resizedArr, this.arr.Length);
                this.arr = resizedArr;
            }
        }
    }
}
