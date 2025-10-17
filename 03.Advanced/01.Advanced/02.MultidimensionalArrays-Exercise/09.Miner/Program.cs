namespace MinerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[n, n];
            int minerRow = 0;
            int minerCol = 0;
            int totalCoals = 0;

            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = row[j];
                    if (field[i, j] == 's')
                    {
                        minerRow = i;
                        minerCol = j;
                    }
                    else if (field[i, j] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            int collectedCoals = 0;

            foreach (var command in commands)
            {
                int nextRow = minerRow;
                int nextCol = minerCol;

                switch (command)
                {
                    case "up":
                        nextRow--;
                        break;
                    case "down":
                        nextRow++;
                        break;
                    case "left":
                        nextCol--;
                        break;
                    case "right":
                        nextCol++;
                        break;
                }

                if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= n)
                    continue;

                minerRow = nextRow;
                minerCol = nextCol;

                if (field[minerRow, minerCol] == 'c')
                {
                    collectedCoals++;
                    field[minerRow, minerCol] = '*';
                    if (collectedCoals == totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }
                else if (field[minerRow, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({minerRow}, {minerCol})");
        }
    }
}
