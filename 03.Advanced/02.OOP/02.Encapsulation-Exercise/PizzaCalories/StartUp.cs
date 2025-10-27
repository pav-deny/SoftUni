using PizzaCalories.Models;

namespace PizzaCalories
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split();
                string pizzaName = pizzaTokens[1];

                string[] doughTokens = Console.ReadLine().Split();
                string flourType = doughTokens[1], bakingTechnique = doughTokens[2];
                double doughWeight = double.Parse(doughTokens[3]);

                Dough dough = new(flourType, bakingTechnique, doughWeight);
                Pizza pizza = new(pizzaName, dough);

                string toppingInput = string.Empty;
                while((toppingInput = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = toppingInput.Split();
                    string toppingType = toppingTokens[1];
                    double toppingWeight = double.Parse(toppingTokens[2]);

                    Topping topping = new(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException e)
            { 
                Console.WriteLine(e.Message); 
            }
            }
    }
}
