namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentsMap = new();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0], country = input[1], city = input[2];

                if (!continentsMap.ContainsKey(continent))
                {
                    continentsMap[continent] = new Dictionary<string, List<string>>();
                }

                Dictionary<string, List<string>> countriesMap = continentsMap[continent];

                if (!countriesMap.ContainsKey(country))
                {
                    countriesMap[country] = new List<string>();
                }

                countriesMap[country].Add(city);
            }

            foreach ((string continent, Dictionary<string, List<string>> countriesMap) in continentsMap)
            {
                Console.WriteLine($"{continent}:");

                foreach ((string country, List<string> cities) in countriesMap)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
