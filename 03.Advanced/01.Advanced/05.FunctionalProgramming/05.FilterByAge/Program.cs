namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ");

                Person person = new(data[0], data[1]);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Predicate<int> meetsCondition;

            if (condition == "older")
                meetsCondition = a => a >= age;

            else 
                meetsCondition = a => a < age;

            people = Sort(people, meetsCondition);

            Action<Person> print;

            string printCondition = Console.ReadLine();


            if (printCondition == "name")
                print = p => Console.WriteLine(p.Name);

            else if (printCondition == "age")
                print = p => Console.WriteLine(p.Age);

            else
                print = p => Console.WriteLine($"{p.Name} - {p.Age}");


            foreach (Person person in people)
                print(person);
        }
        static List<Person> Sort(List<Person> people, Predicate<int> meetsCondition)
        {
            List<Person> result = new();

            foreach (Person person in people)
            {
                if(meetsCondition(person.Age))
                    result.Add(person);
            }

            return result;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person (string name, string ageStr)
        {
            Name = name;
            Age = int.Parse(ageStr);
        }
    }
}
