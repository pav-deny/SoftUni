namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new() { "Hello", "World!", "I'm", "Me" };

            list.RemoveAt(2);

            list.Insert(2, "I am");
            Console.WriteLine(string.Join(" ", list));

            list.Insert(2, ",");

            Console.WriteLine(string.Join(" ", list));

            
        }
    }
}
