using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Fish fish = new("Salmon", 2.40m);
            Soup soup = new("Shkembe", 3.30m, 2.40);
            Cake cake = new("Lindor");

            Coffee coffee = new("Esspresso", 2.3);
            Tea tea = new("Laika", 6.6m, 3.4);

            List<Food> foods = new() { fish, soup, cake };
            List<Beverage> beverages = new() { coffee, tea };

            foreach (Food food in foods)
            {
                Console.WriteLine($"{food.Name}, ${food.Price:f2}, {food.Grams}g");
            }

            foreach (Beverage bevarage in beverages)
            {
                Console.WriteLine($"{bevarage.Name}, ${bevarage.Price:f2}, {bevarage.Milliliters}mL");
            }

            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine();

            //ChatGPT StartUp.cs \/ \/ \/

            Coffee espresso = new Coffee("Espresso", 80);
            Tea greenTea = new Tea("Green Tea", 2.50m, 200);

            Fish salmon = new Fish("Salmon", 12.50m);
            Soup tomatoSoup = new Soup("Tomato Soup", 5.00m, 150);
            Cake chocolateCake = new Cake("Chocolate Cake");

            Console.WriteLine($"Beverages:");
            Console.WriteLine($"{espresso.Name} - {espresso.Price} - {espresso.Milliliters}ml - {espresso.Caffeine}mg caffeine");
            Console.WriteLine($"{greenTea.Name} - {greenTea.Price} - {greenTea.Milliliters}ml");

            Console.WriteLine($"\nFoods:");
            Console.WriteLine($"{salmon.Name} - {salmon.Price} - {salmon.Grams}g");
            Console.WriteLine($"{tomatoSoup.Name} - {tomatoSoup.Price} - {tomatoSoup.Grams}g");
            Console.WriteLine($"{chocolateCake.Name} - {chocolateCake.Price} - {chocolateCake.Grams}g - {chocolateCake.Calories} cal");
        }
    }
}

//Solved with ChatGPT
//Part of the "Solve with AI" problems