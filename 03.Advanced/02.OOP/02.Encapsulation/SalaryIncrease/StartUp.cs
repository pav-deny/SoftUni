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
                decimal salary = decimal.Parse(personData[3]);

                Person person = new(firstName, lastName, age, salary);
                people.Add(person);
            }

            decimal percantage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(percantage));

            foreach (Person person in people)
                Console.WriteLine(person);
        }
    }
}
