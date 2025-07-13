namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new() { "A", "B", "c", "D", "E" };

            strings.RemoveAt(2);

            strings.Insert(2, "C");

            Console.WriteLine(String.Join(", ", strings));
        }
    }
}
