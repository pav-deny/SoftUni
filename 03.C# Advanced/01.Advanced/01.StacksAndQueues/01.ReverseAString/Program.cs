namespace _01.ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string @string = Console.ReadLine();

            Stack<char> letters = new();

            foreach(char c in @string)
            {
                letters.Push(c);
            }

            Console.WriteLine(string.Join("", letters));
        }
    }
}
