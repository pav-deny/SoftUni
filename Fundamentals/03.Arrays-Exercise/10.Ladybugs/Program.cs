using System;
using System.Linq;

namespace _10.Ladybugs
{
    internal class Program
    {
        static void Main()
        {
            int fieldSize = int.Parse(Console.ReadLine());

            int[] field = new int[fieldSize];

            int[] bugsPositions = Console.ReadLine().Split().Select(int.Parse).Where(x => x < field.Length && x >= 0).ToArray();

            foreach (int position  in bugsPositions)
            {
                field[position] = 1;
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input.Split();

                int startPosition = int.Parse(commands[0]);
                string movementDirection = commands[1];
                int flightLength = int.Parse(commands[2]);

                if (startPosition >= field.Length || startPosition < 0)
                {
                    continue;
                }

                if (flightLength < 0)
                {
                    flightLength = Math.Abs(flightLength);

                    switch (movementDirection)
                    {
                        case "right":
                            movementDirection = "left";
                            break;

                        case "left":
                            movementDirection = "right";
                            break;
                    }
                }

                if (movementDirection == "right")
                {
                    int endPosition = startPosition + flightLength;

                    while (field[startPosition] == 1 && endPosition < field.Length)
                    {
                        if (field[endPosition] == 0)
                        {
                            field[startPosition] = 0;
                            field[endPosition] = 1;
                        }
                        else
                        {
                            endPosition++;
                        }
                    }

                    if (endPosition >= field.Length)
                    {
                        field[startPosition] = 0;
                    }
                }

                else if (movementDirection == "left")
                {
                    int endPosition = startPosition - flightLength;

                    while (field[startPosition] == 1 && endPosition >= 0)
                    {
                        if (field[endPosition] == 0)
                        {
                            field[startPosition] = 0;
                            field[endPosition] = 1;
                        }
                        else
                        {
                            endPosition--;
                        }
                    }
                    
                    if (endPosition < 0)
                    {
                        field[startPosition] = 0;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
