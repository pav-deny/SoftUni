namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Warrior : Hero
    {
        private const int StartingPower = 60;
        private const int StartingMana = 0;
        private const int StartingStamina = 100;

        public Warrior(string name, string runeMark)
            :base (name, runeMark, StartingPower, StartingMana, StartingStamina) { }

        public override void Train()
        {
            Power += 30;
            Stamina += 10;
        }
    }
}
