namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int minNum = Aggregate(nums, int.MaxValue, (x, y) => x < y ? x : y);
            Console.WriteLine(minNum);
        }

        static int Aggregate(int[] nums, int initialValue, Func<int, int, int> func)
        {
            int result = initialValue;

            foreach (int num in nums)
                result = func(result, num);

            return result;
        }
    }
}
