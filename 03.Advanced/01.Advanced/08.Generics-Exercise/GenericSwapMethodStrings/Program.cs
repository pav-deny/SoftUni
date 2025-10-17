namespace GenericSwapMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> list = new();

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new(Console.ReadLine());
                list.Add(box);
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Swap(list, indexes[0], indexes[1]);

            list.ForEach(x => Console.WriteLine(x.ToString()));
        }

        static void Swap<T>(List<Box<T>> list, int index1, int index2)
        {
            Box<T> previous = list[index1];

            list[index1] = list[index2];
            list[index2] = previous;
        }
    }
}
