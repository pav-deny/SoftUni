namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodCount = int.Parse(Console.ReadLine());
            
            Queue<int> orders = new(ReadOrders());

            int biggestOrder = orders.Max(); 

            while (orders.Count > 0)
            {
                if (orders.Peek() > foodCount)
                    break;

                foodCount -= orders.Dequeue();
            }

            Console.WriteLine(biggestOrder);

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
            }
        }

        static Queue<int> ReadOrders()
        {
            IEnumerable<int> sequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            return new Queue<int>(sequence);
        }
    }
}
