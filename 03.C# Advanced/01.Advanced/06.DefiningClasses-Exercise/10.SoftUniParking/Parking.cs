using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> Cars { get; set; }
        private readonly int capacity;
        public int Count => Cars.Count;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            Cars = new Dictionary<string, Car>();
        }

        public string AddCar(Car car)
        {
            if (Cars.ContainsKey(car.RegistrationNumber))
                return "Car with that registration number, already exists!";

            else if (Cars.Count == capacity)
                return "Parking is full!";

            else
            {
                Cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.ContainsKey(registrationNumber))
                return "Car with that registration number, doesn't exist!";     
            
            else
            {
                Cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars[registrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumber)
        {
            foreach (string number  in registrationNumber) 
               RemoveCar(number);
        }
    }
}
