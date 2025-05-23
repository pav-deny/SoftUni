using System.ComponentModel.Design;

namespace _01.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            string ageGroup = string.Empty;

            if (age <= 2)
            {
                ageGroup = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                ageGroup = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                ageGroup = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                ageGroup = "adult";
            }
            else
            {
                ageGroup = "elder";
            }

            Console.WriteLine(ageGroup);

        }
    }

}