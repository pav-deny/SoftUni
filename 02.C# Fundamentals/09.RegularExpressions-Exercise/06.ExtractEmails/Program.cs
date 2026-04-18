using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emailPattern = @"[^\.\-_]\b(?![\._\-])[A-Za-z0-9]+[\.\-_]*[A-Za-z0-9]+@[^\.\-](?:[A-Za-z\.\-]+\.)+[A-Za-z]+";

            MatchCollection matches = Regex.Matches(text, emailPattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value.Trim(' ', ',', '\n'));
            }
        }
    }
}
