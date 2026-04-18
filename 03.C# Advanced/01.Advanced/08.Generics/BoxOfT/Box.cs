namespace BoxOfT
{
    public class Box<T>
    {
        private const int InitialCapacity = 4;
        private List<T> elements;

        public int Count => elements.Count;

        public Box()
        {
            elements = new List<T>();
        }

        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T removed = elements[Count - 1];
            elements.RemoveAt(Count - 1);
            return removed;
        }
    }
}
