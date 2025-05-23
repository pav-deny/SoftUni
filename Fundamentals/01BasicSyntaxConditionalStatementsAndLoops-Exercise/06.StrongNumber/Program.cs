using System;
using System.Data;

namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //a number is "strong" if the sum of its digits' factoriels equals the number e.g.1!+4!+5!=145

            int number = int.Parse(Console.ReadLine());
            int digit, sum = 0;
            int varNumber = number; //This is the number that will change

            while (varNumber > 0)
            {
                int factorial = 1; //this will store the factorial (x!)
                digit = varNumber % 10;
                varNumber /= 10;

                for (int i = digit; i > 0; i--)
                {
                    factorial *= i;
                }
                sum += factorial;
            }

            if (sum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
