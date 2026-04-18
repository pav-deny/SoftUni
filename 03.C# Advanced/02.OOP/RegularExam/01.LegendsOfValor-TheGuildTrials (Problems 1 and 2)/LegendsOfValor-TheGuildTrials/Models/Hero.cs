using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public abstract class Hero : IHero
    {
        private string _name;
        private string _runeMark;

        protected Hero(string name, string runeMark, int power, int mana, int stamina)
        {
            Name = name;
            RuneMark = runeMark;
            Power = power;
            Mana = mana;
            Stamina = stamina;
        }


        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ErrorMessages.InvalidHeroName);

                _name = value;
            }
        }
        public string RuneMark
        {
            get => _runeMark;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ErrorMessages.InvalidHeroRuneMark);

                _runeMark = value;
            }
        }
        public string GuildName { get; private set;  }
        public int Power { get; protected set; } //NOTE: protected set; could cause issues
        public int Mana { get; protected set; }
        public int Stamina { get; protected set; }


        public string Essence()
        {
            return $"Essence Revealed - Power [{Power}] Mana [{Mana}] Stamina [{Stamina}]";
        }

        public void JoinGuild(IGuild guild)
        {
            GuildName = guild.Name;
        }

        public abstract void Train();

        public override string ToString() => $"Hero: [{Name}] of the Guild '{GuildName}' - RuneMark: {RuneMark}";
    }
}
