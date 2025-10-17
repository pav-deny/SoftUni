namespace CustomComparator
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            IComparer<int> comparer = Comparer<int>.Create((a, b) =>
            {
                int remainderComparison = Comparer<int>.Default.Compare(Math.Abs(a % 2), Math.Abs(b % 2));

                if (remainderComparison != 0)
                    return remainderComparison;

                return Comparer<int>.Default.Compare(a, b);
            });

            Array.Sort(nums, comparer);
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
