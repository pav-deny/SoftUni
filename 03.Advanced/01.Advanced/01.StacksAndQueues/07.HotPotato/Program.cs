namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());

            Queue<string> kidsQueue = new(kids);
            //int i = 1;

            while (kidsQueue.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    string kid = kidsQueue.Dequeue();
                    kidsQueue.Enqueue(kid);
                }

                Console.WriteLine($"Removed {kidsQueue.Dequeue()}");

                //if (i == n)
                //{
                //    Console.WriteLine($"Removed {kid}");
                //    i = 1;
                //}

                //else
                //{
                //    kidsQueue.Enqueue(kid);
                //    i++;
                //}
            }

            Console.WriteLine($"Last is {kidsQueue.Dequeue()}");
        }
    }
}
