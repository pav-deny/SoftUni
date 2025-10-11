namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int start = range[0], end = range[1];

            string type = Console.ReadLine();

            List<int> result = new();

            if (type == "even")
                result = FindAllType(start, end, x => x % 2 == 0);

            else
                result = FindAllType(start, end, x => x % 2 != 0);

            Console.WriteLine(string.Join(" ", result));
        }

        static List<int> FindAllType (int start, int end, Predicate<int> predicate)
        {
            List<int> result = new();

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                    result.Add(i);
            }

            return result;
        }
            
    }
}
