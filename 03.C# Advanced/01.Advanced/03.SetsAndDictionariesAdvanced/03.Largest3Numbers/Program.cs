namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).OrderByDescending(x => x).Take(3).ToArray();

            Console.WriteLine(string.Join(" ", ints));
        }
    }
}
