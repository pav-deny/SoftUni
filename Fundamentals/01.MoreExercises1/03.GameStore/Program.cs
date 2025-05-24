using System.Reflection;

namespace _03.GameStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OutFall 4   $39.99
            //CS: OG  $15.99
            //Zplinter Zell	$19.99
            //Honored 2   $59.99
            //RoverWatch  $29.99
            //RoverWatch Origins Edition  $39.99

            decimal startingBalance = decimal.Parse(Console.ReadLine());
            string input = default;
            decimal price = 0.00m, currentBalance = startingBalance;
            bool tooExpensive = false, outOfMoney = false, notFound = false;

            while ((input = Console.ReadLine()) != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99m;
                        break;
                    case "CS: OG":
                        price = 15.99m;
                        break;
                    case "Zplinter Zell":
                        price = 19.99m;
                        break;
                    case "Honored 2":
                        price = 59.99m;
                        break;
                    case "RoverWatch":
                        price = 29.99m;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99m;
                        break;
                    default:
                        notFound = true;
                        break;
                }

                if ((currentBalance - price) < 0)
                {
                    Console.WriteLine("Too Expensive");
                }
                else if (notFound)
                {
                    Console.WriteLine("Not Found");
                    notFound = false;
                    continue;
                }
                else
                {
                    currentBalance -= price;
                    Console.WriteLine($"Bought {input}");
                }

                if (currentBalance <= 0)
                {
                    outOfMoney = true;
                    break;
                }
            }

            if (outOfMoney)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                decimal spent = startingBalance - currentBalance;
                Console.WriteLine($"Total spent: ${spent:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
