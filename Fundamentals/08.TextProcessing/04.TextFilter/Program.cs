using System.Text;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (string word in bannedWords)
            {
                int astricsLength = word.Length;

                string replaceWith = new string('*', astricsLength);

                text = text.Replace(word, replaceWith);
            }

            Console.WriteLine(text);
        }
    }
}
