namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random rnd = new();

            for (int i  = 0; i < words.Length; i++)
            {
                int randomIndex = rnd.Next(0, words.Length);
                string temp = words[i];

                words[i] = words[randomIndex];
                words[randomIndex] = temp;
            }

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
