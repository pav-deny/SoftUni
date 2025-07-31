namespace _01.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stringsReversed = new();

            string @string = string.Empty;
            while ((@string = Console.ReadLine()) != "end")
            {
                string reversed = string.Empty;

                for (int i = @string.Length - 1; i >= 0; i--)
                {
                    reversed += @string[i];
                }

                stringsReversed.Add(@string, reversed);
            }

            foreach ((string word, string reversed) in stringsReversed)
            {
                Console.WriteLine(word + " = " + reversed);
            }
        }
    }
}
