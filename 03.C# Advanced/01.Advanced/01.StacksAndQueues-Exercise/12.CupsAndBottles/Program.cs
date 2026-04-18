namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bottles = new(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wasted = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int cup = cups.Peek();

                while (cup > 0 && bottles.Count > 0)
                {
                    int bottle = bottles.Pop();

                    if (bottle >= cup)
                    {
                        wasted += bottle - cup;
                        cups.Dequeue();
                        cup = 0;
                    }
                    else
                    {
                        cup -= bottle;
                    }
                }
            }
                
            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
