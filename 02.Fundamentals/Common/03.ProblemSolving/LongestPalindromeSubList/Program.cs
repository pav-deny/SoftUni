namespace LongestPalindromeSubList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            string longestPalindrome = string.Empty;

            for (int i = 0; i < letters.Length; i++)
            {

                for (int j = i;  j < letters.Length; j++)
                {
                    string substring = letters.Substring(i, j - i + 1);

                    string reversed = new(substring.Reverse().ToArray());

                    if (reversed == substring && substring.Length > longestPalindrome.Length)
                    {
                        longestPalindrome = substring;
                    }
                }
            }

            Console.WriteLine(longestPalindrome.Length);
        }
    }
}
