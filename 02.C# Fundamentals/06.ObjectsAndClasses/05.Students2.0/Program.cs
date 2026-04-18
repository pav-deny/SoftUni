namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new();

            string info = string.Empty;
            while ((info = Console.ReadLine()) != "end")
            {
                string[] studentInfo = info.Split();

                Student student = new()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Age = int.Parse(studentInfo[2]),
                    City = studentInfo[3]
                };

                bool isUnique = true;

                foreach (Student person in students)
                {
                    if (person.Name == student.Name)
                    {
                        person.Age = student.Age;
                        person.City = student.City;
                        isUnique = false;
                    }
                }

                if (isUnique)
                {
                    students.Add(student);
                }
            }

            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == city)
                {
                    Console.WriteLine($"{student.Name} is {student.Age} years old.");
                }
            }

        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}

