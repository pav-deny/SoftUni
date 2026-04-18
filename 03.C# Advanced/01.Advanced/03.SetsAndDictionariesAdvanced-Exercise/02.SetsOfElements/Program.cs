namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            HashSet<int> firstSet = ReadSet(lengths[0]);

            HashSet<int> secondSet = ReadSet(lengths[1]);

            List<int> sharedNums = new();

            foreach (int num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    sharedNums.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", sharedNums));
        }

        static HashSet<int> ReadSet(int setLength)
        {
            HashSet<int> set = new();

            for (int i = 0; i < setLength; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }

            return set;
        }
    }
}
