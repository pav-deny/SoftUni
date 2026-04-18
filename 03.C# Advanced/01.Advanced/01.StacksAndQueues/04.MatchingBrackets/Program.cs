namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string equation = Console.ReadLine();

            Stack<int> bracketsPos = new();

            for (int i = 0; i < equation.Length; i++)
            {
               if (equation[i] == '(')
               {
                    bracketsPos.Push(i);
               }
               else if (equation[i] == ')')
                {
                    int startPos = bracketsPos.Pop();

                    Console.WriteLine(equation.Substring(startPos, (i - startPos) + 1));
                }
           }
        }
    }
}
