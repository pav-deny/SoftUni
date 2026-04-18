using System.Text.RegularExpressions;

namespace RegularFinalExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([/$/%])(?<Tag>[A-Z][a-z]{2,})\1\: (?<Numbers>\[\d+\]\|){3}$";
            string t = "$Request$: [73]|[115]|[105]|";

            Match match = Regex.Match(t, pattern);

            
        }
    }
}
