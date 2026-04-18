using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.FoodModels;

namespace WildFarm.Core
{
    public class FoodFactory
    {
        public Food CreateFood(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = parts[0];
            int quantity = int.Parse(parts[1]);

            Food food;

            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "Fruit":
                    food = new Fruit(quantity);
                    break;

                case "Meat":
                    food = new Meat(quantity);
                    break;

                case "Seeds":
                    food = new Seeds(quantity);
                    break;

                default:
                    throw new InvalidOperationException("Invalid food type");
            }

            return food;
        }
    }
}
