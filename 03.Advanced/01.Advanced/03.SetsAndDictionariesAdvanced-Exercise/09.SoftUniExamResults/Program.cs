namespace ExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> users = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            string input;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = input.Split('-');
                string username = tokens[0];

                if (tokens[1] == "banned")
                {
                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }
                else
                {
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!users.ContainsKey(username))
                    {
                        users[username] = points;
                    }
                    else
                    {
                        if (users[username] < points)
                        {
                            users[username] = points;
                        }
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 1;
                    }
                    else
                    {
                        submissions[language]++;
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var user in users.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var lang in submissions.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }
        }
    }
}

