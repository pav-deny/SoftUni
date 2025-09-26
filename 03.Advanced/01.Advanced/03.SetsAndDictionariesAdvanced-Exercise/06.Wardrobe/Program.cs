namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobeMap = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = input[0];
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobeMap.ContainsKey(colour))
                    wardrobeMap[colour] = new Dictionary<string, int>();

                Dictionary<string, int> countByItem = wardrobeMap[colour];

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!countByItem.ContainsKey(clothes[j]))
                        countByItem[clothes[j]] = 0;

                    countByItem[clothes[j]]++;
                }
            }

            string[] searchQuery = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);  
            
            foreach ((string colour, Dictionary<string, int> itemsMap) in wardrobeMap)
            {
                Console.WriteLine($"{colour} clothes:");

                foreach ((string item, int count) in itemsMap)
                {
                    Console.Write($"* {item} - {count}");

                    if (colour == searchQuery[0] && item == searchQuery[1])
                        Console.Write(" (found!)");

                    Console.WriteLine();
                }
            }
        }
    }
}

