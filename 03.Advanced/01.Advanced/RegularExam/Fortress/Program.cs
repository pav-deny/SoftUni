namespace Fortress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int[] spyPos = new int[2];

            for (int i = 0; i < n; i++)
            {
                string currentLine = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentLine[j];

                    if (currentLine[j] == 'S')
                    {
                        spyPos[0] = i;
                        spyPos[1] = j;
                    }
                }
            }

            int stealthPoints = 100;

            while (stealthPoints > 0)
            {
                string movement = Console.ReadLine();

                int[] newPos = new int[] { spyPos[0], spyPos[1] };

                if (movement == "up")
                    newPos[0] -= 1;

                else if (movement == "down")
                    newPos[0] += 1;

                else if (movement == "left")
                    newPos[1] -= 1;

                else if (movement == "right")
                    newPos[1] += 1;


                if (!ValidatePosition(matrix, newPos))
                    continue;

                matrix[spyPos[0], spyPos[1]] = '.';
                spyPos = newPos;

                char currentPos = matrix[spyPos[0], spyPos[1]];

                if (currentPos == 'E')
                    break;

                else if (currentPos == 'G')
                    stealthPoints -= 40;

                else if (currentPos == 'B')
                {
                    stealthPoints += 15;

                    if (stealthPoints > 100)
                        stealthPoints = 100;
                }


                matrix[spyPos[0], spyPos[1]] = 'S';
            }

            if (stealthPoints > 0)
                Console.WriteLine("Mission accomplished. Spy extracted successfully.");

            else
                Console.WriteLine("Mission failed. Spy compromised.");

            Console.WriteLine($"Stealth level: {stealthPoints} units");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
        }

        static bool ValidatePosition(char[,] matrix, int[] pos)
        {
            return pos[0] >= 0 && pos[0] < matrix.GetLength(0)
                && pos[1] >= 0 && pos[1] < matrix.GetLength(1);
        }
    }
}
