namespace EqualityLogic
{
    public class Person : IEquatable<Person>, IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public bool Equals(Person? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return StringComparer.InvariantCultureIgnoreCase.Equals(this.Name, other.Name)
                && this.Age.CompareTo(other.Age) == 0;
        }

        public override bool Equals(object obj) => obj is Person p && Equals(p);

        public override int GetHashCode()
        {
            return HashCode.Combine(StringComparer.InvariantCultureIgnoreCase.GetHashCode(this.Name), this.Age);
        }

        public int CompareTo(Person? other)
        {
            if (other == null) return -1;

            int result = StringComparer.OrdinalIgnoreCase.Compare(this.Name, other.Name);

            if (result == 0)
                result = this.Age.CompareTo(other.Age);

            return result;
        }

    }
}
