namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private const string NameErrorMessage = "A name should not be empty.";

        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(NameErrorMessage);

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (!players.Any())
                    return 0;

                return (int)Math.Round(players.Average(p => p.OverallSkill));
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");

            this.players.Remove(player);
        }

        public override string ToString() => $"{this.Name} - {this.Rating}";
    }
}
