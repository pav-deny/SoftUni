using System;
using System.Collections.Generic;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> productsMap = new(); //Creates the dictionary


            string input = string.Empty;
            while ((input = Console.ReadLine()) != "buy") //Until the input = "buy"
            {
                string[] productInfo = input.Split(); //Gets the data from the input

                //Variables needed for a Product
                string name = productInfo[0];
                decimal price = decimal.Parse(productInfo[1]);
                int quantity = int.Parse(productInfo[2]);

                Product product = new(name, price, quantity);//Creates a new Product

                if (!productsMap.ContainsKey(name)) //If the dictionary doesn't contain this key
                {

                    productsMap.Add(name, product); //Create it
                }
                else
                {
                    productsMap[name].Update(price, quantity); //Update if it exists
                }
            }

            foreach ((string name, Product product) in productsMap)
            {
                decimal totalPrice = product.Price * product.Quantity; //Gets the total price

                Console.WriteLine($"{name} -> {totalPrice:f2}"); //Prints it
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product(string name, decimal price, int quantity) //Constructor for Product
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Update(decimal price, int quantity)//Updates the Product
        {
            Price = price;
            Quantity += quantity;
        }
    }
}