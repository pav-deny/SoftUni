namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> enginesByModel = new();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = data[0];
                int power = int.Parse(data[1]);

                int? displacement = null;
                string? efficiency = null;

                if (data.Length == 4)
                {
                    displacement = int.Parse(data[2]);
                    efficiency = data[3];
                }
                else if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int temp))
                    {
                        displacement = temp;
                    }
                    else
                    {
                        efficiency = data[2];
                    }
                }

                Engine engine = new(model, power, displacement, efficiency);
                enginesByModel[model] = engine;
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new();

            for (int i = 0; i < m; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0], engineModel = data[1];

                Engine engine = enginesByModel[engineModel];

                int? weight = null;
                string? color = null;

                if (data.Length == 4)
                {
                    weight = int.Parse(data[2]);
                    color = data[3];
                }
                else if (data.Length == 3)
                {
                    if (int.TryParse(data[2], out int temp))
                    {
                        weight = temp;
                    }
                    else
                    {
                        color = data[2];
                    }
                }

                Car car = new(model, engine, weight, color);
                cars.Add(car);
            }

            foreach (Car car in cars)
                Console.WriteLine(car.ToString());

            //Console.ReadLine();
            //Console.Clear();
            //Main(args);
        }
    }
}


