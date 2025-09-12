namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> stations = new();

            for (int i = 0; i < n; i++)
            {
                int[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                stations.Enqueue(parameters);
            }

            int answer = -1;

            for (int i = 0; i < stations.Count;i++)
            {
                int fuel = 0;
                bool canComplete = true;

                foreach (int[] station in stations)
                {
                    fuel += station[0] - station[1];

                    if (fuel < 0)
                    {
                        canComplete = false;
                        break;
                    }

                }

                if (canComplete)
                {
                    answer = i;
                    Console.WriteLine(answer);
                    return;
                }

                stations.Enqueue(stations.Dequeue());
            }
        }
    }
}
