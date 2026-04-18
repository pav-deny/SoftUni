using CarDealership.Core.Contracts;
using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Repositories;
using CarDealership.Utilities.Messages;
using System.Text;

namespace CarDealership.Core
{
    public class Controller : IController
    {
        private readonly IDealership _dealership;

        public Controller()
        {
            _dealership = new Dealership();
        }

        public string AddCustomer(string customerTypeName, string customerName)
        {
            if (customerTypeName != nameof(IndividualClient) && customerTypeName != nameof(LegalEntityCustomer))
                return string.Format(OutputMessages.InvalidType, customerTypeName);

            if (_dealership.Customers.Exists(customerName))
                return string.Format(OutputMessages.CustomerAlreadyAdded, customerName);

            ICustomer customer = customerTypeName == nameof(IndividualClient)
                ? new IndividualClient(customerName)
                : new LegalEntityCustomer(customerName);

            _dealership.Customers.Add(customer);

            return string.Format(OutputMessages.CustomerAddedSuccessfully, customerName);
        }

        public string AddVehicle(string vehicleTypeName, string model, double price)
        {
            if (vehicleTypeName != nameof(SaloonCar) && vehicleTypeName != nameof(SUV) && vehicleTypeName != nameof(Truck))
                return string.Format(OutputMessages.InvalidType, vehicleTypeName);

            if (_dealership.Vehicles.Exists(model)) //TODO: fix this line
                return string.Format(OutputMessages.VehicleAlreadyAdded, model);

            IVehicle vehicle;

            if (vehicleTypeName == nameof(SaloonCar))
            {
                vehicle = new SaloonCar(model, price);
            }
            else if (vehicleTypeName == nameof(SUV))
            {
                vehicle = new SUV(model, price);
            }
            else //if (vehicleTypeName == nameof(Truck)
            {
                vehicle = new Truck(model, price);
            }
            
            _dealership.Vehicles.Add(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, vehicleTypeName, model, $"{vehicle.Price:f2}");
        }

        public string PurchaseVehicle(string vehicleTypeName, string customerName, double budget)
        {
           if (!_dealership.Customers.Exists(customerName))
                return string.Format(OutputMessages.CustomerNotFound, customerName);

            if (!_dealership.Vehicles.Models.Any(v => v.GetType().Name == vehicleTypeName))
                return string.Format(OutputMessages.VehicleTypeNotFound, vehicleTypeName);

            ICustomer customer = _dealership.Customers.Get(customerName);
            string customerType = customer.GetType().Name;

            if ((customerType == nameof(IndividualClient) && vehicleTypeName == nameof(Truck)) ||
                (customerType == nameof(LegalEntityCustomer) && vehicleTypeName == nameof(SaloonCar)))
                 return string.Format(OutputMessages.CustomerNotEligibleToPurchaseVehicle, customerName, vehicleTypeName);

            List<IVehicle> filteredVehices = _dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName && v.Price <= budget).ToList();

            if (!filteredVehices.Any())
                return string.Format(OutputMessages.BudgetIsNotEnough, customerName, vehicleTypeName);

            IVehicle vehicle = filteredVehices.MaxBy(v => v.Price);

            customer.BuyVehicle(vehicle.Model);
            vehicle.SellVehicle(customer.Name);

            return string.Format(OutputMessages.VehiclePurchasedSuccessfully, customerName, vehicle.Model);
        }

        public string CustomerReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Customer Report:");

            foreach(ICustomer customer in _dealership.Customers.Models.OrderBy(c => c.Name))
            {
                sb.AppendLine(customer.ToString());
                sb.AppendLine("-Models:");

                if (customer.Purchases.Count == 0)
                {
                    sb.AppendLine("--none");
                }

                else
                {
                    foreach(string vehicleModel in customer.Purchases.OrderBy(v => v))
                    {
                        sb.AppendLine($"--{vehicleModel}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SalesReport(string vehicleTypeName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{vehicleTypeName} Sales Report:");

            List<IVehicle> vehicles = _dealership.Vehicles.Models
                .Where(v => v.GetType().Name == vehicleTypeName).ToList();

            foreach (IVehicle vehicle in vehicles.OrderBy(v => v.Model))
            {
                sb.AppendLine($"--{vehicle.ToString()}");
            }

            sb.AppendLine($"-Total Purchases: {vehicles.Sum(v => v.SalesCount)}");

            return sb.ToString().Trim();
        }
    }
}
