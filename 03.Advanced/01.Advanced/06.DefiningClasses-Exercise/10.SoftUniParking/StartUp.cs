namespace SoftUniParking
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var car1 = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");

            // 2. Print cars using ToString()
            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());

            // 3. Create parking with capacity 5
            var parking = new Parking(5);

            // 4. Add cars to parking
            Console.WriteLine(parking.AddCar(car1)); // Successfully added
            Console.WriteLine(parking.AddCar(car1)); // Already exists
            Console.WriteLine(parking.AddCar(car2)); // Successfully added

            // 5. Get car by registration number and print
            Car retrievedCar = parking.GetCar("EB8787MN");
            Console.WriteLine(retrievedCar.ToString());

            // 6. Remove a car
            Console.WriteLine(parking.RemoveCar("EB8787MN")); // Successfully removed
            Console.WriteLine(parking.RemoveCar("EB8787MN")); // Doesn't exist

            // 7. Count cars currently in parking
            Console.WriteLine(parking.Count); // 1
        }
    }
}
