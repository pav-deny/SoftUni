using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> studentsList = new();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();

                Student currentStudent = new()
                {
                    FirstName = studentInfo[0],
                    LastName = studentInfo[1],
                    Grade = decimal.Parse(studentInfo[2])
                };

                studentsList.Add(currentStudent);
            }

            studentsList = studentsList.OrderByDescending(Student => Student.Grade).ToList();

            for (int i = 0; i < studentsCount; i++)
            {
                Student student = studentsList[i];
                Console.WriteLine($"{student.FullName}: {student.Grade:f2}");
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Grade { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        static Student()
        {

        }
    }
}
