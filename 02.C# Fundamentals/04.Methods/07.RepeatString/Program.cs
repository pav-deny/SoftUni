namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(input, n));
        }

        static string RepeatString(string input, int n)
        {
            string repeatedString = string.Empty;

            for (int i = 0; i < n; i++)
            {
                repeatedString += input;
            }

            return repeatedString;
        }
    }
}
