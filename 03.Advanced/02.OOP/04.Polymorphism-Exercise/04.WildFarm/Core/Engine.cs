using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.IO.Interfaces;
using WildFarm.Models.AnimalModels.AbstractClasses;
using WildFarm.Models.FoodModels;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;
        private readonly List<Animal> animals;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                string animalInput = reader.ReadLine();
                if (animalInput == "End") break;

                string foodInput = reader.ReadLine();

                Animal animal = animalFactory.CreateAnimal(animalInput);
                Food food = foodFactory.CreateFood(foodInput);

                animal.MakeSound();
                animal.Eat(food);

                animals.Add(animal);
            }

            foreach (var a in animals)
            {
                writer.WriteLine(a.ToString());
            }
        }
    }
}
