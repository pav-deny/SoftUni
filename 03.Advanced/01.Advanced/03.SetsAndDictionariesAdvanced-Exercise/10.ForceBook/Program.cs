namespace ForceUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] tokens = input.Split(" | ");
                    string side = tokens[0];
                    string user = tokens[1];

                    if (!users.ContainsKey(user))
                    {
                        users[user] = side;
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] tokens = input.Split(" -> ");
                    string user = tokens[0];
                    string side = tokens[1];

                    users[user] = side;
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var sides = users
                .GroupBy(u => u.Value)
                .Where(g => g.Count() > 0)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key);

            foreach (var side in sides)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Count()}");
                foreach (var user in side.OrderBy(u => u.Key))
                {
                    Console.WriteLine($"! {user.Key}");
                }
            }
        }
    }
}
