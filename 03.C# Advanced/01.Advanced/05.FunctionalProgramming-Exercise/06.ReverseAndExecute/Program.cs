namespace _06.ReverseAndExecute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int[] result = ReverseAndFilter(nums, x => x % n != 0);
            Console.WriteLine(string.Join(" ", result));
        }

        static int[] ReverseAndFilter(int[] nums, Func<int, bool> condition)
        {
            List<int> result = new();

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (condition(nums[i]))
                    result.Add(nums[i]);
            }

            return result.ToArray();
        }
    }
}
