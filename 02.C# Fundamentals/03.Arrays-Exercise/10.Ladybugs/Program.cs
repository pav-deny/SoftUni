using System;
using System.Linq;

namespace _10.Ladybugs
{
    internal class Program
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine()); //Setup part: fieldSize, bugPositions and the field itself

            int[] field = new int[fieldSize];

            int[] bugsPositions = Console.ReadLine().Split()
                .Select(int.Parse).Where(x => x >= 0 && x < fieldSize).ToArray();

            foreach (int position in bugsPositions)//Adds the ladybugs to the field
            {
                field[position] = 1;
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end") //Until given the end command
            {
                string[] commandArgs = command.Split(" ");

                int startPosition = int.Parse(commandArgs[0]);
                int flightLength = int.Parse(commandArgs[2]);

                if (!CheckIfValid(field, startPosition) || field[startPosition] == 0)//Checks if the start position is valid
                {
                    continue;
                }

                int endPosition = 0;
                field[startPosition] = 0;

                if (commandArgs[1] == "right")//If the direction is right
                {
                    endPosition = startPosition + flightLength;

                    while (CheckIfValid(field, endPosition) && field[endPosition] == 1) 
                    {
                        endPosition += flightLength; //fly to the next one
                    }

                    if (CheckIfValid(field, endPosition))
                    {
                        field[endPosition] = 1;
                    }
                }

                else if (commandArgs[1] == "left")//If the direction is left
                {
                    endPosition = startPosition - flightLength;

                    while (CheckIfValid(field, endPosition) && field[endPosition] == 1) 
                    {
                        endPosition -= flightLength; //fly to the next one
                    }

                    if (CheckIfValid(field, endPosition))
                    {
                        field[endPosition] = 1;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));//Write the field
        }

        static bool CheckIfValid(int[] field, int index)
        {
            if (index >= 0 && index < field.Length) //If the index is inside the array
            {
                return true;
            }

            return false;
        }
    }
}
