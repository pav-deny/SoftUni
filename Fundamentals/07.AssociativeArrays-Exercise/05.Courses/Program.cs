namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Course> coursesMap = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] courseData = input.Split(" : ");

                string courseName = courseData[0];
                string studentName = courseData[1];

                if (!coursesMap.ContainsKey(courseName))
                {
                    Course course = new(courseName);
                    coursesMap.Add(courseName, course);
                }

                coursesMap[courseName].Students.Add(studentName);
            }

            foreach ((string name, Course course)  in coursesMap)
            {
                int studentsCount = course.Students.Count;

                Console.WriteLine($"{name}: {studentsCount}");

                course.PrintStudents();
            }
        }
    }

    public class Course
    {
        public string Name { get; set; }

        public List<string> Students { get; set; }

        public Course(string name)
        {
            Name = name;
            Students = new();
        }

        public void PrintStudents()
        {
            foreach (string student in Students)
            {
                Console.WriteLine($"-- {student}");
            }
        }
    }
}
