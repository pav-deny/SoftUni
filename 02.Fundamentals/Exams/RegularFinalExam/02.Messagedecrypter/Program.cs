using System.Text;
using System.Text.RegularExpressions;

namespace _02.Messagedecrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([\$\%])(?<Tag>[A-Z][a-z]{2,})\1\: (?<Numbers>(?:\[\d+\]\|){3})$";
            string numPattern = @"(?<Numbers>\[\d+\]\|){3}$";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string message = Console.ReadLine();

                Match match = Regex.Match(message, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }


                string tag = match.Groups["Tag"].Value;

                StringBuilder decryptedSb = new();
                string encryptedMSG = match.Groups["Numbers"].Value;

                string[] nums = encryptedMSG.Split("|", StringSplitOptions.RemoveEmptyEntries);

                foreach (string numStr in nums)
                {
                    string numsPattern = @"\d+";
                    Match numMatch = Regex.Match(numStr, numsPattern);
                    int num = int.Parse(numMatch.Value);

                    char letter = (char)num;
                    decryptedSb.Append(letter);
                }

                string decryptedMSG = decryptedSb.ToString();
                Console.WriteLine($"{tag}: {decryptedMSG}");
            }
        }
    }
}
