namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> startsWithUpper = s => s[0] == char.ToUpper(s[0]);

            foreach (string word in text)
            {
                if (startsWithUpper(word))
                    Console.WriteLine(word);
            }
        }
    }
}
