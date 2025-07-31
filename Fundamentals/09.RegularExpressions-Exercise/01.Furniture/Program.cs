using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Furniture> furnitures = new();
            string pattern = @"\>\>([A-Za-z]+)\<\<(\d+|\d+.\d+)\!(\d+)";


            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                foreach(Match match in Regex.Matches(input, pattern))
                {
                    Furniture furniture = new()
                    { 
                        Name = match.Groups[1].Value,
                        Price = decimal.Parse(match.Groups[2].Value),
                        Quantity = int.Parse(match.Groups[3].Value)
                    };

                    furnitures.Add(furniture);
                }
            }

            Console.WriteLine($"Bought furniture:");

            decimal total = 0;

            foreach (Furniture furniture in furnitures)
            {
                Console.WriteLine(furniture.Name);
                total += furniture.GetTotal();
            }

            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }

    public class Furniture
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal GetTotal()
        {
            return Price * Quantity;
        }
    }
}
