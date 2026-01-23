using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.FoodModels;

namespace WildFarm.Models.AnimalModels.AbstractClasses
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract void MakeSound();
        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {FoodEaten}]";
        }
    }

}
