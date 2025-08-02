using System;

namespace _03.Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int day = int.Parse(Console.ReadLine());

            if (day >= 1 && day <= 7)
            {
                day--;
                Console.WriteLine(days[day]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
