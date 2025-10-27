using FootballTeamGenerator.Models;

namespace FootballTeamGenerator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] parts = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            string teamName = parts[1];
                            Team team = new Team(teamName);
                            teams[teamName] = team;
                            break;

                        case "Add":
                            teamName = parts[1];
                            if (!teams.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                break;
                            }

                            string playerName = parts[2];
                            int endurance = int.Parse(parts[3]);
                            int sprint = int.Parse(parts[4]);
                            int dribble = int.Parse(parts[5]);
                            int passing = int.Parse(parts[6]);
                            int shooting = int.Parse(parts[7]);

                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams[teamName].AddPlayer(player);
                            break;

                        case "Remove":
                            teamName = parts[1];
                            playerName = parts[2];

                            if (!teams.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                break;
                            }

                            teams[teamName].RemovePlayer(playerName);
                            break;

                        case "Rating":
                            teamName = parts[1];
                            if (!teams.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                break;
                            }

                            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
