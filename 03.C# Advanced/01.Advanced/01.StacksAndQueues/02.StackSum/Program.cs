namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> nums = new Stack<int>(numsArr);


            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "add":
                        int num1 = int.Parse(commandArgs[1]);
                        int num2 = int.Parse(commandArgs[2]);

                        nums.Push(num1);
                        nums.Push(num2);
                        break;

                    case "remove":
                        int count = int.Parse(commandArgs[1]);

                        if (count < nums.Count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                nums.Pop();
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}
