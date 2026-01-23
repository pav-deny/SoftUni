using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.AnimalModels;
using WildFarm.Models.AnimalModels.AbstractClasses;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {

        public Animal CreateAnimal(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = parts[0];
            string name = parts[1];
            double weight = double.Parse(parts[2]);

            Animal animal;

            switch (type)
            {
                case "Owl":
                    double wingSizeOwl = double.Parse(parts[3]);
                    animal = new Owl(name, weight, wingSizeOwl);
                    break;

                case "Hen":
                    double wingSizeHen = double.Parse(parts[3]);
                    animal = new Hen(name, weight, wingSizeHen);
                    break;

                case "Mouse":
                    string livingRegionMouse = parts[3];
                    animal = new Mouse(name, weight, livingRegionMouse);
                    break;

                case "Dog":
                    string livingRegionDog = parts[3];
                    animal = new Dog(name, weight, livingRegionDog);
                    break;

                case "Cat":
                    string livingRegionCat = parts[3];
                    string breedCat = parts[4];
                    animal = new Cat(name, weight, livingRegionCat, breedCat);
                    break;

                case "Tiger":
                    string livingRegionTiger = parts[3];
                    string breedTiger = parts[4];
                    animal = new Tiger(name, weight, livingRegionTiger, breedTiger);
                    break;

                default:
                    throw new InvalidOperationException("Invalid animal type");
            }

            return animal;
        }
    }
}
