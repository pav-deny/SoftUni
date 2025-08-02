using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Racer> racers = new();

            string[] racersNames = Console.ReadLine().Split(", ");

            foreach (string racerName in racersNames)
            {
                Racer racer = new(racerName);
                racers.Add(racerName, racer);
            }

            string patternNums = @"\d";
            string patternLetters = @"[A-Za-z]";

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder name = new();

                foreach (Match match in Regex.Matches(input, patternLetters))
                {
                    name.Append(match.Value);
                }

                int distance = 0;

                foreach (Match match in Regex.Matches(input, patternNums))
                {
                    distance += int.Parse(match.Value);
                }

                if (racers.ContainsKey(name.ToString()))
                {
                    racers[name.ToString()].Distance += distance;
                }
            }

            List<KeyValuePair<string, Racer>> orderedRacers = racers.OrderByDescending(p => p.Value.Distance).Take(3).ToList();

            Console.WriteLine("1st place: " + orderedRacers[0].Value.Name);
            Console.WriteLine("2nd place: " + orderedRacers[1].Value.Name);
            Console.WriteLine("3rd place: " + orderedRacers[2].Value.Name);
        }
    }

    public class Racer
    {
        public string Name { get; set; }

        public int Distance { get; set; }

        public Racer(string name)
        {
            Name = name;
            Distance = 0;
        }
    }
}
