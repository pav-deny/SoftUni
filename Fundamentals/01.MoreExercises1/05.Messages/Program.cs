namespace _05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < n; i++)
            {
                
                int messageInNums = int.Parse(Console.ReadLine());
                if (messageInNums > 1)
                {
                    int j = messageInNums, numberOfDigits = 0;

                    while (j > 0)
                    {
                        numberOfDigits++;
                        j /= 10;
                    }

                    int mainDigit = messageInNums % 10;
                    int offset = (mainDigit - 2) * 3;

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset += 1;
                    }

                    int letterIndex = (offset + numberOfDigits) - 1;

                    char letter = (char)(letterIndex + 97);

                    message += letter;
                }
                else if (messageInNums == 0)
                {
                    message += " ";
                }
            }
            Console.WriteLine(message);
        }
    }
}

