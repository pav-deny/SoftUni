using System.Security.Cryptography.X509Certificates;

namespace _02.LastDigitName
{
    internal class Program
    {
      
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string name = LastDigitName(number,"");
           
            Console.WriteLine(name);
        }
        static string LastDigitName(int number, string name)
        {
            int lastDigit = number % 10;

            switch (lastDigit)
            {
                case 0:
                    name = "zero";
                    break;
                case 1:
                    name = "one";
                    break;
                case 2:
                    name = "two";
                    break;
                case 3:
                    name = "three";
                    break;
                case 4:
                    name = "four";
                    break;
                case 5:
                    name = "five";
                    break;
                case 6:
                    name = "six";
                    break;
                case 7:
                    name = "seven";
                    break;
                case 8:
                    name = "eight";
                    break;
                case 9:
                    name = "nine";
                    break;
            }

            return name;
            
        }
    }
}
