namespace DefiningClasses
{ 
    public class Person
    {
        public Person()
            :this(1)
        {

        }
        public Person(int age)
            : this("No name", age)
        { 

        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private string name;
        private int age;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
    }
}
