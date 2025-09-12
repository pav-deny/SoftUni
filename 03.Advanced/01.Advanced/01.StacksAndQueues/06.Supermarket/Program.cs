namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    PrintQueue(queue);
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }

        private static void PrintQueue(Queue<string> queue)
        {
            foreach (string customer in queue)
            {
                Console.WriteLine(customer);
            } 
        }
    }
}
