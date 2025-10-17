using System.Collections.Concurrent;
using System.Runtime.Intrinsics.X86;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                ProcessCommand(command, stack);
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (int element in stack)
                    Console.WriteLine(element);
            }
        }

        static void ProcessCommand(string command, Stack<int> stack)
        {
            if (command == "Pop")
            {
                try
                {
                    stack.Pop();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (command.StartsWith("Push "))
            {
                int[] nums = command.Substring(5).Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();       
                foreach (int num in nums) 
                    stack.Push(num);
            }
        }
    }
}
