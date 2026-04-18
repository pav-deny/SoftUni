namespace _10.RadioactiveMutantBunnies
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] gridData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] lair = new char[gridData[0], gridData[1]];

            int[] playerCords = new int[2], lastCords = new int[2];
            List<int[]> bunnyCords = new();

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                string currentLine = Console.ReadLine();

                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    lair[i, j] = currentLine[j];

                    if (lair[i, j] == 'P')
                    {
                        playerCords[0] = i;
                        playerCords[1] = j;
                    }
                    else if (lair[i, j] == 'B')
                    {
                        bunnyCords.Add(new int[] { i, j });
                    }
                }
            }

            string moves = Console.ReadLine();
            bool isDead = false, hasWon = false;


            for (int i = 0; i < moves.Length; i++)
            {
                if (isDead == true)
                    break;

                lastCords[0] = playerCords[0];
                lastCords[1] = playerCords[1];

                lair[playerCords[0], playerCords[1]] = '.';

                if (moves[i] == 'U') 
                    playerCords[0]--;

                else if (moves[i] == 'D')
                    playerCords[0]++;

                else if (moves[i] == 'L')
                    playerCords[1]--;

                else if (moves[i] == 'R') 
                    playerCords[1]++;


                if (ValidateMove(lair, playerCords))
                {
                    if (CheckForBunnies(playerCords, bunnyCords))
                    {
                        isDead = true;
                    }
                    else
                    {
                        lair[playerCords[0], playerCords[1]] = 'P';
                    }
                }
                else
                    hasWon = true;

                List<int[]> newBunnies = new();

                foreach (int[] bunnyPos in bunnyCords)
                {
                    int row = bunnyPos[0];
                    int col = bunnyPos[1];

                    if (row + 1 < lair.GetLength(0) && lair[row + 1, col] != 'B')
                        newBunnies.Add(new int[] { row + 1, col });

                    if (row - 1 >= 0 && lair[row - 1, col] != 'B')
                        newBunnies.Add(new int[] { row - 1, col });

                    if (col + 1 < lair.GetLength(1) && lair[row, col + 1] != 'B')
                        newBunnies.Add(new int[] { row, col + 1 });

                    if (col - 1 >= 0 && lair[row, col - 1] != 'B')
                        newBunnies.Add(new int[] { row, col - 1 });
                }

                foreach (int[] pos in newBunnies)
                    lair[pos[0], pos[1]] = 'B';

                bunnyCords.AddRange(newBunnies);

                if (CheckForBunnies(playerCords, bunnyCords) && !hasWon)
                {
                    isDead = true;
                }
            }


            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                    Console.Write(lair[i, j]);

                Console.WriteLine();
            }


            if (isDead)
            {
                Console.WriteLine($"dead: {playerCords[0]} {playerCords[1]}");
            }
            else
            {
                Console.WriteLine($"won: {lastCords[0]} {lastCords[1]}");
            }
        }

        static bool ValidateMove(char[,] lair, int[] playerPos)
        {
            if (playerPos[0] >= 0 && playerPos[0] < lair.GetLength(0)
                && playerPos[1] >= 0 && playerPos[1] < lair.GetLength(1))
            {
                return true;
            }

            return false;
        }

        static bool CheckForBunnies(int[] playerPos, List<int[]> bunnyPos)
        {
            foreach (int[] bunnyP in bunnyPos)
            {
                if (bunnyP[0] == playerPos[0] && bunnyP[1] == playerPos[1])
                    return true;
            }

            return false;
        }
    }

}