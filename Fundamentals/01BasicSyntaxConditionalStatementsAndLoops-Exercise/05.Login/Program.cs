using System;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Empty;
            string inputPassword = string.Empty;
            int wrongAttempts = 0;

            for (int i = (username.Length - 1); i >= 0; i--)
            {
                char currentChar = username[i];

                password += currentChar;
            }

            while (true)
            {
                inputPassword = Console.ReadLine();

                if (inputPassword == password)
                {
                    Console.WriteLine($"User {username} logged in." );
                    break;
                }
                else
                {
                    wrongAttempts++;
                    if (wrongAttempts > 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                
            }
        }
    }
}
