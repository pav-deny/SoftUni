using System.Text;

namespace _04.CeaserCypher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder encryptedText = new();

            foreach (char character in text)
            {
                char encryptedChar = (char)(character + 3);

                encryptedText.Append(encryptedChar);
            }

            Console.WriteLine(encryptedText.ToString());
        }
    }
}
