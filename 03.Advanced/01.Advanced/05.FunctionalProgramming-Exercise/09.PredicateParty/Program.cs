namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commandData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string criterea = commandData[1];
                string argument = commandData[2];

                Predicate<string> matchesCriterea;

                if (criterea == "StartsWith")
                {
                    matchesCriterea = x => x.StartsWith(argument);
                }
                else if (criterea == "EndsWith")
                {
                    matchesCriterea = x => x.EndsWith(argument);
                }
                else
                {
                    matchesCriterea = x => x.Length == int.Parse(argument);
                }


                if (commandData[0] == "Remove")
                    people.RemoveAll(matchesCriterea);

                else if (commandData[0] == "Double")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (matchesCriterea(people[i]))
                        {
                            people.Insert(i + 1, people[i]);
                            i++;
                        }
                    }
                }
            }
                if (people.Count == 0)
                {
                    Console.WriteLine("Nobody is going to the party!");
                    return;
                }

                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
        }
    }
}