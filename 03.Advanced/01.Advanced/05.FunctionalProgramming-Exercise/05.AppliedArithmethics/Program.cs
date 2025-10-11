using System.Net.Http.Headers;

namespace _05.AppliedArithmethics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Action<int[]>> execurters = new()
            {
                ["add"] = arr => Transform(arr, x => x + 1),
                ["multiply"] = arr => Transform(arr, x => x * 2),
                ["subtract"] = arr => Transform(arr, x => x - 1),
                ["print"] = arr => Console.WriteLine(string.Join(" ", arr))
            };

            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (execurters.ContainsKey(command))
                {
                    Action<int[]> action = execurters[command];
                    action(nums);
                }
            }
        }

        static int[] Transform(int[] nums, Func<int, int> action)
        {
            for (int i = 0; i < nums.Length; i++)
                nums[i] = action(nums[i]);

            return nums;
        }
    }
}
