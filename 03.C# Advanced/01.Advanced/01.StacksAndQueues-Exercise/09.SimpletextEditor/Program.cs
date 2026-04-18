using System.Buffers;
using System.Text;

namespace _09.SimpletextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new();

            Stack<string> stack = new();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int query = int.Parse(command[0]);

                switch (query)
                {
                    case 1:
                        stack.Push(sb.ToString());
                        string str = command[1];
                        sb.Append(str);
                        break;

                    case 2:
                        stack.Push(sb.ToString());

                        int count = int.Parse(command[1]);

                        sb = sb.Remove(sb.Length - count, count);
                        break;

                    case 3:
                        int index = int.Parse(command[1]);

                        Console.WriteLine(sb[index - 1]);
                        break;

                    case 4:
                        sb = new(stack.Pop());
                        break;
                }
            }
        }
    }
}
