using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<Day>[0-9]{2})([./-])(?<Month>[A-Z][a-z]{2})\1(?<Year>[0-9]{4})\b";

            string dates = Console.ReadLine();

            MatchCollection matches = Regex.Matches(dates, pattern);

            foreach (Match match in matches)
            {
                string date = match.Groups["Day"].Value;
                string month = match.Groups["Month"].Value;
                string year = match.Groups["Year"].Value;

                Console.WriteLine($"Day: {date}, Month: {month}, Year: {year}");
            }
        }
    }
}
