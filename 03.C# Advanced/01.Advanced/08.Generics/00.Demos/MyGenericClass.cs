using System.Windows.Markup;

namespace _00.Demos
{
    /// <summary>
    /// A demo of a Generic class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class MyGenericClass<T>
    {
        private T value;

        public T Value => value; 

        public MyGenericClass(T value)
        {
            this.value = value;
        }

        public T GetValue()
        {
            return value;
        }
    }
}
