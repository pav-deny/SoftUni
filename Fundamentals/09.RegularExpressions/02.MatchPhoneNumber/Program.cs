using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=^|\s)(?:[+][3][5][9])([ -])[2]\1[0-9]{3}\1[0-9]{4}\b";
            string numbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(numbers, pattern);

            string[] matchesArr = matches.Cast<Match>().Select(m => m.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", matchesArr));
        }
    }
}
