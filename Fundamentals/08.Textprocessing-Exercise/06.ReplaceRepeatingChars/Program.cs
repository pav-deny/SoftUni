namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            string noRepeatingCharsStr = string.Empty;
            char previousChar = default;

            foreach (char c in str)
            {
                if (c != previousChar)
                {
                    previousChar = c;
                    noRepeatingCharsStr += c;
                }
            }

            Console.WriteLine(noRepeatingCharsStr);
        }
    }
}
