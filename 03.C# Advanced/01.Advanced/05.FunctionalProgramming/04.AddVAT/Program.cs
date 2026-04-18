namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<decimal> prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToList();
            Func<decimal, decimal> addVat = d => d += d * 0.2m;
            
            for (int i = 0; i < prices.Count; i++)
            {
                prices[i] = addVat(prices[i]);
            }

            prices.ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
