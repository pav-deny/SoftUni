namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private string type;
        private double weight;

        private Dictionary<string, double> typesCalories;

        public Topping(string type, double weight)
        {
            typesCalories = new Dictionary<string, double>()
            {
                { "meat", 1.2 },
                { "veggies", 0.8},
                { "cheese", 1.1 },
                { "sauce", 0.9 }
            };

            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!typesCalories.ContainsKey(value.ToLower()))
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{this.Type} should be in range [1..50].");

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double typeModifier = this.typesCalories[this.Type.ToLower()];

                return BaseCaloriesPerGram * this.Weight * typeModifier;
            }
        }
    }
}
