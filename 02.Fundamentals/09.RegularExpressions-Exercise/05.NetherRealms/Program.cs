using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);


            List<Demon> demonsList = new();

            foreach (string demon in demons)
            {
                string lettersPattern = @"[^\+\-\*\/\.0-9+]";
                MatchCollection letterMatches = Regex.Matches(demon,lettersPattern);

                int health = 0;
                foreach (Match match in letterMatches)
                {
                    health += char.Parse(match.Value);
                }

                double damage = 0;

                string numbersPattern = @"([+-]?[0-9]+(?:\.[0-9]+)?)";
                MatchCollection numberMatches = Regex.Matches(demon, numbersPattern);

                foreach (Match match in numberMatches)
                {
                    damage += double.Parse(match.Value);
                }

                string actionPattern = @"(\*)|(\/)";
                MatchCollection actionMatches = Regex.Matches(demon, actionPattern);

                foreach (Match match in actionMatches)
                {
                    if (match.Value == "*")
                    {
                        damage *= 2;
                    }
                    else if (match.Value == "/")
                    {
                        damage /= 2;
                    }
                }

                Demon demonInfo = new() { Name = demon, Health = health, Damage = damage };
                demonsList.Add(demonInfo);
            }

            demonsList = demonsList.OrderBy(d => d.Name).ToList();

            demonsList.ForEach(d => Console.WriteLine($"{d.Name} - {d.Health} health, {d.Damage:f2} damage"));
        }
    }

    public class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}
