using CustomStack;
using CustomLinkedStack;

namespace Project
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            MyLinkedStack stack = new();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        int num = Random.Shared.Next(0, 100);
                        stack.Push(num);
                        Console.WriteLine($"Added {num}");
                        PrintStack(stack);
                    }

                    for (int k = 0; k < 3; k++)
                    {
                        int removed = stack.Pop();
                        Console.WriteLine($"Removed {removed}");
                        PrintStack(stack);
                    }
                }

                while (stack.Count > 0)
                {
                    int removed = stack.Pop();
                    Console.WriteLine($"Removed {removed}");
                    PrintStack(stack);
                }
            }
        }

        static void PrintStack(MyLinkedStack stack)
        {
            if (stack.Count <= 0)
            {
                Console.WriteLine("Count: 0 | The stack is empty");
                return;
            }
            int[] arr = stack.ToArray();

            Console.WriteLine($"Count: {stack.Count} | Stack: {string.Join(", ", arr)} | Top: {stack.Peek()}");
        }
    }
}
