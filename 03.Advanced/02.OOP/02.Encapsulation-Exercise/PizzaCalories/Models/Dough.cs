namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        private Dictionary<string, double> flourTypesCalories;
        private Dictionary<string, double> bakingTechniquesCalories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypesCalories = new Dictionary<string, double>() 
            { 
                { "white", 1.5 }, 
                { "wholegrain", 1.0} 
            };

            bakingTechniquesCalories = new Dictionary<string, double>() 
            { 
                { "crispy", 0.9 }, 
                { "chewy", 1.1 }, 
                { "homemade", 1.0 }
            };

            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!flourTypesCalories.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough");

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (!bakingTechniquesCalories.ContainsKey(value.ToLower()))
                    throw new ArgumentException("Invalid type of dough");

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");

                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double flourTypeModifier = this.flourTypesCalories[this.FlourType.ToLower()];
                double bakingTechniqueModifier = this.bakingTechniquesCalories[this.BakingTechnique.ToLower()];

                return BaseCaloriesPerGram * this.Weight * flourTypeModifier * bakingTechniqueModifier;
            }
        }
    }
}
