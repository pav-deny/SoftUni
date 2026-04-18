namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsMap = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = info[0], product = info[1];
                double price = double.Parse(info[2]);

                if (!shopsMap.ContainsKey(shop))
                {
                    shopsMap[shop] = new Dictionary<string, double>();
                }

                shopsMap[shop][product] = price;
            }

            shopsMap = shopsMap.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach ((string shop, Dictionary<string, double> products) in shopsMap)
            {
                Console.WriteLine($"{shop}->");

                foreach ((string product, double price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
