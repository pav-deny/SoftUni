namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> carByModel = new();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new()
                {
                    Model = data[0],
                    FuelAmount = double.Parse(data[1]),
                    FuelConsumption = double.Parse(data[2])
                };

                carByModel[car.Model] = car;
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commandArgs[1];
                double distance = double.Parse(commandArgs[2]);

                Car car = carByModel[model];

                if (!car.Drive(distance))
                    Console.WriteLine("Insufficient fuel for the drive");
            }

            foreach (Car car in carByModel.Values)
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }
    }
}
