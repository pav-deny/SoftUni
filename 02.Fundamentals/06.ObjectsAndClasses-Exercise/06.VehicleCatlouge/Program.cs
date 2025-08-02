using System.Linq.Expressions;

namespace _06.VehicleCatlouge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehiclesList = new();

            string carInfo = string.Empty;
            while ((carInfo = Console.ReadLine()) != "End")
            {
                string[] carInfoArgs = carInfo.Split();

                Vehicle vehicle = new(carInfoArgs[0], carInfoArgs[1], carInfoArgs[2], carInfoArgs[3]);

                vehiclesList.Add(vehicle);
            }


            string carModel = string.Empty;
            while ((carModel = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle vehicle = vehiclesList.Find(m => m.Model == carModel);

                Console.WriteLine($"Type: {vehicle.Type}");
                Console.WriteLine($"Model: {vehicle.Model}\nColor: {vehicle.Color}\nHorsepower: {vehicle.HorsePower}");
            }

            decimal averageHPCars = Vehicle.GetAverageHP(vehiclesList, "Car");
            decimal averageHPTrucks = Vehicle.GetAverageHP(vehiclesList, "Truck");

            Console.WriteLine($"Cars have average horsepower of: {averageHPCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHPTrucks:f2}.");

        }
    }

    public class Vehicle
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }


        public Vehicle(string type, string model, string color, string horsepower)
        {
            Type = ToUpperFirstLetter(type);
            Model = model;
            Color = color;
            HorsePower = int.Parse(horsepower);
        }

        public static decimal GetAverageHP(List<Vehicle> vehicles, string type)
        {
            decimal sumOfHp = 0;
            int count = 0;

            List<Vehicle> vehiclesOfSameType = vehicles.FindAll(v => v.Type == type);

            foreach (Vehicle vehicle in vehiclesOfSameType)
            {
                sumOfHp += vehicle.HorsePower;
                count++;
            }

            if (count == 0)
            {
                return 0;
            }

            decimal averageHp = sumOfHp / count;
            
            return averageHp;
        }

         public static string ToUpperFirstLetter(string vehicleType)
        {
            vehicleType = char.ToUpper(vehicleType[0]) + vehicleType.Substring(1);

            return vehicleType;
        }
    }
}
