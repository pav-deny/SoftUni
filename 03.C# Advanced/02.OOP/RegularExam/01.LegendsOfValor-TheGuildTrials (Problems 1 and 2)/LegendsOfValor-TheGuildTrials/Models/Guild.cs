using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Guild : IGuild
    {
        private string _name;
        private List<string> _legion;

        public Guild(string name)
        {
            Name = name;
            Wealth = 5000;
            _legion = new List<string>();
            IsFallen = false;
        }


        public string Name
        {
            get => _name;
            private set
            {
                if (value != "WarriorGuild" && value != "SorcererGuild" && value != "ShadowGuild")
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);

                _name = value;
            }
        }
        public int Wealth { get; private set; }
        public IReadOnlyCollection<string> Legion => _legion.AsReadOnly();
        public bool IsFallen { get; private set; }


        public void RecruitHero(IHero hero)
        {
            _legion.Add(hero.RuneMark);
            Wealth -= 500;
        }

        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            foreach (IHero hero in heroesToTrain)
            {
                Wealth -= 200;
                hero.Train();
            }
        }

        public void WinWar(int goldAmount)
        {
            Wealth += goldAmount;
        }

        public void LoseWar()
        {
            Wealth = 0;
            IsFallen = true;
        }
    }
}
