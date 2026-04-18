using BirthdayCelebrations.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : INamable, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public int Age { get; private set; }
        public string Name { get; private set; }
        public string Id { get; private set; }
        public string BirthDate {get; private set; }
    }
}
