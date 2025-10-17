namespace SumOfCoins
{
    using System.Collections.Generic;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).OrderByDescending(c => c).ToList();

            int targetSum = int.Parse(Console.ReadLine());

            Dictionary<int, int> result = ChooseCoins(coins, targetSum);
            int totalCoins = result.Sum(x => x.Value);

            if (result.Count > 0)
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");

                foreach ((int coin, int count) in result)
                {
                    Console.WriteLine($"{count} coin(s) with value {coin}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> coinsCount = new();

            foreach (int coin in coins)
            {
                if (targetSum == 0)
                    break;

                int count = targetSum / coin;
                targetSum -= coin * count;

                if (count > 0)
                    coinsCount.Add(coin, count);
            }

            return coinsCount;
        }
    }
}
