namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = data[0];

                Engine engine = new() { Speed = int.Parse(data[1]), Power = int.Parse(data[2]) };
                Cargo cargo = new() { Weight = int.Parse(data[3]), Type = data[4] };

                Tire[] tires = ReadTires(data);

                Car car = new(model, engine, cargo, tires);
                cars.Add(car);
            }

            string query = Console.ReadLine();
            Func<Car, bool> condition;

            if (query == "fragile")
                condition = c => c.Cargo.Type == query && c.Tires.Any(t => t.Pressure < 1);

            else if (query == "flammable")
                condition = c => c.Cargo.Type == query && c.Engine.Power > 250;

            else
                condition = c => false;

            foreach (Car car in cars.Where(condition))
            {
                Console.WriteLine(car.Model);
            }
        }

        static Tire[] ReadTires(string[] data)
        {
            Tire[] tires = new Tire[4];
            int dataIndex = 5;

            for (int i = 0; i < 4; i++)
            {
                Tire tire = new() { Pressure = double.Parse(data[dataIndex]), Age = int.Parse(data[dataIndex + 1]) };

                tires[i] = tire;
                dataIndex += 2;
            }

            return tires;
        }
    }
}
