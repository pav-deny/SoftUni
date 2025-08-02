namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal total = 0;
            decimal taxes = 0;

            decimal taxRate = 0.20m;
            decimal specialDiscount = 0.10m;


            string input = string.Empty;
            while ((input = Console.ReadLine()) != "special" && input  != "regular" )
            {
                decimal price = decimal.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                total += price;
                taxes += price * taxRate;
            }

            if (total <= 0)
            {
                Console.WriteLine($"Invalid order!");
                return;
            }

            decimal totalWithTaxes = total + taxes;

            if (input == "special")
            {
                totalWithTaxes -= totalWithTaxes * specialDiscount;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {total:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalWithTaxes:f2}$");
        }
    }
}
