namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main()
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, bool>[] conditions = new Func<int, bool>[dividers.Length];

            for (int i = 0; i < dividers.Length; i++)
            {
                int currentDivider = dividers[i];
                conditions[i] = x => x % currentDivider == 0;
            }

            int[] result = InRange(1, range, All(conditions));
            Console.WriteLine(string.Join(" ", result));
        }

        static Func<int, bool> All(Func<int, bool>[] conditions)
        {
            return x =>
            {
                foreach (Func<int, bool> condition in conditions)
                    if (!condition(x))
                        return false;

                return true;
            };
        }
        static int[] InRange(int start, int end, Func<int, bool> condition)
        {
            List<int> result = new();

            for (int i = start; i <= end; i++)
            {
                if (condition(i))
                    result.Add(i);
            }

            return result.ToArray();
        }
    }
}

