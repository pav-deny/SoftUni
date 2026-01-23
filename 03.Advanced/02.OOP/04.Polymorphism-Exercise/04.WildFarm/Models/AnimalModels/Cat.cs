using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.AnimalModels.AbstractClasses;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(Food food)
        {
            if (food is Meat || food is Vegetable)
            {
                FoodEaten += food.Quantity;
                Weight += 0.30 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
