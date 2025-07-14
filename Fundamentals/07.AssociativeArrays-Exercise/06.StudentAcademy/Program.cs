using System.Globalization;

namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            Dictionary<string, Student> studentsGrades = new();

            for (int i  = 0; i < rowsCount; i++)
            {
                string name = Console.ReadLine();
                decimal grade = decimal.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new Student(name));
                }

                studentsGrades[name].Grades.Add(grade);
            }

            var filteredStudents = studentsGrades.Where(x => x.Value.GetAverage() >= 4.5m);


            foreach((string name, Student student) in  filteredStudents)
            {
                //decimal averageGrade = student.GetAverage();

                Console.WriteLine(student.Print());
            }
        }
    }
  

    public class Student
    {
        public string Name { get; set; }
        public List<decimal> Grades { get; set; }

        public Student(string name)
        {
            Name = name;
            Grades = new();
        }

        public decimal GetAverage()
        {
            int gradesCount = Grades.Count;
            decimal gradesSum = Grades.Sum();
            
            return gradesSum / gradesCount;
        }

        public string Print()
        {
            string result = $"{Name} -> {GetAverage():f2}";

            return result;
        }
    }
}
