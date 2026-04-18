namespace CustomList
{
    public class MyList
    {
        private const int DefaultCapacity = 4;
        private int[] arr;
        private int count;

        public int Count => this.count;
        public int Capacity => this.arr.Length;
        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.arr[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.arr[index] = value;
            }
        }

        public MyList() : this(DefaultCapacity) { }
        public MyList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be a positive number");

            this.arr = new int[capacity];
        }


        public void Add(int element)
        {
            GrowIfNecessary();

            this.arr[this.count] = element;
            this.count++;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index + 1; i < this.count; i++)
                this.arr[i - 1] = this.arr[i];

            this.arr[count - 1] = default;
            this.count--;

            if (this.arr.Length / 2 == count)
                Shrink();
                
        }

        public void Insert(int index, int element)
        {
            if (index == this.count)
            {
                this.Add(element);
                return;
            }

            this.ValidateIndex(index);
            GrowIfNecessary();

            for (int i = count - 1; i >= index; i--)
                this.arr[i + 1] = this.arr[i];

            this.arr[index] = element;
            this.count++;
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

        private void Shrink()
        {
            int[] resizedArr = new int[this.arr.Length / 2];
            Array.Copy(this.arr, resizedArr, this.count);
            this.arr = resizedArr;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException($"Index must be between 0 and {this.Count - 1}");
        }
    }
}
