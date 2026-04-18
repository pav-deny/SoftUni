namespace _09.PokemonDontGo
{
    internal class Program
    {
        public static List<int> DistancesFromPokemons { get; set; }
        static void Main(string[] args)
        {
            DistancesFromPokemons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse).ToList();

            int removedNumsSum = 0;

            while (DistancesFromPokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedNum = 0;

                if (!CheckIfValidIndex(index))
                {
                    int lastIndex = DistancesFromPokemons.Count - 1;

                    if (index < 0)
                    {
                        removedNum = DistancesFromPokemons[0];
                        removedNumsSum += removedNum;

                        DistancesFromPokemons[0] = DistancesFromPokemons[lastIndex];
                        UpdateDistances(removedNum);

                        //Console.WriteLine(string.Join(" ", DistancesFromPokemons)); //Debug line
                    }

                    else
                    {
                        removedNum = DistancesFromPokemons[lastIndex];
                        removedNumsSum += removedNum;

                        DistancesFromPokemons[lastIndex] = DistancesFromPokemons[0];
                        UpdateDistances(removedNum);

                        //Console.WriteLine(string.Join(" ", DistancesFromPokemons)); //Debug line
                    }
                }
                else
                {
                    removedNum = DistancesFromPokemons[index];
                    removedNumsSum += removedNum;

                    DistancesFromPokemons.RemoveAt(index);
                    UpdateDistances(removedNum);

                    //Console.WriteLine(string.Join(" ", DistancesFromPokemons)); //Debug line
                }
            }

            Console.WriteLine(removedNumsSum);
        }

        static void UpdateDistances(int removedNum)
        {
            for (int i = 0; i < DistancesFromPokemons.Count; i++)
            {
                if (DistancesFromPokemons[i] <= removedNum)
                {
                    DistancesFromPokemons[i] += removedNum;
                }

                else if (DistancesFromPokemons[i] > removedNum)
                {
                    DistancesFromPokemons[i] -= removedNum;
                }
            }
        }
        static bool CheckIfValidIndex(int index)
        {
            if (index >= 0 && index < DistancesFromPokemons.Count)
            {
                return true;
            }

            return false;
        }
    }
}
