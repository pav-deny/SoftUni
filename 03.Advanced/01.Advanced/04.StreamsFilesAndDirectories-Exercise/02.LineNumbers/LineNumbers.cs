namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = FormatLine(lines[i], i);
            }

            File.WriteAllLines(outputFilePath, lines);
        }

        private static string FormatLine(string line, int index)
        {
            int letterscount = 0, punctoaitonCount = 0;

            foreach (char c in line)
            {
                if (char.IsLetter(c)) 
                  letterscount++;

                else if (char.IsPunctuation(c))
                    punctoaitonCount++;
            }

            return $"Line {index + 1}: {line} ({letterscount})({punctoaitonCount})";
        }
    }
}

