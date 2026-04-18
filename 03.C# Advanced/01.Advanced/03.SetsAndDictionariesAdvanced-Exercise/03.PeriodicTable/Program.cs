namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            HashSet<string> elements = new();
            //SortedSet<string> elements = new();

            for (int i = 0; i < linesCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in input)
                    elements.Add(element);
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
            //If using SortedSet remove .OrderBy(x => x)
        }
    }
}
