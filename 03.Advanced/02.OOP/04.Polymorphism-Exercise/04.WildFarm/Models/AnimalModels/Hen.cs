using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.AnimalModels.AbstractClasses;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += 0.35 * food.Quantity;
        }
    }
}
