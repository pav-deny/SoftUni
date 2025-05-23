using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            decimal total = 0;

            for (int i = 0;  i < orders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                decimal price = ((days * capsulesCount) * pricePerCapsule);
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                total += price;
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
