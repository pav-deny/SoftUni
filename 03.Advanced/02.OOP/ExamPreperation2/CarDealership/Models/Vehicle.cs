using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;

namespace CarDealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string _model;
        private double _price;
        private readonly List<string> _buyers;//NOTE: Not sure of readonly - may cause errors

        public Vehicle(string model, double price)
        {
            Model = model;
            Price = price;

            _buyers = new List<string>();
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ModelIsRequired);

                _model = value;
            }
        }
        public double Price
        {
            get => _price;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.PriceMustBePositive);

                _price = value;
            }
        }
        public IReadOnlyCollection<string> Buyers => _buyers.AsReadOnly();
        public int SalesCount => Buyers.Count;


        public void SellVehicle(string buyerName)
        {
            _buyers.Add(buyerName);
        }

        public override string ToString() => $"{Model} - Price: {Price:f2}, Total Model Sales: {SalesCount}";
    }
}
