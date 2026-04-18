namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int numsCount = parameters[0], popCount = parameters[1], x = parameters[2];

            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new();

            for (int i = 0; i < numsCount; i++)
            {
                stack.Push(nums[i]);
            }
            
            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            bool isFound = false;
            int min = int.MaxValue;

            foreach (int num in stack)
            {
                if (num == x)
                {
                    isFound = true;
                    break;
                }

                else if (num < min)
                {
                    min = num;
                }
            }

            if (isFound)
            {
                Console.WriteLine("true");
            }

            else if (min == int.MaxValue)
            {
                Console.WriteLine(0);
            }

            else
            {
                Console.WriteLine(min);
            }
        }
    }
}
