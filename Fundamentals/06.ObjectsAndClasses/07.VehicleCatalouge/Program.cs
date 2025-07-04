using System.Runtime.CompilerServices;

namespace _07.VehicleCatalouge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();
            List<Truck> trucks = new();
    
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] vehicleData = input.Split('/');

                if (vehicleData[0] == "Car")
                {
                    Car car = new()
                    {
                        Brand = vehicleData[1],
                        Model = vehicleData[2],
                        HorsePower = double.Parse(vehicleData[3])
                    };

                    cars.Add(car);
                }
                else if (vehicleData[0] == "Truck")
                {
                    Truck truck = new()
                    {
                        Brand = vehicleData[1],
                        Model = vehicleData[2],
                        Weight = double.Parse(vehicleData[3])
                    };

                    trucks.Add(truck);
                }
            }

            trucks = trucks.OrderBy(Truck => Truck.Brand).ToList();
            cars = cars.OrderBy(Car => Car.Brand).ToList();

            Catalouge catalouge = new()
            {
                Cars = cars,
                Trucks = trucks
            };

            Catalouge.PrintCatalouge(catalouge);
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }

    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    public class Catalouge
    {
        public Catalouge()
        {

        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }

        public static void PrintCatalouge(Catalouge catalouge)
        {
            if (catalouge.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");

                for (int i = 0; i < catalouge.Cars.Count; i++)
                {
                    Car car = catalouge.Cars[i];

                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }

            }

            if (catalouge.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                for (int i = 0; i < catalouge.Trucks.Count; i++)
                {
                    Truck truck = catalouge.Trucks[i];

                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    }
