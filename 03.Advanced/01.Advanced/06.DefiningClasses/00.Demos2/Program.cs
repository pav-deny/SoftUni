namespace _00.Demos2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Static.Print();
            Console.WriteLine(Static.Property);

            Static.Property = 10;
            Console.WriteLine(Static.Property);
        }
    }
}
