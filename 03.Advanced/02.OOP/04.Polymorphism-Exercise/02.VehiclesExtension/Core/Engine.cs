using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Core.Interfaces;
using Vehicles.Factory.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            List<IVehicle> vehicles = new();

            for (int i = 0; i < 3; i++)
            {
                string[] data = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IVehicle vehicle = vehicleFactory.Create(data[0], double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                vehicles.Add(vehicle);
            }

            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0], type = commandArgs[1];

                IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

                if (command == "Drive")
                {
                    double distance = double.Parse(commandArgs[2]);
                    writer.WriteLine(vehicle.Drive(distance));
                }
                else if (command == "DriveEmpty")
                {
                    ISpecialisedVehicle specialised = vehicle as ISpecialisedVehicle;

                    if (vehicle is null)
                        continue;

                    double distance = double.Parse(commandArgs[2]);
                    writer.WriteLine(specialised.DriveEmpty(distance));

                }
                else if (command == "Refuel")
                {
                    double amount = double.Parse(commandArgs[2]);
                    
                    string message = vehicle.Refuel(amount);

                    if (message != "Refueled")
                        writer.WriteLine(message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
                writer.WriteLine(vehicle.ToString());
        }
    }
}
