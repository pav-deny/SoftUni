namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> nums = new Queue<int>(numsArr);
            List<int> evenNums = new();

            while (nums.Count > 0)
            {
                int num = nums.Dequeue();

                if (num % 2 == 0)
                {
                    evenNums.Add(num);
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
