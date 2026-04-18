namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        { 
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = personData[0], lastName = personData[1];
                int age = int.Parse(personData[2]);

                Person person = new(firstName, lastName, age);
                people.Add(person);
            }

            people = people.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList();

            foreach(Person person in people)
                Console.WriteLine(person);
        }
    }
}
