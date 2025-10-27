namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
        public virtual int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (age >= 0)
                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} -> Name: {Name}, Age: {Age}";
        }
    }
}
