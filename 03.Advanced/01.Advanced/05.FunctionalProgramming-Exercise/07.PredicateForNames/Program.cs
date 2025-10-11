namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Iterate(Filter(names, x => x.Length <= n), s => Console.WriteLine(s));
        }

        static string[] Filter(string[] arr, Func<string, bool> condition)
        {
            List<string> result = new();

            foreach (string s in arr)
            {
                if (condition(s))
                    result.Add(s);
            }

            return result.ToArray();
        }

        static void Iterate(string[] arr, Action<string> action)
        {
            foreach (string s in arr)
                action(s);
        }
    }
}
