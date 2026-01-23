namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Sorcerer : Hero
    {
        private const int StartingPower = 40;
        private const int StartingMana = 120;
        private const int StartingStamina = 0;

        public Sorcerer(string name, string runeMark)
            : base(name, runeMark, StartingPower, StartingMana, StartingStamina) { }

        public override void Train()
        {
            Power += 20;
            Mana += 25;
        }
    }
}
