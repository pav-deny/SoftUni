using CarManufacturer;

namespace CarsManufacturer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = ReadTires();
            List<Engine> engines = ReadEngines();
            List<Car> cars = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0], model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]), fuelConsumption = double.Parse(carInfo[4]);
                Engine engine = engines[int.Parse(carInfo[5])];
                Tire[] carTires = tires[int.Parse(carInfo[6])];

                Car car = new(make, model, year, fuelQuantity, fuelConsumption, engine, carTires);
                cars.Add(car);
            }

            cars = SortCars(cars);

            cars.ForEach(c => PrintSpecialCars(c));
        }


        static List<Tire[]> ReadTires()
        {
            List<Tire[]> tires = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] tiresArr = new Tire[4];
                int index = 0;

                for (int i = 0; i < tireInfo.Length; i += 2)
                {
                    Tire tire = new(int.Parse(tireInfo[i]), double.Parse(tireInfo[i + 1]));
                    tiresArr[index++] = tire;
                }

                tires.Add(tiresArr);
            }

            return tires;
        }

        static List<Engine> ReadEngines()
        {
            List<Engine> engines = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new(int.Parse(engineInfo[0]), double.Parse(engineInfo[1]));
                engines.Add(engine);
            }

            return engines;
        }

        static List<Car> SortCars(List<Car> cars)
        {
            List<Car> sortedCars = new();

            foreach (Car car in cars)
            {
                double pressureSum = car.Tires.Sum(t => t.Pressure);

                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && (pressureSum >= 9 && pressureSum <= 10))
                {
                    car.Drive(20);
                    sortedCars.Add(car);
                }
            }

            return sortedCars;
        }

        static void PrintSpecialCars(Car specialCar)
        {
            Console.WriteLine($"Make: {specialCar.Make}");
            Console.WriteLine($"Model: {specialCar.Model}");
            Console.WriteLine($"Year: {specialCar.Year}");
            Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
            Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
        }
    }
}
