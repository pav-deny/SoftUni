namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> symbolsMap = new();

            foreach (char symbol in text)
            {
                if (!symbolsMap.ContainsKey(symbol))
                    symbolsMap[symbol] = 0;

                symbolsMap[symbol]++;
            }

            foreach ((char symbol, int count) in symbolsMap.OrderBy(x => x.Key))
                Console.WriteLine($"{symbol}: {count} time/s");
        }
    }
}
