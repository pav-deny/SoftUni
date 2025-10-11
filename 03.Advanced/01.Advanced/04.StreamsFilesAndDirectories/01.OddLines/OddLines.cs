namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new(inputFilePath);
            using StreamWriter writer = new(outputFilePath, false);

            int lineNumber = 0;

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                    break;

                if (lineNumber % 2 == 1)
                {
                    writer.WriteLine(line);
                }

                lineNumber++;
            }
        }
    }
}
