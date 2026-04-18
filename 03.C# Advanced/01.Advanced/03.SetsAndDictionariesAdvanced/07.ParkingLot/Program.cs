using System.Runtime.InteropServices;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string query = inputArgs[0], licensePlate = inputArgs[1];

                if (query == "IN")
                {
                    parkingLot.Add(licensePlate);
                }
                else if (query == "OUT")
                {
                    parkingLot.Remove(licensePlate);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string licensePlate in  parkingLot)
                {
                    Console.WriteLine(licensePlate);
                }
            }
        }
    }
}
