namespace _07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (HashSet<string> followers, HashSet<string> following)> vloggersMap = new();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 4 && data[1] == "joined")
                {
                    string username = data[0];

                    if (!vloggersMap.ContainsKey(username))
                    {
                        vloggersMap[username] = (followers: new(), following: new());
                    }
                }
                else if (data.Length == 3 && data[1] == "followed")
                {
                    string fan = data[0], vlogger = data[2];

                    if (vloggersMap.ContainsKey(fan) && vloggersMap.ContainsKey(vlogger) && fan != vlogger)
                    {
                        vloggersMap[vlogger].followers.Add(fan);
                        vloggersMap[fan].following.Add(vlogger);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggersMap.Count} vloggers in its logs.");

            int currentVlogger = 1;

            foreach ((string username, (HashSet<string> followedBy, HashSet<string> following)) in vloggersMap.OrderByDescending(x => x.Value.followers.Count).ThenBy(x => x.Value.following.Count))
            {
                Console.WriteLine($"{currentVlogger}. {username} : {followedBy.Count} followers, {following.Count} following");

                if (currentVlogger == 1)
                {
                    foreach (string user in followedBy.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {user}");
                    }
                }

                currentVlogger++;
            }
        }
    }
}
