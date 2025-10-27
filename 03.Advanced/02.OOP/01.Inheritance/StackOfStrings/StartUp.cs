namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings sStack = new();

            sStack.Push("Ivan");
            sStack.Push("Peter");
            sStack.Push("Meeee");

            Console.WriteLine(sStack.IsEmpty());
            Console.WriteLine(sStack.Count);

            Stack<string> stack = new();
            stack.Push("Arson");
            stack.Push("yoooo");
            stack.Push("WOOO");

            sStack.AddRange(stack);
            Console.WriteLine(sStack.Count);

            for (int i = 0; i < sStack.Count; i++) 
                sStack.Pop();

            Console.WriteLine(sStack.IsEmpty());
        }
    }
}
