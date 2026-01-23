namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Spellblade : Hero
    {
        private const int StartingPower = 50;
        private const int StartingMana = 60;
        private const int StartingStamina = 60;

        public Spellblade(string name, string runeMark)
            : base(name, runeMark, StartingPower, StartingMana, StartingStamina) { }

        public override void Train()
        {
            Power += 15;
            Mana += 10;
            Stamina += 10;
        }
    }
}
