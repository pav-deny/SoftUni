namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(data[0], int.Parse(data[1]), data[2]);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            Person nPerson = people[n - 1];
            int matches = 0;

            foreach (Person person in people)
            {
               int result = person.CompareTo(nPerson);

                if (result == 0)
                    matches++;
            }

            if (matches == 1)
                Console.WriteLine("No matches");

            else
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
        }
    }
}
