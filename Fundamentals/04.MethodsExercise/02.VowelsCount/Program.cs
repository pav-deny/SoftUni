namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string input = Console.ReadLine();
            PrintVowelsCount(input);
        }

        static void PrintVowelsCount(string input)
        {
            int vowelCount = 0;
            foreach (char c in input)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
                    || c == 'A' || c == 'E' || c == 'I' || c == 'o' || c == 'U')
                {
                    vowelCount++;
                }
            }

            Console.WriteLine(vowelCount);
        }
    }
}
