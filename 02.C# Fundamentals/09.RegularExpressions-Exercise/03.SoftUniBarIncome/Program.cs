using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%([A-Z][a-z]+)\%[^|$%.]*\<(\w+)\>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+(?:\.\d+)?)\$";
            List<Order> orders = new();

            decimal totalIncome = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string customer = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    decimal price = decimal.Parse(match.Groups[4].Value);

                    Order order = new(customer, product, quantity, price);
                    orders.Add(order);

                    totalIncome += order.TotalPrice;
                    Console.WriteLine($"{order.Customer}: {order.Product} - {order.TotalPrice:f2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }

    public class Order
    {
        public string Customer {  get; set; }
        public string Product { get; set; }
        public decimal TotalPrice { get; set; }

        public Order(string customer, string product, int quantity, decimal price)
        {
            Customer = customer;
            Product = product;
            TotalPrice = price * quantity;
        }
    }
}
