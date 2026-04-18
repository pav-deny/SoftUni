namespace RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int result = Sum(nums);

            Console.WriteLine(result);
        }

        static int Sum(int[] nums, int index = 0)
        {
            if (index == nums.Length)
                return 0;

            int currentElement = nums[index];

            return currentElement + Sum(nums, index + 1);
        }
    }
}
