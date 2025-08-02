namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new() { "Hi", "Hello", "Yo" };

            list.Remove("Hi");
            Console.WriteLine(string.Join(", ", list));

            list.Remove("My");
            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine(list.IndexOf("Hello"));
            Console.WriteLine(list.IndexOf("Bye"));

        }
    }
}
