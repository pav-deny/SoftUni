namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingMap = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string user = arguments[1];

                switch (arguments[0])
                {
                    case "register":
                        string licensePlate = arguments[2];

                        if (CheckIfParked(user, parkingMap))
                        {
                            string usedLicensePlate = parkingMap[user];
                            Console.WriteLine($"ERROR: already registered with plate number {usedLicensePlate}");

                            break;
                        }

                        parkingMap.Add(user, licensePlate);
                        Console.WriteLine($"{user} registered {licensePlate} successfully");
                        
                        break;

                    case "unregister":

                        if (!CheckIfParked(user, parkingMap))
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                            break;
                        }

                        parkingMap.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");

                        break;
                }
            }

            foreach((string user, string licensePlate) in parkingMap)
            {
                Console.WriteLine($"{user} => {licensePlate}");
            }
        }

        static bool CheckIfParked(string user, Dictionary<string, string> parkingMap)
        {
            if (parkingMap.ContainsKey(user))
            {
                return true;
            }

            return false;
        }
    }
}
