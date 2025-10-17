using CustomQueue;

namespace Project
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            MyQueue queue = new();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        int num = Random.Shared.Next(0, 100);
                        queue.Enqueue(num);
                        Console.WriteLine($"Added {num}");
                        PrintQueue(queue);
                    }

                    for (int k = 0; k < 3; k++)
                    {
                        int removed = queue.Dequeue();
                        Console.WriteLine($"Removed {removed}");
                        PrintQueue(queue);
                    }

                    for (int k = 0; k < 2; k++)
                    {
                        int rotated = queue.Dequeue();
                        queue.Enqueue(rotated);

                        Console.WriteLine($"Rotated {rotated}");
                        PrintQueue(queue);
                    }
                }

                while (queue.Count > 0)
                {
                    int removed = queue.Dequeue();
                    Console.WriteLine($"Removed {removed}");
                    PrintQueue(queue);
                }
            }
        }

        static void PrintQueue(MyQueue queue)
        {
            if (queue.Count <= 0)
            {
                Console.WriteLine("Count: 0 | The queue is empty");
                return;
            }
            int[] arr = queue.ToArray();

            Console.WriteLine($"Count: {queue.Count} | Queue: {string.Join(", ", arr)} | First: {queue.Peek()}");
        }
    }
}
