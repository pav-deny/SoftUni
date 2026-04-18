namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<char> stack = new();
            Dictionary<char, char> map = new() { { '(', ')' }, { '[', ']' }, { '{', '}' } };

            foreach (char c in text)
            {
                if (map.ContainsKey(c))
                {
                    stack.Push(map[c]);
                }
                else
                {
                    if (stack.Any() && stack.Peek() == c)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
