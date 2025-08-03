namespace _03.DegustationParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Guest> guests = new();
            int dislikedMealsCount = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commandArgs = command.Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Like")
                {
                    string name = commandArgs[1];
                    string likedMeal = commandArgs[2];

                    if (!guests.ContainsKey(commandArgs[1]))
                    {
                        Guest guest = new Guest(name);
                        guests.Add(name, guest);
                    }
                    else if (guests[name].LikedMeals.Contains(likedMeal))
                    {
                        continue;
                    } 
                    guests[name].LikedMeals.Add(likedMeal);
                }

                else if (commandArgs[0] == "Dislike")
                {
                    string name = commandArgs[1];
                    string dislikedMeal = commandArgs[2];

                    if (!guests.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} is not at the party.");
                    }
                    else if (!guests[name].LikedMeals.Contains(dislikedMeal))
                    {
                        Console.WriteLine($"{name} doesn't have the {dislikedMeal} in his/her collection.");
                    }
                    else
                    {
                        guests[name].LikedMeals.Remove(dislikedMeal);
                        Console.WriteLine($"{name} doesn't like the {dislikedMeal}.");
                        dislikedMealsCount++;
                    }
                }

            }

            foreach ((string name, Guest guest) in guests)
            {
                Console.WriteLine($"{name}: {string.Join(", ", guest.LikedMeals)}");
            }

            Console.WriteLine($"Unliked meals: {dislikedMealsCount}");
        }
    }

    public class Guest
    {
        public string Name { get; set; }
        public List<string> LikedMeals { get; set; }

        public Guest(string name)
        {
            Name = name;
            LikedMeals = new();
        }
    }
}
