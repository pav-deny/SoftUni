namespace GenericArrayCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] s = ArrayCreator.Create<string>(3, "Joe");
        }
    }
}
