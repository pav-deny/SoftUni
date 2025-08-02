using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[STARstar]";

            List<string> attackedPlanets = new();
            List<string> destroyedPlanets = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string encryptedMessage = Console.ReadLine();
                
                int matchesCount = Regex.Matches(encryptedMessage, pattern).Count;

                if (matchesCount > 0)
                { 
                    StringBuilder decryptedMessage = new();

                    foreach (char c in encryptedMessage)
                    {
                        char decryptedChar = (char)(c - matchesCount);

                        decryptedMessage.Append(decryptedChar);
                    }

                    string decryptedMessageSTR = decryptedMessage.ToString();

                    string infoPattern = @"\@(?<Planet>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<Population>\d+)[^\@\-\!\:\>]*\!(?<Type>A|D)\![^\@\-\!\:\>]*\-\>[^\@\-\!\:\>]*?(?<Soldiers>\d+)[^\@\-\!\:\>]*";

                    Match match = Regex.Match(decryptedMessageSTR, infoPattern);

                    if (match.Success)
                    {
                        switch (match.Groups["Type"].Value)
                        {
                            case "A":
                                attackedPlanets.Add(match.Groups["Planet"].Value);
                                break;

                            case "D":
                                destroyedPlanets.Add(match.Groups["Planet"].Value);
                                break;
                        }
                    }
                }
            }

            attackedPlanets.Sort();
            destroyedPlanets.Sort();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.ForEach(x => Console.WriteLine($"-> {x}"));

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets.ForEach(x => Console.WriteLine($"-> {x}"));
        }
    }
}
