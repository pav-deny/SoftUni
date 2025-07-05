using System.Linq.Expressions;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();


            for (int i = 0; i < teamsCount; i++)
            {
                string[] teamArguments = Console.ReadLine().Split("-");
                string teamCreator = teamArguments[0];
                string teamName = teamArguments[1];

                Team teamWithSameName = teams.Find(t => t.Name == teamName);

                if (teamWithSameName != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                Team creatorAlreadyMadeATeam = teams.Find(t => t.Creator == teamCreator);

                if (creatorAlreadyMadeATeam != null)
                {
                    Console.WriteLine($"{teamCreator} cannot create another team!");
                    continue;
                }

                Team newTeam = new() { Creator = teamCreator, Name = teamName, Members = new() };

                teams.Add(newTeam);
                Console.WriteLine($"Team {newTeam.Name} has been created by {newTeam.Creator}!");
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] memberArguments = input.Split("->");

                string memberName = memberArguments[0];
                string teamToJoin = memberArguments[1];

                if(!teams.Any(t => t.Name == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }

               if (teams.Any(tm => tm.Creator == memberName) || teams.Any(t => t.Members.Contains(memberName)))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
                    continue;
                }

                teams.Find(t => t.Name == teamToJoin).Members.Add(memberName);               
            }

            List<Team> teamsToDisband = new();

            teams = teams.OrderBy(t => t.Name).ToList();
            teams = teams.OrderByDescending(t => t.Members.Count()).ToList();
            
            foreach(Team team in teams)
            {
                if(team.Members.Count <= 0)
                {
                    teamsToDisband.Add(team);
                    continue;
                }

                Console.WriteLine($"{team.Name}\n- {team.Creator}");

                foreach (string member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team lTeam in teamsToDisband)
            {
                Console.WriteLine(lTeam.Name);
            }
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public Team()
        {

        }
    }
}