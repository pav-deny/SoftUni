namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isLongEnough = CheckLength(password);
            bool hasNoSpecialCharacters = CheckChars(password);
            bool hasAtleastTwoDigits = CheckDigits(password);

            bool hasError = false;

            if (!isLongEnough)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                hasError = true;
            }
            
            if (!hasNoSpecialCharacters)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                hasError = true;
            }

            if (!hasAtleastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
                hasError = true;
            }

            if (!hasError)
            {
                Console.WriteLine("Password is valid");
            }
            
        }

        static bool CheckLength(string password)
        {
            int length = 0;

            foreach (char c in password)
            {
                length++;
            }

            if (length >= 6 && length <= 10)
            {
                return true;
            }

            return false;
        }

        static bool CheckChars(string password)
        {
            foreach (char c in password)
            {
                if (!(char.IsLetterOrDigit(c)))
                {
                    return false;
                }
            }
            return true;
        }

        static bool CheckDigits(string password)
        {
            int digits = 0;
            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digits++;
                }
            }

            if (digits >= 2)
            {
                return true;
            }

            return false;
        }
    }
}
