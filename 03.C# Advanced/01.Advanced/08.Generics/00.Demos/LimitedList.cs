namespace _00.Demos
{
    ///<summary>
    ///List of maximum 4 elements
    /// </summary>
    public class LimitedList<T>
    {
        private T[] items;
        private int index;

        public LimitedList()
        {
            items = new T[4];
            index = 0;
        }

        public void Add(T item)
        {
            if (index >= items.Length)
                return;

            items[index] = item;
            index++;
        }

        public T Get(int index)
        {
            if (index >= items.Length || index < 0)
                throw new IndexOutOfRangeException("Index must be in [0; 3]");

            return items[index];
        }
    }
}
