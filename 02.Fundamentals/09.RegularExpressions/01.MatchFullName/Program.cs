using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b";

            string names = Console.ReadLine();

            MatchCollection validNames = Regex.Matches(names, pattern);

            foreach (Match match in validNames)
            {
                Console.Write(match.ToString() + " ");
            }

            Console.WriteLine();
        }
    }
}
