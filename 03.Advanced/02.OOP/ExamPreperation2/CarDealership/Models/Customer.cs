using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        private string _name;
        private readonly List<string> _purchases;

        public Customer(string name)
        {
            Name = name;

            _purchases = new List<string>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameIsRequired);

                _name = value;
            }
        }
        public IReadOnlyCollection<string> Purchases => _purchases.AsReadOnly();


        public void BuyVehicle(string vehicleModel)
        {
            _purchases.Add(vehicleModel);
        }

        public override string ToString() => $"{Name} - Purchases: {Purchases.Count}";
    }
}
