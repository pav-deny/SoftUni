namespace _00.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            list.RemoveRange(4, 2);
            list.RemoveRange(3, 2);

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
