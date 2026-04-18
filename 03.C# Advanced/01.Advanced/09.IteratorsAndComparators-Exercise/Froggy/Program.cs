namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] stones = Console.ReadLine().Split(new string[]{ ", ", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Lake lake = new(stones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
