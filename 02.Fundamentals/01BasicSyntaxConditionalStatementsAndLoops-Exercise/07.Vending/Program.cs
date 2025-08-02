using System.Collections.Concurrent;

namespace _07.Vending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Coin collector
            //Valid coins 0.1, 0.2, 0.5, 1, 2

            string input = string.Empty;
            double totalCoins = 0;

            while ((input = Console.ReadLine()) != "Start")
            {
                double coins = double.Parse(input);

                switch (coins)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1:
                    case 2:
                        totalCoins += coins;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coins}");
                        break;
                }
            }
            //The buying process

            string product = string.Empty;


            while ((product = Console.ReadLine()) != "End")
            {
                switch (product)
                {
                    case "Nuts"://2
                        if (totalCoins - 2.0 < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            totalCoins -= 2.0;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                            break;
                    case "Water"://0.7
                        if (totalCoins - 0.7 < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            totalCoins -= 0.7;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    case "Crisps"://1.5
                        if (totalCoins - 1.5 < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            totalCoins -= 1.5;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    case "Soda"://0.8
                        if (totalCoins - 0.8 < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            totalCoins -= 0.8;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    case "Coke"://1
                        if (totalCoins - 1.0 < 0)
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        else
                        {
                            totalCoins -= 1.0;
                            Console.WriteLine($"Purchased {product.ToLower()}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        break;
                }
            }

            Console.WriteLine($"Change: {totalCoins:f2}");

        }
    }
}
