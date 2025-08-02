namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            PrintCharsInBetween(char1, char2);
        }

        static void PrintCharsInBetween(char char1, char char2)
        {
            if (char1 > char2)
            {
                char temp = char1;
                char1 = char2;
                char2 = temp;
            }

            for (int i = char1 + 1; i < char2; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
