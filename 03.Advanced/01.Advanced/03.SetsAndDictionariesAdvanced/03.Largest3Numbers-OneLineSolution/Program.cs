namespace _03.Largest3Numbers_OneLineSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderByDescending(x => x).Take(3))));
        }
    }
}
