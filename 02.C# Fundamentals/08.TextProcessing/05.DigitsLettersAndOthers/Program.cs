using System.Runtime.InteropServices;
using System.Text;

namespace _05.DigitsLettersAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder digits = new();
            StringBuilder letters = new();
            StringBuilder others = new();

            foreach (char c in text)
            {
                if(char.IsDigit(c))
                {
                    digits.Append(c);
                }
                else if (char.IsLetter(c))
                {
                    letters.Append(c);
                }
                else
                {
                    others.Append(c);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
