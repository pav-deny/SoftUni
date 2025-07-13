using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new();

            string personInfo = string.Empty;
            while ((personInfo = Console.ReadLine()) != "End")
            {
                string[] personInfoArr = personInfo.Split();

                string name = personInfoArr[0];
                string id = personInfoArr[1];
                int age = int.Parse(personInfoArr[2]);

                Person person = new()
                {
                    Name = name,
                    ID = id,
                    Age = age
                };

                people = Person.CheckForSameID(person, people);
            }

            SortAndPrint(people);

        }

        static void SortAndPrint(List<Person> people)
        {
            people = people.OrderBy(p => p.Age).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }


        public Person()
        {

        }

        public static List<Person> CheckForSameID(Person person, List<Person> people)
        {
            Person personWithSameID = people.Find(p => p.ID ==  person.ID);

            if (personWithSameID == null)
            {
                people.Add(person);
                return people;
            }

            people = ReplaceSameID(person, people);
            return people;
        }

        static List<Person> ReplaceSameID(Person person, List<Person> people)
        {
            int index = people.FindIndex(t => t.ID == person.ID);

            people.RemoveAt(index);

            people.Insert(index, person);

            return people;
        }
    }
}
