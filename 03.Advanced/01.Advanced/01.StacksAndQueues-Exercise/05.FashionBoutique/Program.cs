namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesStack = new(ReadClothes());
            int capacity = int.Parse(Console.ReadLine());

            int count = 0, remaining = 0;

            while (clothesStack.Count > 0)
            {
                int current = clothesStack.Pop();
                
                if (current > remaining)
                {
                    count++;
                    remaining = capacity;
                }

                remaining -= current;
            }

            Console.WriteLine(count);
        }

        private static Stack<int> ReadClothes()
        {
            IEnumerable<int> sequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            return new Stack<int>(sequence);
        }
    }
}
