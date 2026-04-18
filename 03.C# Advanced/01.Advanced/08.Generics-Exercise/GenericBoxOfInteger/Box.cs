namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private T value;

        public T Value => value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {value}";
        }
    }
}
