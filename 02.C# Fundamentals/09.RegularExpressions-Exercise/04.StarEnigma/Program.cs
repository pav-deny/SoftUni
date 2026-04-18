using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Message> messages = new();

            string starPattern = @"[STARstar]";
            int messagesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messagesCount; i++)
            {
                string encryptedMSG = Console.ReadLine();

                int matchesCount = Regex.Matches(encryptedMSG, starPattern).Count;

                StringBuilder decryptedMSG = new();

                foreach (char c in encryptedMSG)
                {
                    char decryptedChar = (char)(c - matchesCount);
                    decryptedMSG.Append(decryptedChar);
                }

                string decryptedMSGString = decryptedMSG.ToString();

                string infoPattern = @"\@(?<Planet>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<Population>[0-9]+)[^\@\-\!\:\>]*\!(?<Type>[AD])\![^\@\-\!\:\>]*\-\>(?<Soldiers>[0-9]+)";

                Match infoMatch = Regex.Match(decryptedMSGString, infoPattern);

                if (infoMatch.Success)
                {
                    string planetName = infoMatch.Groups["Planet"].Value;
                    int population = int.Parse(infoMatch.Groups["Population"].Value);
                    string attackType = infoMatch.Groups["Type"].Value;
                    int soldiersCount = int.Parse(infoMatch.Groups["Soldiers"].Value);

                    Message message = new(planetName, population, attackType, soldiersCount);

                    messages.Add(message);
                }
            }

            List<Message> groupedMessages = messages.Where(m => m.AttackType == "A").OrderBy(m => m.PlanetName).ToList();

            Console.WriteLine($"Attacked planets: {groupedMessages.Count}");
            groupedMessages.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));

            groupedMessages = messages.Where(m => m.AttackType == "D").OrderBy(m => m.PlanetName).ToList();

            Console.WriteLine($"Destroyed planets: {groupedMessages.Count}");
            groupedMessages.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));
        }
    }

    public class Message
    {
        public string PlanetName { get; set; }
        public int Population { get; set; }
        public string AttackType { get; set; }
        public int SoldierCount { get; set; }

        public Message(string planetName, int population, string attackType, int soldierCount)
        {
            PlanetName = planetName;
            Population = population;
            AttackType = attackType;
            SoldierCount = soldierCount;
        }
    }
}
