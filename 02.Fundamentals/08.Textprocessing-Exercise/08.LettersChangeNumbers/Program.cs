namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(' ')).ToArray();

            double totalSum = 0;

            foreach (string @string in strings)
            {
                double number = double.Parse(@string.Substring(1, @string.Length - 2));

                if (char.IsUpper(@string[0]))
                {
                    number = number / ((@string[0]) - 64);
                }
                else
                {
                    number = number * ((@string[0]) - 96);
                }

                if (char.IsUpper(@string[@string.Length - 1]))
                {
                    number = number - ((@string[@string.Length - 1]) - 64);
                }
                else
                {
                    number = number + ((@string[@string.Length - 1]) - 96);
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
