namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }
        public Person GetoOldest()
        {
            return this.people.MaxBy(p => p.Age);
        }
    }
}
