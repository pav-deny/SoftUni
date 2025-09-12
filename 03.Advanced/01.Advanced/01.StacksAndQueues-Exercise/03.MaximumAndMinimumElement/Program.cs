namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new();

            for (int i = 0; i < n; i++)
            {
                int[] queryArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int query = queryArr[0];

                switch (query)
                {
                    case 1:
                        int num = queryArr[1];
                        stack.Push(num);
                        break;

                    case 2:
                        if (stack.Any())
                            stack.Pop();

                        break;

                    case 3:
                        if (stack.Any())
                          PrintMax(stack);

                        break;

                    case 4:
                        if (stack.Any())
                            PrintMin(stack);

                        break;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }

        private static void PrintMax(Stack<int> stack)
        {
            int max = int.MinValue;

            foreach(int num in stack)
            {
                max = Math.Max(max, num);
            }

            Console.WriteLine(max);
        }

        private static void PrintMin(Stack<int> stack)
        {
            int min = int.MaxValue;

            foreach (int num in stack)
            {
                min = Math.Min(min, num);
            }

            Console.WriteLine(min);
        }
    }
}
