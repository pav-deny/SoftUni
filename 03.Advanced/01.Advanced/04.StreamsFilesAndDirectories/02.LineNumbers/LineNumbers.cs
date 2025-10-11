namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new(inputFilePath);
            using StreamWriter writer = new(outputFilePath, false);

            int lineCounter = 1;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                writer.WriteLine($"{lineCounter}. {line}");

                lineCounter++;
            }
        }
    }
}

