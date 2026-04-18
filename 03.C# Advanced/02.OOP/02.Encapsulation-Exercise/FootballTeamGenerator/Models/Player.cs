namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const string StatErrorMessage = "{0} should be between 0 and 100.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }


        public double OverallSkill => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A name should not be empty.");
                this.name = value;
            }
        }

        private int Endurance
        {
            get => this.endurance; 
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(string.Format(StatErrorMessage, nameof(Endurance)));
                this.endurance = value;
            }
        }

        private int Sprint
        {
            get => this.sprint; 
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(string.Format(StatErrorMessage, nameof(Sprint)));
                this.sprint = value;
            }
        }

        private int Dribble
        {
            get => this.dribble; 
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(string.Format(StatErrorMessage, nameof(Dribble)));
                this.dribble = value;
            }
        }

        private int Passing
        {
            get => this.passing;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(string.Format(StatErrorMessage, nameof(Passing)));
                this.passing = value;
            }
        }

        private int Shooting
        {
            get => this.shooting;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException(string.Format(StatErrorMessage, nameof(Shooting)));
                this.shooting = value;
            }
        }
    }
}
