using System;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new();

            string[] peopleData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleData.Length; i++)
            {
                try
                {
                    string[] personData = peopleData[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = personData[0];
                    decimal money = decimal.Parse(personData[1]);

                    Person person = new(name, money);
                    people.Add(name, person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            Dictionary<string, Product> products = new();
            string[] productsData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsData.Length; i++)
            {
                try
                {
                    string[] productData = productsData[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = productData[0];
                    decimal cost = decimal.Parse(productData[1]);

                    Product product = new(name, cost);
                    products.Add(name, product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = data[0], productName = data[1];

                Person person = people[personName];
                Product product = products[productName];

                Console.WriteLine(person.Buy(product));
            }

            foreach (Person person in people.Values)
                Console.WriteLine(person);
        }
    }
}
