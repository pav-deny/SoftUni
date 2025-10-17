namespace SetCover
{
    using System.Collections.Generic;
    using System.Timers;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            int totalSets = int.Parse(Console.ReadLine());

            List<int[]> allSets = new();

            for (int i = 0; i < totalSets; i++)
            {
                int[] currentSet = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                allSets.Add(currentSet);
            }

            List<int[]> result = ChooseSets(allSets, universe);

            Console.WriteLine($"Sets to take ({result.Count}):");

            foreach (int[] set in result)
            {
                string setAsText = string.Join(", ", set);

                Console.WriteLine($"{{ {setAsText} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> setsChoosen = new();

            while (true)
            {
                int[] maximumSet = sets.OrderByDescending(i => universe.Count(el => i.Contains(el))).ToList().Take(1).First();

                setsChoosen.Add(maximumSet);

                universe = universe.Where(el => !maximumSet.Contains(el)).ToList();

                if (universe.Count == 0)
                    break;
            }

            return setsChoosen;
        }
    }
}

