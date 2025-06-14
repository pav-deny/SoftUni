namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                uint num = uint.Parse(input);

                bool isPalindrome = CheckIfPalindrome(num, input);

                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool CheckIfPalindrome(uint num, string numAsString)
        {
            uint tempNum = num;
            string flippedNumAsString = "";

            for (int i = numAsString.Length; i > 0; i--)
            {
                flippedNumAsString += tempNum % 10;
                tempNum /= 10;
            }

            uint flippedNum = uint.Parse(flippedNumAsString);

            if (flippedNum == num)
            {
                return true;
            }

            return false;
        }
    }
}
