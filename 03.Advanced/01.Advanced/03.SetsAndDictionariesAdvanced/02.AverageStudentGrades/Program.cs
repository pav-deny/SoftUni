namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsGrades = new();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                decimal grade = decimal.Parse(info[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<decimal>();
                }

                studentsGrades[name].Add(grade);
            }

            foreach ((string student, List <decimal> grades) in studentsGrades)
            {
                //decimal average = grades.Average();
                string gradesStr = string.Empty;
                decimal sum = 0;

                foreach (decimal grade in grades)
                {
                    gradesStr += $"{grade:f2} ";

                    sum += grade;
                }

                gradesStr = gradesStr.Trim();
                decimal average = sum / grades.Count;

                Console.WriteLine($"{student} -> {gradesStr} (avg: {average:f2})");
            }
        }
    }
}
