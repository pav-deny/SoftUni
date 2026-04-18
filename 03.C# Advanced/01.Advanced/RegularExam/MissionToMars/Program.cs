namespace MissionToMars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> solarEnergy = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Queue<int> dailyDistance = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Stack<int> resourceWeight = new(new int[] { 70, 60, 100, 90, 80 });
            List<int> gatheredResourcesWeights = new();

            while (solarEnergy.Count > 0 && dailyDistance.Count > 0 && resourceWeight.Count > 0)
            {
                int currentEnergy = solarEnergy.Pop();
                int currentDistance = dailyDistance.Dequeue();

                int sum = currentEnergy + currentDistance;

                int currentWeight = resourceWeight.Peek();

                if (sum >= currentWeight)
                {
                    gatheredResourcesWeights.Add(resourceWeight.Pop());
                }
            }

            if (gatheredResourcesWeights.Count == 5)
            {
                Console.WriteLine("Mission complete! All minerals have been collected.");
            }
            else
            {
                Console.WriteLine("Mission not completed! Awaiting further instructions from Earth.");
            }

            if (gatheredResourcesWeights.Count <= 0)
                return;

            Console.WriteLine("Collected resources:");

            Dictionary<int, string> resources = new()
            {
                { 80, "Iron" },
                { 90, "Titanium"},
                { 100, "Aluminium"},
                { 60, "Chlorine"},
                { 70, "Sulfur" }
            };

            foreach (int weight in gatheredResourcesWeights)
            {
                Console.WriteLine(resources[weight]);
            }
        }
    }
}
